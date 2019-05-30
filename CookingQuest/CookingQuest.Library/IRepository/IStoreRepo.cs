using CookingQuest.Library.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookingQuest.Library.IRepository
{
    public interface IStoreRepo : IDisposable
    {
        void Save();
        IEnumerable<StoreModel> GetAll();
        StoreModel Get(int id);
        int Create(StoreModel store, bool ignoreId = true);
        bool Update(StoreModel store);
        bool Delete(int id);

    }
}
