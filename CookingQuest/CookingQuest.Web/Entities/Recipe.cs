using System;
using System.Collections.Generic;

namespace CookingQuest.Web.Entities
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeLoot = new HashSet<RecipeLoot>();
        }

        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RecipeLoot> RecipeLoot { get; set; }
    }
}
