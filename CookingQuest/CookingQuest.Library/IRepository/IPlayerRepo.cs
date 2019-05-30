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
        Task<PlayerModel> GetPlayerByEmail(string email);
        Task<IEnumerable<EquipmentModel>> GetPlayerEquipment(int PlayerId);
        Task<IEnumerable<LocationModel>> GetUnlockedLocations(int PlayerId);
        Task<IEnumerable<LootModel>> GetLoot(int PlayerId);
        Task<bool> EditPlayer(PlayerModel player);
        Task<bool> EditPlayerLoot(LootModel lootModel);
        Task<bool> EditPlayerEquipment(EquipmentModel equipmentModel);
        Task<bool> DeletePlayerEquipment(int playerEquipmentId);
        Task<bool> DeletePlayerLoot(int PlayerLootId);
        Task<bool> AddPlayerEquipment(EquipmentModel equipmentModel, int PlayerId);
        void Save();
    }
}
