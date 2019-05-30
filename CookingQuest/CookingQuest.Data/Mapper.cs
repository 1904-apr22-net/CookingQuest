using CookingQuest.Data.Entities;
using CookingQuest.Library.Models.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookingQuest.Data
{
    public class Mapper
    {
        public static Store Map(StoreModel store) => new Store
        {
            StoreId = store.StoreId,
            Name = store.Name,
            Description = store.Description,
            Difficulty = store.Difficulty,
        };
        public static StoreModel Map(Store store) => new StoreModel
        {
            StoreId = store.StoreId,
            Name = store.Name,
            Description = store.Description,
            Difficulty = store.Difficulty,
        };

        public static Recipe Map(RecipeModel recipe) => new Recipe
        {
            RecipeId = recipe.RecipeId,
            Name = recipe.Name,
            Description = recipe.Description,
        };
        public static RecipeModel Map(Recipe recipe) => new RecipeModel
        {
            RecipeId = recipe.RecipeId,
            Name = recipe.Name,
            Description = recipe.Description,
        };
        public static Player Map(PlayerModel player) => new Player
        {
            PlayerId = player.PlayerId,
            Name = player.Name,
            Gold = player.Gold,
        };
        public static PlayerModel Map(Player player) => new PlayerModel
        {
            PlayerId = player.PlayerId,
            Name = player.Name,
            Gold = player.Gold,
        };
        public static Loot Map(LootModel loot) => new Loot
        {
            LootId = loot.LootId,
            Name = loot.Name,
            Price = loot.Price,
            Description = loot.Description,
        };
        public static LootModel Map(Loot loot) => new LootModel
        {
            LootId = loot.LootId,
            Name = loot.Name,
            Price = loot.Price,
            Description = loot.Description,
        };
        public static Account Map(AccountModel account) => new Account
        {
            AccountId = account.AccountId,
            Username = account.Username,
            Password = account.Password,
            PlayerId = account.PlayerId,
            IsAdmin = account.IsAdmin,
        };
        public static AccountModel Map(Account account) => new AccountModel
        {
            AccountId = account.AccountId,
            Username = account.Username,
            Password = account.Password,
            PlayerId = account.PlayerId,
            IsAdmin = account.IsAdmin,
        };
        public static Equipment Map(EquipmentModel equipment) => new Equipment
        {
            EquipmentId = equipment.EquipmentId,
            Modifier = equipment.Modifier,
            Name = equipment.Name,
            Price = equipment.Price,
            Type = equipment.Type,
            Difficulty = equipment.Difficulty,
        };

        public static EquipmentModel Map(Equipment equipment) => new EquipmentModel
        {
            EquipmentId = equipment.EquipmentId,
            Modifier = equipment.Modifier,
            Name = equipment.Name,
            Price = equipment.Price,
            Type = equipment.Type,
            Difficulty = equipment.Difficulty,
        };
        public static Flavor Map(FlavorModel flavor) => new Flavor
        {
            FlavorId = flavor.FlavorId,
            Name = flavor.Name,
            Description = flavor.Description,
        };
        public static FlavorModel Map(Flavor flavor) => new FlavorModel
        {
            FlavorId = flavor.FlavorId,
            Name = flavor.Name,
            Description = flavor.Description,
        };

        public static Location Map(LocationModel locationModel) => new Location
        {
            LocationId = locationModel.LocationId,
            Name = locationModel.Name,
            Difficulty = locationModel.Difficulty,
            Description = locationModel.Description,
        };
        public static LocationModel Map(Location location) => new LocationModel
        {
            LocationId = location.LocationId,
            Name = location.Name,
            Difficulty = location.Difficulty,
            Description = location.Description,
        };
        public static FlavorLoot Map(FlavorLootModel flavorLootModel) => new FlavorLoot
        {
            FlavorLootId = flavorLootModel.FlavorLootId,
            FlavorId = flavorLootModel.FlavorId,
            LootId = flavorLootModel.LootId,
        };
        public static FlavorLootModel Map(FlavorLoot flavorLoot) => new FlavorLootModel
        {
            FlavorLootId = flavorLoot.FlavorLootId,
            FlavorId = flavorLoot.FlavorId,
            LootId = flavorLoot.LootId,
        };

        public static LocationLoot Map(LocationLootModel locationLootModel) => new LocationLoot
        {
            LocationLootId = locationLootModel.LocationLootId,
            LocationId = locationLootModel.LocationId,
            LootId = locationLootModel.LootId,
            DropRate = locationLootModel.DropRate,
        };
        public static LocationLootModel Map(LocationLoot locationLoot) => new LocationLootModel
        {
            LocationLootId = locationLoot.LocationLootId,
            LocationId = locationLoot.LocationId,
            LootId = locationLoot.LootId,
            DropRate = locationLoot.DropRate,
        };
        public static PlayerEquipment Map(PlayerEquipmentModel player) => new PlayerEquipment
        {
            PlayerEquipmentId = player.PlayerEquipmentId,
            PlayerId = player.PlayerId,
            EquipmentId = player.EquipmentId,
        };
        public static PlayerEquipmentModel Map(PlayerEquipment player) => new PlayerEquipmentModel
        {
            PlayerEquipmentId = player.PlayerEquipmentId,
            PlayerId = player.PlayerId,
            EquipmentId = player.EquipmentId,
        };
        public static PlayerLocation Map(PlayerLocationModel player) => new PlayerLocation
        {
            PlayerLocation1 = player.PlayerLocationId,
            PlayerId = player.PlayerId,
            LocationId = player.LocationId,
        };
        public static PlayerLocationModel Map(PlayerLocation player) => new PlayerLocationModel
        {
            PlayerLocationId = player.PlayerLocation1,
            PlayerId = player.PlayerId,
            LocationId = player.LocationId,
        };
        public static PlayerLoot Map(PlayerLootModel player) => new PlayerLoot
        {
            PlayerLootId = player.PlayerLootId,
            PlayerId = player.PlayerId,
            LootId = player.LootId,
            Quantity = player.Quantity,
        };
        public static PlayerLootModel Map(PlayerLoot player) => new PlayerLootModel
        {
            PlayerLootId = player.PlayerLootId,
            PlayerId = player.PlayerId,
            LootId = player.LootId,
            Quantity = player.Quantity,
        };
        public static RecipeLoot Map(RecipeLootModel recipe) => new RecipeLoot
        {
            RecipeLootId = recipe.RecipeLootId,
            RecipeId = recipe.RecipeId,
            LootId = recipe.LootId,
        };
        public static RecipeLootModel Map(RecipeLoot recipe) => new RecipeLootModel
        {
            RecipeLootId = recipe.RecipeLootId,
            RecipeId = recipe.RecipeId,
            LootId = recipe.LootId,
        };
        public static StoreEquipment Map(StoreEquipmentModel store) => new StoreEquipment
        {
            StoreEquipmentId = store.StoreEquipmentId,
            StoreId = store.StoreId,
            EquipmentId = store.EquipmentId,
        };
        public static StoreEquipmentModel Map(StoreEquipment store) => new StoreEquipmentModel
        {
            StoreEquipmentId = store.StoreEquipmentId,
            StoreId = store.StoreId,
            EquipmentId = store.EquipmentId,
        };
        public static StoreFlavor Map(StoreFlavorModel store) => new StoreFlavor
        {
            StoreFlavorId = store.StoreFlavorId,
            StoreId = store.StoreId,
            FlavorId = store.FlavorId,
            Bonus = store.Bonus,
        };
        public static StoreFlavorModel Map(StoreFlavor store) => new StoreFlavorModel
        {
            StoreFlavorId = store.StoreFlavorId,
            StoreId = store.StoreId,
            FlavorId = store.FlavorId,
            Bonus = store.Bonus,
        };
        public static IEnumerable<Store> Map(IEnumerable<StoreModel> stores) => stores.Select(Map);
        public static IEnumerable<StoreModel> Map(IEnumerable<Store> stores) => stores.Select(Map);
        public static IEnumerable<Recipe> Map(IEnumerable<RecipeModel> recipes) => recipes.Select(Map);
        public static IEnumerable<RecipeModel> Map(IEnumerable<Recipe> recipes) => recipes.Select(Map);
        public static IEnumerable<Player> Map(IEnumerable<PlayerModel> players) => players.Select(Map);
        public static IEnumerable<PlayerModel> Map(IEnumerable<Player> players) => players.Select(Map);
        public static IEnumerable<Loot> Map(IEnumerable<LootModel> loots) => loots.Select(Map);
        public static IEnumerable<LootModel> Map(IEnumerable<Loot> loots) => loots.Select(Map);
        public static IEnumerable<Account> Map(IEnumerable<AccountModel> accounts) => accounts.Select(Map);
        public static IEnumerable<AccountModel> Map(IEnumerable<Account> accounts) => accounts.Select(Map);
        public static IEnumerable<Equipment> Map(IEnumerable<EquipmentModel> equipment) => equipment.Select(Map);
        public static IEnumerable<EquipmentModel> Map(IEnumerable<Equipment> equipment) => equipment.Select(Map);
        public static IEnumerable<Flavor> Map(IEnumerable<FlavorModel> flavors) => flavors.Select(Map);
        public static IEnumerable<FlavorModel> Map(IEnumerable<Flavor> flavors) => flavors.Select(Map);
        public static IEnumerable<Location> Map(IEnumerable<LocationModel> locationModels) => locationModels.Select(Map);
        public static IEnumerable<LocationModel> Map(IEnumerable<Location> locations) => locations.Select(Map);
        public static IEnumerable<FlavorLootModel> Map(IEnumerable<FlavorLoot> flavorLoots) => flavorLoots.Select(Map);
        public static IEnumerable<FlavorLoot> Map(IEnumerable<FlavorLootModel> flavorLootModels) => flavorLootModels.Select(Map);
        public static IEnumerable<LocationLoot> Map(IEnumerable<LocationLootModel> locationLootModels) => locationLootModels.Select(Map);
        public static IEnumerable<LocationLootModel> Map(IEnumerable<LocationLoot> locationLoots) => locationLoots.Select(Map);
        public static IEnumerable<PlayerEquipment> Map(IEnumerable<PlayerEquipmentModel> players) => players.Select(Map);
        public static IEnumerable<PlayerEquipmentModel> Map(IEnumerable<PlayerEquipment> players) => players.Select(Map);
        public static IEnumerable<PlayerLocation> Map(IEnumerable<PlayerLocationModel> players) => players.Select(Map);
        public static IEnumerable<PlayerLocationModel> Map(IEnumerable<PlayerLocation> players) => players.Select(Map);
        public static IEnumerable<PlayerLoot> Map(IEnumerable<PlayerLootModel> players) => players.Select(Map);
        public static IEnumerable<PlayerLootModel> Map(IEnumerable<PlayerLoot> players) => players.Select(Map);
        public static IEnumerable<RecipeLoot> Map(IEnumerable<RecipeLootModel> recipes) => recipes.Select(Map);
        public static IEnumerable<RecipeLootModel> Map(IEnumerable<RecipeLoot> recipes) => recipes.Select(Map);
        public static IEnumerable<StoreEquipment> Map(IEnumerable<StoreEquipmentModel> stores) => stores.Select(Map);
        public static IEnumerable<StoreEquipmentModel> Map(IEnumerable<StoreEquipment> stores) => stores.Select(Map);
        public static IEnumerable<StoreFlavor> Map(IEnumerable<StoreFlavorModel> stores) => stores.Select(Map);
        public static IEnumerable<StoreFlavorModel> Map(IEnumerable<StoreFlavor> stores) => stores.Select(Map);
    }
}
