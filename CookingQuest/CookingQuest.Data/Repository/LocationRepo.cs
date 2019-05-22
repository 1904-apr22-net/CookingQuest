using CookingQuest.Data.Entities;
using CookingQuest.Library.IRepository;
using CookingQuest.Library.Models.Library;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CookingQuest.Data.Repository
{
    public class LocationRepo : ILocationRepo
    {
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly CookingQuestContext _dbContext;
        public LocationRepo(CookingQuestContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));


        public IEnumerable<LocationModel> GetAll()
        {
            try
            {
                return Mapper.Map(_dbContext.Location);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }

        public LocationModel Get(int id)
        {
            Location l;
            try
            {
                l = _dbContext.Location.FirstOrDefault(x => x.LocationId == id);
                return Mapper.Map(l);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
            
        }

       

        public int Create(LocationModel location, bool ignoreId = true)
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
            _dbContext.Location.Add(Mapper.Map(location));
            return location.LocationId;
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

        public bool Update(LocationModel location)
        {
            if (!location.Validate() && location.LocationId != 0)
            {
                throw new ArgumentException("Location Invalid", nameof(location));
            }
            var deleted = Delete(location.LocationId);

            if (!deleted)
            {
                return false;
            }

            Create(location, ignoreId: false);

            return true;
        }

        public bool Delete(int id)
        {
            if (Get(id) is LocationModel location)
            {
                _dbContext.Location.Remove(_dbContext.Location.First(x => x.LocationId == location.LocationId));
                return true;
            }
            return false;
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
    }
}
