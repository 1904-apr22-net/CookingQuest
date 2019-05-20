using System;
using System.Collections.Generic;
using System.Text;

namespace CookingQuest.Library.Models.Library
{
    public class PlayerLootModel
    {
        public int PlayerLootId { get; set; }
        public int PlayerId { get; set; }
        public int LootId { get; set; }
        public int Quantity { get; set; }
    }
}
