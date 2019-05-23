using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class Store
    {
        public Store()
        {
            StoreEquipment = new HashSet<StoreEquipment>();
            StoreFlavor = new HashSet<StoreFlavor>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }

        public virtual ICollection<StoreEquipment> StoreEquipment { get; set; }
        public virtual ICollection<StoreFlavor> StoreFlavor { get; set; }

        internal bool Validate()
        {
            throw new NotImplementedException();
        }

        public static implicit operator Store(CookingQuestContext v)
        {
            throw new NotImplementedException();
        }
    }
}
