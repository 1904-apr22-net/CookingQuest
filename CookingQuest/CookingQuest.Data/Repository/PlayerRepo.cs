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
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly CookingQuestContext _dbContext;
        public PlayerRepo(CookingQuestContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<PlayerModel> GetAllPlayers()
        {
            try
            {
                return Mapper.Map(_dbContext.Player);
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
