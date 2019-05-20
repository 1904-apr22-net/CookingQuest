using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class Flavor
    {
        public Flavor()
        {
            FlavorLoot = new HashSet<FlavorLoot>();
            StoreFlavor = new HashSet<StoreFlavor>();
        }

        public int FlavorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FlavorLoot> FlavorLoot { get; set; }
        public virtual ICollection<StoreFlavor> StoreFlavor { get; set; }
    }
}
