using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingQuest.Data.Repository;
using CookingQuest.Library.IRepository;
using CookingQuest.Library.Models.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CookingQuest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public IPlayerRepo PlayerRepo { get; set; }
        public PlayerController(IPlayerRepo PlayerRepo)
        {
            this.PlayerRepo = PlayerRepo ?? throw new ArgumentNullException(nameof(PlayerRepo));
        }

        // GET: api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerModel>>> Get()
        {
            var players = await PlayerRepo.GetAllPlayers();

            if (players == null)
            {
                return NotFound();
            }

            _logger.Info($"Returning {players.Count()} players");

            return Ok(players);
        }

        // GET: api/Player/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<PlayerModel>> Get(int id)
        {
            if(await PlayerRepo.GetPlayerById(id) is PlayerModel playerModel)
            {
                _logger.Info($"Returning {playerModel.Name}");
                return playerModel;
            }

            return NotFound();
        }

        // GET: api/Player/{Email}
        [HttpGet("[action]/{email}")]
        public async Task<ActionResult<PlayerModel>> Account(string email)
        {
            var player = await PlayerRepo.GetPlayerByEmail(email);

            if (player == null)
            {
                return NotFound();
            }
            _logger.Info($"Returning {player.PlayerId}");
            return Ok(player);
        }

        // GET: api/Player/Equipment/{PlayerId}
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<PlayerModel>>> Equipment(int id)
        {
            var playerEquip = await PlayerRepo.GetPlayerEquipment(id);

            if(playerEquip == null)
            {
                return NotFound();
            }
            _logger.Info($"Returning {playerEquip.Count()} equipment from player {id}");
            return Ok(playerEquip);
        }
        // GET: api/Player/Equipment/{PlayerId}
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult> Equipment(int id, EquipmentModel equipmentModel)
        {
            var equipment = await PlayerRepo.EditPlayerEquipment(equipmentModel);

            if (equipment == false)
            {
                return NotFound();
            }
            _logger.Info($"Updated {equipmentModel.Name} for player {id}");
            return NoContent();
        }
        // DELETE: api/Player/loot/Delete/{playerid}
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> DeleteEquipment(int id)
        {
            if (await PlayerRepo.DeletePlayerEquipment(id))
            {
                _logger.Info($"Deleted Player Equipment of player: {id}");
                return NoContent();
            }
            return NotFound();
        }
        // GET: api/Player/Equipment/{PlayerId}
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult> PostEquipment(int id, EquipmentModel equipmentModel)
        {
            var equipment = await PlayerRepo.AddPlayerEquipment(equipmentModel, id);

            if (equipment == false)
            {
                return NotFound();
            }
            _logger.Info($"Added {equipmentModel.Name} for player {id}");
            return NoContent();

        }



        // GET: api/Player/Locations/{PlayerId}
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<LocationModel>>> Locations(int id)
        {
            var locations = await PlayerRepo.GetUnlockedLocations(id);

            if (locations == null)
            {
                return NotFound();
            }
            _logger.Info($"Returning {locations.Count()} for player {id}");
            return Ok(locations);
        }

        // GET: api/Player/Loot/{PlayerId}
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<LootModel>>> Loot(int id)
        {
            var loot = await PlayerRepo.GetLoot(id);

            if (loot == null)
            {
                return NotFound();
            }
            _logger.Info($"Returning {loot.Count()} for player {id}");
            return Ok(loot);
        }
        // Post: api/Player/Loot/{PlayerId}
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult> Loot(int id, LootModel lootModel)
        {
            var loot = await PlayerRepo.EditPlayerLoot(lootModel);

            if (loot == false)
            {
                return NotFound();
            }
            _logger.Info($"Updated {lootModel.Name} for player {id}");
            return NoContent();
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult> NewLoot(int id, LootModel lootModel)
        {
            var loot = await PlayerRepo.AddPlayerLoot(lootModel, id);

            if (loot == false)
            {
                return NotFound();
            }
            _logger.Info($"Updated {lootModel.Name} for player {id}");
            return NoContent();
        }
        // DELETE: api/Player/loot/Delete/{playerid}
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> DeleteLoot(int id)
        {
            if (await PlayerRepo.DeletePlayerLoot(id))
            {
                _logger.Info($"Deleted Player Loot of player: {id}");
                return NoContent();
            }
            return NotFound();
        }

        // PUT: api/Player/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PlayerModel player)
        {
            if (id == player.PlayerId && !(await PlayerRepo.GetPlayerById(id) is null))
            {
                if(await PlayerRepo.EditPlayer(player))
                {
                    _logger.Info($"Edited Player {id}");
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
