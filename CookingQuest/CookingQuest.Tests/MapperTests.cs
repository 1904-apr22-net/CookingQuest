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
        public void StoreFlavorModel()
        {
            var model = new StoreFlavorModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }
        [Fact]
        public void StoreModel()
        {
            var model = new StoreModel();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);

            Assert.IsAssignableFrom(model.GetType(), model3);
        }


        [Fact]
        public void Account()
        {
            IEnumerable<Account> model = new List<Account>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }

        [Fact]
        public void FlavorLoot()
        {
            IEnumerable<FlavorLoot> model = new List<FlavorLoot>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void Equipment()
        {
            IEnumerable<Equipment> model = new List<Equipment>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void Flavor()
        {
            IEnumerable<Flavor> model = new List<Flavor>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void LocationLoot()
        {
            IEnumerable<LocationLoot> model = new List<LocationLoot>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void Location()
        {
            IEnumerable<Location> model = new List<Location>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void Loot()
        {
            IEnumerable<Loot> model = new List<Loot>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void PlayerEquipment()
        {
            IEnumerable<PlayerEquipment> model = new List<PlayerEquipment>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void PlayerLocation()
        {
            IEnumerable<PlayerLocation> model = new List<PlayerLocation>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void PlayerLoot()
        {
            IEnumerable<PlayerLoot> model = new List<PlayerLoot>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void Player()
        {
            IEnumerable<Player> model = new List<Player>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void RecipeLoot()
        {
            IEnumerable<RecipeLoot> model = new List<RecipeLoot>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void Recipe()
        {
            IEnumerable<Recipe> model = new List<Recipe>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void StoreEquipment()
        {
            IEnumerable<StoreEquipment> model = new List<StoreEquipment>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void StoreFlavor()
        {
            IEnumerable<StoreFlavor> model = new List<StoreFlavor>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
        [Fact]
        public void Store()
        {
            IEnumerable<Store> model = new List<Store>();
            var model2 = Mapper.Map(model);
            var model3 = Mapper.Map(model2);
            var model4 = Mapper.Map(model3);
            var model5 = Mapper.Map(model4);

            Assert.IsType(model3.GetType(), model5);
        }
    }
}
