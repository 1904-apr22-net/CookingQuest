using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class StoreFlavor
    {
        public int StoreFlavorId { get; set; }
        public int StoreId { get; set; }
        public int FlavorId { get; set; }
        public int Bonus { get; set; }

        public virtual Flavor Flavor { get; set; }
        public virtual Store Store { get; set; }
    }
}
