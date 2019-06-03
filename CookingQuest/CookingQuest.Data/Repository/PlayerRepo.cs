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
    public class PlayerRepo : IPlayerRepo
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly CookingQuestContext _dbContext;
        public PlayerRepo(CookingQuestContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<IEnumerable<PlayerModel>> GetAllPlayers()
        {
            try
            {
                return await Task.FromResult(Mapper.Map(_dbContext.Player));
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }

        public async Task<PlayerModel> GetPlayerById(int PlayerId)
        {
            try
            {
                var player = await _dbContext.Player.FindAsync(PlayerId);
                return Mapper.Map(player);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }
        public async Task<PlayerModel> GetPlayerByEmail(string email)
        {
            try
            {
                Account account = await Task.FromResult(_dbContext.Account.Where(a => a.Username == email).FirstOrDefault());
                if(account == null)
                {
                    throw new ArgumentException();
                }

                var player = await _dbContext.Player.FindAsync(account.PlayerId);
                return Mapper.Map(player);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }
        public async Task<IEnumerable<EquipmentModel>> GetPlayerEquipment(int PlayerId)
        {
            try
            {
                var player_equipment = await Task.FromResult(_dbContext.PlayerEquipment.Where(x => x.PlayerId == PlayerId));

                var equipment = Mapper.Map(await Task.FromResult(_dbContext.Equipment));

                var items = new List<EquipmentModel>();

                foreach (var equip in equipment)
                {
                    foreach (var pe in player_equipment)
                    {
                       
                        if (pe.EquipmentId == equip.EquipmentId)
                        {
                            equip.PlayerEquipmentId = pe.PlayerEquipmentId;
                            items.Add(equip);
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
        public async Task<IEnumerable<LocationModel>> GetUnlockedLocations(int PlayerId)
        {
            try
            {
                var player_equipment = await GetPlayerEquipment(PlayerId);
                var maxDifficulty = player_equipment.Where(y=>y.Type == "Dungeon").Max(x => x.Difficulty);

                return Mapper.Map(await Task.FromResult(_dbContext.Location.Where(x => x.Difficulty <= maxDifficulty)));

            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<LootModel>> GetLoot(int PlayerId)
        {
            try
            {
                var player_loot = await Task.FromResult(_dbContext.PlayerLoot.Where(x => x.PlayerId == PlayerId));

                var loot = Mapper.Map(await Task.FromResult(_dbContext.Loot));

                var items = new List<LootModel>();

                foreach (var l in loot)
                {
                    foreach (var pl in player_loot)
                    {
                        if (pl.LootId == l.LootId)
                        {
                            var flavor_loot = await Task.FromResult(_dbContext.FlavorLoot.Where(x => x.LootId == l.LootId).FirstOrDefault());
                            var flavor = await Task.FromResult(_dbContext.Flavor.Where(x => x.FlavorId == flavor_loot.FlavorId).FirstOrDefault());
                            l.Flavor = Mapper.Map(flavor);
                            l.Quantity = pl.Quantity;
                            l.PlayerLootId = pl.PlayerLootId;
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
        
        public async Task<bool> EditPlayer(PlayerModel player)
        {
            try
            {
                if (player == null || string.IsNullOrWhiteSpace(player.Name) || player?.Gold < 0)
                {
                    throw new ArgumentException();
                }

                Player CurrentPlayer = await _dbContext.Player.FindAsync(player.PlayerId);
                Player newPlayer = Mapper.Map(player);

                _dbContext.Entry(CurrentPlayer).CurrentValues.SetValues(newPlayer);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }
        public async Task<bool> EditPlayerLoot(LootModel lootModel)
        {
            try
            {
                if (lootModel == null)
                {
                    throw new ArgumentException();
                }

                PlayerLoot CurrentLoot = await _dbContext.PlayerLoot.FindAsync(lootModel.PlayerLootId);
                PlayerLoot newLoot = new PlayerLoot
                {
                    LootId = CurrentLoot.LootId,
                    PlayerId = CurrentLoot.PlayerId,
                    PlayerLootId = CurrentLoot.PlayerLootId,
                    Quantity = lootModel.Quantity,
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

        public async Task<bool> AddPlayerLoot(LootModel lootModel, int PlayerId)
        {
            try
            {
                Player player = await _dbContext.Player.FindAsync(PlayerId);
                Loot loot = Mapper.Map(lootModel);
                PlayerLoot pl =  await Task.FromResult(_dbContext.PlayerLoot.Where(x => x.LootId == lootModel.LootId && x.PlayerId == PlayerId).FirstOrDefault()) ?? new PlayerLoot();
                PlayerLoot playerLoot = new PlayerLoot()
                {
                    LootId = loot.LootId,
                    Quantity = lootModel.Quantity,
                    PlayerId = PlayerId,
                };
                if (pl.LootId == playerLoot.LootId && pl.PlayerId == playerLoot.PlayerId)
                {
                    playerLoot.Quantity = pl.Quantity + 1;
                    try
                    {
                        await DeletePlayerLoot(pl.PlayerLootId);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex.ToString());
                        return false;
                    }

                }

                _dbContext.PlayerLoot.Add(playerLoot);
                Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }

        public async Task<bool> AddPlayerLootArray(IEnumerable<LootModel> lootModel, int PlayerId)
        {
            foreach (var loot in lootModel)
            {
                try
                {
                    await AddPlayerLoot(loot, PlayerId);
                   
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                    return false;
                }
            }
            return true;
        }
        

        public async Task<bool> AddPlayerEquipment(EquipmentModel equipmentModel, int PlayerId)
        {
            try
            {
                Player player = await _dbContext.Player.FindAsync(PlayerId);
                Equipment equipment = Mapper.Map(equipmentModel);
                PlayerEquipment playerEquipment = new PlayerEquipment()
                {
                    EquipmentId = equipment.EquipmentId,
                    PlayerId = player.PlayerId,
                };

                _dbContext.PlayerEquipment.Add(playerEquipment);
                Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }

        public async Task<bool> EditPlayerEquipment(EquipmentModel equipmentModel)
        {
            try
            {
                if (equipmentModel == null)
                {
                    throw new ArgumentException();
                }

                Equipment equipment = await _dbContext.Equipment.FindAsync(equipmentModel.EquipmentId);
                Equipment equipment2 = Mapper.Map(equipmentModel);
                _dbContext.Entry(equipment).CurrentValues.SetValues(equipment2);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeletePlayerEquipment(int playerEquipmentId)
        {
            try
            {
                PlayerEquipment playerEquipment = await _dbContext.PlayerEquipment.FindAsync(playerEquipmentId);

                if (playerEquipment == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dbContext.PlayerEquipment.Remove(playerEquipment);
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
        public async Task<bool> DeletePlayerLoot(int PlayerLootId)
        {
            try
            {
                PlayerLoot playerLoot = await _dbContext.PlayerLoot.FindAsync(PlayerLootId);

                if (playerLoot == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dbContext.PlayerLoot.Remove(playerLoot);
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
