using CookingQuest.Library.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingQuest.Library.IRepository
{
    public interface ILootRepo : IDisposable
    {
        Task<IEnumerable<LootModel>> GetAllLoot();
        Task<LootModel> GetLootById(int PlayerId);
        Task<int> AddLoot(LootModel equipmentModel);
        Task<bool> EditLoot(LootModel equipmentModel);
        Task<bool> DeleteLoot(int equipmentId);
        void Save();
    }
}
