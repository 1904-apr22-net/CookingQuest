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
        public async Task<IEnumerable<EquipmentModel>> GetPlayerEquipment(int PlayerId)
        {
            try
            {
                var player_equipment = await Task.FromResult(_dbContext.PlayerEquipment.Where(x => x.PlayerId == PlayerId));

                var equipment = await Task.FromResult(_dbContext.Equipment);

                var items = new List<Equipment>();

                foreach (var equip in equipment)
                {
                    foreach (var pe in player_equipment)
                    {
                        if (pe.EquipmentId == equip.EquipmentId)
                        {
                            items.Add(equip);
                        }
                    }
                }
                return Mapper.Map(items);
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
                            l.Quantity = pl.Quantity;
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
        public async Task<int> AddPlayer(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException();
                }

                PlayerModel player = new PlayerModel
                {
                    Name = name,
                };
                await _dbContext.Player.AddAsync(Mapper.Map(player));
                Save();
                 
                return await Task.FromResult(_dbContext.Player.OrderByDescending(x=>x.PlayerId).FirstOrDefault().PlayerId);
            }

            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return -1;
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

        public async Task<bool> DeletePlayer(int PlayerId)
        {
            try
            {
                Player CurrentPlayer = await _dbContext.Player.FindAsync(PlayerId);

                if(await Task.FromResult(_dbContext.Account.FirstOrDefault(x => x.PlayerId == PlayerId)) != null){
                    throw new ArgumentException();
                }

                if(CurrentPlayer == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dbContext.Player.Remove(CurrentPlayer);
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
