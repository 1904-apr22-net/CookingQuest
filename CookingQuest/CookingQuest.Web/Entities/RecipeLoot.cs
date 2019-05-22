using System;
using System.Collections.Generic;

namespace CookingQuest.Web.Entities
{
    public partial class RecipeLoot
    {
        public int RecipeLootId { get; set; }
        public int RecipeId { get; set; }
        public int LootId { get; set; }

        public virtual Loot Loot { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
