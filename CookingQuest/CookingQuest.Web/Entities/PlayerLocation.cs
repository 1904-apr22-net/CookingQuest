using System;
using System.Collections.Generic;

namespace CookingQuest.Web.Entities
{
    public partial class PlayerLocation
    {
        public int PlayerLocation1 { get; set; }
        public int PlayerId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Player Player { get; set; }
    }
}
