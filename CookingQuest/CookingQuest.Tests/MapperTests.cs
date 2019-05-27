using System;
using System.Collections.Generic;
using System.Text;
using CookingQuest.Data;
using CookingQuest.Data.Entities;
using CookingQuest.Data.Repository;
using CookingQuest.Library.Models.Library;
using Xunit;

namespace CookingQuest.Tests
{
    public class MapperTests
    {
        [Fact]
        public void AccountModel()
        {
            var model = new AccountModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }

        [Fact]
        public void EquipmentModel()
        {
            var model = new EquipmentModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }

        [Fact]
        public void FlavorLootModel()
        {
            var model = new FlavorLootModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void FlavorModel()
        {
            var model = new FlavorModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void LocationLootModel()
        {
            var model = new LocationLootModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void LocationModel()
        {
            var model = new LocationModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void LootModel()
        {
            var model = new LootModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void PlayerEquipmentModel()
        {
            var model = new PlayerEquipmentModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void PlayerLocationModel()
        {
            var model = new PlayerLocationModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void PlayerLootModel()
        {
            var model = new PlayerLootModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void PlayerModel()
        {
            var model = new PlayerModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void RecipeLootModel()
        {
            var model = new RecipeLootModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void RecipeModel()
        {
            var model = new RecipeModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void StoreEquipmentModel()
        {
            var model = new StoreEquipmentModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void StoreFlavor()
        {
            var model = new StoreFlavor();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void Store()
        {
            var model = new Store();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }



    }
}
