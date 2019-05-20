using System;
using System.Collections.Generic;
using System.Text;

namespace CookingQuest.Library.Models.Library
{
    public class PlayerLocationModel
    {
        public int PlayerLocationId { get; set; }
        public int PlayerId { get; set; }
        public int LocationId { get; set; }
    }
}
