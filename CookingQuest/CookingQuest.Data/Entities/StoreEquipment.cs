using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class StoreEquipment
    {
        public int StoreEquipmentId { get; set; }
        public int StoreId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Store Store { get; set; }
    }
}
