using CookingQuest.Data.Entities;
using CookingQuest.Library.IRepository;
using CookingQuest.Library.Models.Library;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CookingQuest.Data.Repository
{
    public class LocationRepo : ILocationRepo
    {
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly CookingQuestContext _dbContext;
        public LocationRepo(CookingQuestContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));


        public async Task<IEnumerable<LocationModel>> GetAll()
        {
            try
            {
                return await Task.FromResult(Mapper.Map(_dbContext.Location));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }

        public async Task<LocationModel> Get(int id)
        {
            Location l;
            try
            {
                l = _dbContext.Location.FirstOrDefault(x => x.LocationId == id);
                return await Task.FromResult(Mapper.Map(l));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
            
        }

        public async Task<IEnumerable<LootModel>> GetLocationLoot(int id) {
            try
            {
                var location_loot = await Task.FromResult(Mapper.Map(_dbContext.LocationLoot.Where(x => x.LocationId == id)));
                var loot = Mapper.Map(await Task.FromResult(_dbContext.Loot));

                var items = new List<LootModel>();

                foreach (var l in loot)
                {
                    foreach (var pl in location_loot)
                    {
                        if (pl.LootId == l.LootId)
                        {
                            l.DropRate = pl.DropRate;
                            l.LocationLootId = pl.LocationLootId;
                            items.Add(l);
                        }
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }
        public async Task<IEnumerable<LootModel>> GetQuestLoot(int locationID, int modifier)
        {
            var lootlist = await GetLocationLoot(locationID);
            var lootlist2 = new List<LootModel>();
            Random rand = new Random();
            foreach (var loot in lootlist)
            {
                int roll = rand.Next(101) * modifier;
                if (roll > loot.DropRate)
                {
                    lootlist2.Add(loot);
                }
            }
            return lootlist2;
        }



        public async Task<int> Create(LocationModel location, bool ignoreId = true)
        {
            if (location is null)
            {
                throw new ArgumentNullException(nameof(location));
            }
            if (!location.Validate())
            {
                throw new ArgumentException("Location Invalid", nameof(location));
            }
            if (ignoreId)
            {
                location.LocationId = (_dbContext.Location.Count() == 0) ? 1 : (_dbContext.Location.Max(x => x.LocationId) + 1);
            }
            try
            {
                _dbContext.Location.Add(Mapper.Map(location));
                Save();
                return await Task.FromResult(location.LocationId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return 0;
            }
        }


        public async Task<bool> Update(LocationModel location)
        {
            if (!location.Validate() && location.LocationId != 0)
            {
                throw new ArgumentException("Location Invalid", nameof(location));
            }
            try
            {
                var deleted = await DeleteAsync(location.LocationId);
                if (!deleted)
                {
                    return false;
                }
                await Create(location, ignoreId: false);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }

        public async Task<bool> EditLocationLoot(LootModel lootModel)
        {
            try
            {
                if (lootModel == null)
                {
                    throw new ArgumentException();
                }

                LocationLoot CurrentLoot = await _dbContext.LocationLoot.FindAsync(lootModel.LocationLootId);
                LocationLoot newLoot = new LocationLoot
                {
                    LootId = CurrentLoot.LootId,
                    LocationId = CurrentLoot.LocationId,
                    LocationLootId = CurrentLoot.LocationLootId,
                    DropRate = lootModel.DropRate,
                };
                _dbContext.Entry(CurrentLoot).CurrentValues.SetValues(newLoot);


                Loot loot = await _dbContext.Loot.FindAsync(lootModel.LootId);
                Loot newLoot2 = Mapper.Map(lootModel);
                _dbContext.Entry(loot).CurrentValues.SetValues(newLoot2);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Location deletedlocation = await _dbContext.Location.FindAsync(id);

                //if (Get(id) is LocationModel location)
                if (deletedlocation == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dbContext.Location.Remove(deletedlocation);
                    Save();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteLocationLoot(int LocationLootId)
        {
            try
            {
                LocationLoot locationLoot = await _dbContext.LocationLoot.FindAsync(LocationLootId);

                if (locationLoot == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dbContext.LocationLoot.Remove(locationLoot);
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
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        private bool disposedValue = false; // To detect redundant calls

        public void Dispose()
        {
            Dispose(true);
        }

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
    }
}
