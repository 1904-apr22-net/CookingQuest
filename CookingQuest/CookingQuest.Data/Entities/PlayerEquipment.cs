using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class PlayerEquipment
    {
        public int PlayerEquipmentId { get; set; }
        public int PlayerId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Player Player { get; set; }
    }
}
