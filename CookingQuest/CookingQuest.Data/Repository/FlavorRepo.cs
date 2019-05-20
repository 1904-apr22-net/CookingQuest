using CookingQuest.Data.Entities;
using CookingQuest.Library.IRepository;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
namespace CookingQuest.Data.Repository
{
    public class FlavorRepo : IFlavorRepo
    {
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly CookingQuestContext _dbContext;
        public FlavorRepo(CookingQuestContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));



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
