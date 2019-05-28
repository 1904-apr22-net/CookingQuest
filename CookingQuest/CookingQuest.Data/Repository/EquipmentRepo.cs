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
    public class EquipmentRepo : IEquipmentRepo
    {
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly CookingQuestContext _dbContext;
        public EquipmentRepo(CookingQuestContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<IEnumerable<EquipmentModel>> GetAllEquipment()
        {
            try
            {
                return await Task.FromResult(Mapper.Map(_dbContext.Equipment));
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }

        public async Task<EquipmentModel> GetEquipmentById(int PlayerId)
        {
            try
            {
                var equipment = await _dbContext.Equipment.FindAsync(PlayerId);
                return Mapper.Map(equipment);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }
        public async Task<int> AddEquipment(EquipmentModel equipmentModel)
        {
            try
            {
                if (equipmentModel == null)
                {
                    throw new ArgumentException();
                }

                await _dbContext.Equipment.AddAsync(Mapper.Map(equipmentModel));
                Save();

                return await Task.FromResult(_dbContext.Equipment.OrderByDescending(x => x.EquipmentId).FirstOrDefault().EquipmentId);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return -1;
            }
        }
        public async Task<bool> EditEquipment(EquipmentModel equipmentModel)
        {
            try
            {
                if (equipmentModel == null)
                {
                    throw new ArgumentException();
                }

                Equipment currentEquipment = await _dbContext.Equipment.FindAsync(equipmentModel.EquipmentId);
                Equipment newEquipment = Mapper.Map(equipmentModel);

                _dbContext.Entry(currentEquipment).CurrentValues.SetValues(newEquipment);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteEquipment(int equipmentId)
        {
            try
            {
                Equipment currentEquipment = await _dbContext.Equipment.FindAsync(equipmentId);


                if (currentEquipment == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dbContext.Equipment.Remove(currentEquipment);
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
