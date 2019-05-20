using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingQuest.Library.Models.Library
{
    public class LocationLootModel
    {
        public int LocationLootId { get; set; }
        public int LocationId { get; set; }
        public int LootId { get; set; }
        public int DropRate { get; set; }
    }
}
