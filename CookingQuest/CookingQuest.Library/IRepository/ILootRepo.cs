using System;
using System.Collections.Generic;
using System.Text;

namespace CookingQuest.Library.IRepository
{
    public interface ILootRepo : IDisposable
    {
        void Save();
    }
}
