using System;
using System.Collections.Generic;
using System.Text;

namespace CookingQuest.Library.IRepository
{
    public interface IAccountRepo : IDisposable
    {
        void Save();
    }
}
