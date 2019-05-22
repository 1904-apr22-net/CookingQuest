using CookingQuest.Data.Repository;
using CookingQuest.Library.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CookingQuest.Tests
{
    public class LocationRepoTests
    {
        private readonly LocationRepo _repo;

        public LocationRepoTests() : this(new LocationRepo
        {
            new LocationModel { LocationId = 1, Name = "TestMarket", Description = "Empty", Difficulty=1 }
        })
        { }

        public LocationRepoTests(LocationRepo list)
        {
            _repo = list ?? throw new ArgumentNullException(nameof(list));
        }

        [Fact]
        public void GetById_Acceptable_Id ()
        {

        }
    }
}
