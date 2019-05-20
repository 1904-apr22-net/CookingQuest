using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CookingQuest.Library.Models.Library
{
    public class FlavorLootModel
    {
        public int FlavorLootId { get; set; }
        public int FlavorId { get; set; }
        public int LootId { get; set; }
    }
}
