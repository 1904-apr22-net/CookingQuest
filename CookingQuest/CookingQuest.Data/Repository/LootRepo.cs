using CookingQuest.Data.Entities;
using CookingQuest.Library.IRepository;
using CookingQuest.Library.Models.Library;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingQuest.Data.Repository
{
    public class LootRepo : ILootRepo
    {
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly CookingQuestContext _dbContext;
        public LootRepo(CookingQuestContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<IEnumerable<LootModel>> GetAllLoot()
        {
            try
            {
                return await Task.FromResult(Mapper.Map(_dbContext.Loot));
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }

        public async Task<LootModel> GetLootById(int lootId)
        {
            try
            {
                var equipment = await _dbContext.Loot.FindAsync(lootId);
                return Mapper.Map(equipment);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }

        public async Task<int> AddLoot(LootModel lootModel)
        {
            try
            {
                if (lootModel == null)
                {
                    throw new ArgumentException();
                }

                await _dbContext.Loot.AddAsync(Mapper.Map(lootModel));
                Save();

                return await Task.FromResult(_dbContext.Loot.OrderByDescending(x => x.LootId).FirstOrDefault().LootId);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return -1;
            }
        }
        public async Task<bool> EditLoot(LootModel lootModel)
        {
            try
            {
                if (lootModel == null)
                {
                    throw new ArgumentException();
                }

                Loot currentLoot = await _dbContext.Loot.FindAsync(lootModel.LootId);
                Loot newLoot = Mapper.Map(lootModel);

                _dbContext.Entry(currentLoot).CurrentValues.SetValues(newLoot);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteLoot(int lootId)
        {
            try
            {
                Loot currentLoot = await _dbContext.Loot.FindAsync(lootId);


                if (currentLoot == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dbContext.Loot.Remove(currentLoot);
                    Save();
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

    }
}
