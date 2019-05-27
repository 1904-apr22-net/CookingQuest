using CookingQuest.Data.Entities;
using CookingQuest.Data.Repository;
using CookingQuest.Library.Models.Library;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CookingQuest.Tests
{
    public class PlayerTests
    {
               [Fact]
        public async Task PlayerRepo()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<CookingQuestContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new CookingQuestContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new CookingQuestContext(options))
                {
                    context.Player.Add(new Player
                    {
                        Gold = 10,
                        Name = "Test",
                        PlayerId = 1,
                    });
                    context.SaveChanges();
                    context.Account.Add(new Account
                    {
                        AccountId = 1,
                        IsAdmin = true,
                        Password = "Easy",
                        PlayerId = 1,
                        Username = "paul",
                    });
                    context.SaveChanges();
                    context.Equipment.Add(new Equipment
                    {
                        Difficulty = 8,
                        EquipmentId = 1,
                        Modifier = 5,
                        Name = "TestE",
                        Price = 45,
                        Type = "Dungeon",
                    });
                    context.SaveChanges();
                    context.PlayerEquipment.Add(new PlayerEquipment
                    {
                        EquipmentId = 1,
                        PlayerId = 1,
                        PlayerEquipmentId = 1,
                    });
                    context.SaveChanges();
                    context.Location.Add(new Location
                    {
                        Description = "Testl",
                        Difficulty = 1,
                        LocationId = 1,
                        Name = "TestNl",
                    });
                    context.SaveChanges();
                    context.Loot.Add(new Loot
                    {
                        Description = "a",
                        LootId = 1,
                        Name = "l",
                        Price = 44,
                    });
                    context.SaveChanges();
                    context.PlayerLoot.Add(new PlayerLoot {
                        LootId = 1,
                        PlayerId = 1,
                        PlayerLootId = 1,
                    });
                    context.SaveChanges();
                    var testRepo = new PlayerRepo(context);
                    var players = await testRepo.GetAllPlayers();
                    var player = await testRepo.GetPlayerById(1);
                    var playerEmail = await testRepo.GetPlayerByEmail("paul");
                    var playerEqp = await testRepo.GetPlayerEquipment(1);
                    var locationUnl = await testRepo.GetUnlockedLocations(1);
                    var loot = await testRepo.GetLoot(1);
                    var editP = await testRepo.EditPlayer(player);
                    var editPLoot = await testRepo.EditPlayerLoot(loot.ElementAt(0));
                    var editPEqp = await testRepo.EditPlayerEquipment(playerEqp.ElementAt(0));
                    var deletePQqp = await testRepo.DeletePlayerEquipment(playerEqp.ElementAt(0).PlayerEquipmentId);
                    var deletPLoot = await testRepo.DeletePlayerLoot(loot.ElementAt(0).PlayerLootId);

                    Assert.NotEmpty(players);
                    Assert.NotNull(player);
                    Assert.Equal("Test", player.Name);
                    Assert.NotNull(playerEmail);
                    Assert.NotEmpty(playerEqp);
                    Assert.NotEmpty(locationUnl);
                    Assert.NotEmpty(loot);
                    Assert.True(editP);
                    Assert.True(editPLoot);
                    Assert.True(editPEqp);
                    Assert.True(deletePQqp);
                    Assert.True(deletPLoot);
                    testRepo.Dispose();
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
