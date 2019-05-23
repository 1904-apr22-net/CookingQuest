using CookingQuest.Library.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingQuest.Library.IRepository
{
    public interface IPlayerRepo : IDisposable
    {
        Task<IEnumerable<PlayerModel>> GetAllPlayers();
        Task<PlayerModel> GetPlayerById(int PlayerId);
        Task<IEnumerable<EquipmentModel>> GetPlayerEquipment(int PlayerId);
        Task<IEnumerable<LocationModel>> GetUnlockedLocations(int PlayerId);
        Task<IEnumerable<LootModel>> GetLoot(int PlayerId);
        Task<int> AddPlayer(string name);
        Task<bool> EditPlayer(PlayerModel player);
        Task<bool> DeletePlayer(int PlayerId);
        void Save();
    }
}
