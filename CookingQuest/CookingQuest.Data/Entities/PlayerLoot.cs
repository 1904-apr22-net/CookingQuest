using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class PlayerLoot
    {
        public int PlayerLootId { get; set; }
        public int PlayerId { get; set; }
        public int LootId { get; set; }
        public int Quantity { get; set; }

        public virtual Loot Loot { get; set; }
        public virtual Player Player { get; set; }
    }
}
