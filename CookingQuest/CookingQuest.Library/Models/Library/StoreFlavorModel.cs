using System;
using System.Collections.Generic;
using System.Text;

namespace CookingQuest.Library.Models.Library
{
    public class StoreFlavorModel
    {
        public int StoreFlavorId { get; set; }
        public int StoreId { get; set; }
        public int FlavorId { get; set; }
        public int Bonus { get; set; }
    }
}
