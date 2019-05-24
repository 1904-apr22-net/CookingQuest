using CookingQuest.Data.Entities;
using CookingQuest.Library.IRepository;
using CookingQuest.Library.Models.Library;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookingQuest.Data.Repository
{
    public class StoreRepo : IStoreRepo
    {
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly CookingQuestContext _dbContext;
        public StoreRepo(CookingQuestContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<StoreModel> GetAll()
        {
            try
            {
                return Mapper.Map(_dbContext.Store);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public StoreModel Get(int id)
        {
            Store store;
            try
            {
                store = _dbContext.Store.FirstOrDefault(x => x.StoreId == id);
                return Mapper.Map(store);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
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

        public int Create(StoreModel store, bool ignoreId = true)
        {
            if (store is null)
            {
                throw new ArgumentNullException(nameof(store));
            }
            if (!store.Validate())
            {
                throw new ArgumentException("Invalid store", nameof(store));
            }
            if (ignoreId)
            {
                store.StoreId = (_dbContext.Store.Count() == 0) ? 1 : (_dbContext.Store.Max(x => x.StoreId) + 1);
            }
            _dbContext.Store.Add(Mapper.Map(store));
            return store.StoreId;
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

        public bool Update(StoreModel store)
        {
            if(!store.Validate() && store.StoreId != 0)
            {
                throw new ArgumentException("Invalid store", nameof(store));
            }
            bool deleted = Delete(store.StoreId);
            if (!deleted)
            {
                return false;
            }
            Create(store);
            return true;
        }

        public bool Delete(int id)
        {
            if(Get(id) is StoreModel store)
            {
                _dbContext.Remove(store);
                return true;
            }
            return false;
        }
    }
}
