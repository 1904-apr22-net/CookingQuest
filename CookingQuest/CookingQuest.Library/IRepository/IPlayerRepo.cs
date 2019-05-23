using CookingQuest.Library.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingQuest.Library.IRepository
{
    public interface IPlayerRepo : IDisposable
    {
        IEnumerable<PlayerModel> GetAllPlayers();
        Task<PlayerModel> GetPlayerById(int PlayerId);

        void Save();
    }
}
