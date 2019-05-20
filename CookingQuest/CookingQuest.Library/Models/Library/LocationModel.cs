﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingQuest.Library.Models.Library
{
    public class LocationModel
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string Description { get; set; }
    }
}
