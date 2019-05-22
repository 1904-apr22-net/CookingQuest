using System;
using System.Collections.Generic;

namespace CookingQuest.Web.Entities
{
    public partial class Location
    {
        public Location()
        {
            LocationLoot = new HashSet<LocationLoot>();
            PlayerLocation = new HashSet<PlayerLocation>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LocationLoot> LocationLoot { get; set; }
        public virtual ICollection<PlayerLocation> PlayerLocation { get; set; }
    }
}
