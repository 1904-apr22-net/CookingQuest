using System;
using System.Collections.Generic;
using System.Text;

namespace CookingQuest.Library.IRepository
{
    public interface ILocationRepo : IDisposable
    {
        void Save();
    }
}
