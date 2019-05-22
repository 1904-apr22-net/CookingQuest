using System;
using System.Collections.Generic;

namespace CookingQuest.Web.Entities
{
    public partial class Equipment
    {
        public Equipment()
        {
            PlayerEquipment = new HashSet<PlayerEquipment>();
            StoreEquipment = new HashSet<StoreEquipment>();
        }

        public int EquipmentId { get; set; }
        public int Modifier { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public int Difficulty { get; set; }

        public virtual ICollection<PlayerEquipment> PlayerEquipment { get; set; }
        public virtual ICollection<StoreEquipment> StoreEquipment { get; set; }
    }
}
