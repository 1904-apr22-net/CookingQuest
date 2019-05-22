using System;
using System.Collections.Generic;

namespace CookingQuest.Web.Entities
{
    public partial class Loot
    {
        public Loot()
        {
            FlavorLoot = new HashSet<FlavorLoot>();
            LocationLoot = new HashSet<LocationLoot>();
            PlayerLoot = new HashSet<PlayerLoot>();
            RecipeLoot = new HashSet<RecipeLoot>();
        }

        public int LootId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FlavorLoot> FlavorLoot { get; set; }
        public virtual ICollection<LocationLoot> LocationLoot { get; set; }
        public virtual ICollection<PlayerLoot> PlayerLoot { get; set; }
        public virtual ICollection<RecipeLoot> RecipeLoot { get; set; }
    }
}
