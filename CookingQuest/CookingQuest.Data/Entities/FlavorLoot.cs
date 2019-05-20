using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class FlavorLoot
    {
        public int FlavorLootId { get; set; }
        public int FlavorId { get; set; }
        public int LootId { get; set; }

        public virtual Flavor Flavor { get; set; }
        public virtual Loot Loot { get; set; }
    }
}
