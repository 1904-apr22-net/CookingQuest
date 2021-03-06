﻿using CookingQuest.Library.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingQuest.Library.IRepository
{

    
    public interface ILocationRepo : IDisposable
    {
        Task<IEnumerable<LocationModel>> GetAll();
        Task<LocationModel> Get(int id);
        Task<IEnumerable<LootModel>> GetLocationLoot(int id);
        Task<IEnumerable<LootModel>> GetQuestLoot(int id, int equipmentid);
        Task<int> Create(LocationModel location, bool ignoreId = true);
        Task<bool> Update(LocationModel location);
        Task<bool> EditLocationLoot(LootModel lootModel);
        Task<bool> DeleteAsync(int id);
        void Save();
    }
}
