using System;
using System.Collections.Generic;
using System.Text;

namespace CookingQuest.Library.Models.Library
{
    public class StoreModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }
        public List<FlavorModel> Flavors { get; set; } = new List<FlavorModel>();
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                return false;
            }
            if (StoreId < 0)
            {
                return false;
            }
            return true;

        }
    }


}
