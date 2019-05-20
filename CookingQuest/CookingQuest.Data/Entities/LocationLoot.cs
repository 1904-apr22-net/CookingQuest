using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class LocationLoot
    {
        public int LocationLootId { get; set; }
        public int LocationId { get; set; }
        public int LootId { get; set; }
        public int DropRate { get; set; }

        public virtual Location Location { get; set; }
        public virtual Loot Loot { get; set; }
    }
}
