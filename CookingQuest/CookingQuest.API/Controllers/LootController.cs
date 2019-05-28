using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingQuest.Library.IRepository;
using CookingQuest.Library.Models.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CookingQuest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LootController : ControllerBase
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public ILootRepo lootRepo { get; set; }
        public LootController(ILootRepo lootRepo)
        {
            this.lootRepo = lootRepo ?? throw new ArgumentNullException(nameof(lootRepo));
        }

        // GET: api/Loot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LootModel>>> GetLoots()
        {
            var loot = await lootRepo.GetAllLoot();

            if (loot == null)
            {
                return NotFound();
            }

            _logger.Info($"Returning {loot.Count()} Loot");

            return Ok(loot);
        }

        // GET: api/Loot/5
        [HttpGet("{id}", Name = "GetLoots")]
        public async Task<ActionResult<LootModel>> GetLoots(int id)
        {
            if (await lootRepo.GetLootById(id) is LootModel lootModel)
            {
                _logger.Info($"Returning {lootModel.Name}");
                return lootModel;
            }

            return NotFound();
        }

        // POST: api/Loot
        [HttpPost]
        public async Task<IActionResult> PostLoots([FromBody] LootModel lootModel)
        {
            int id;
            try
            {
                id = await lootRepo.AddLoot(lootModel);
                _logger.Info($"Adding new Loot at {id}");
                return CreatedAtRoute("GetLoots", new { Id = id }, GetLoots(id)); // 201 Created
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Loot/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutLoots(int id, [FromBody] LootModel lootModel)
        {
            if (id == lootModel.LootId && !(await lootRepo.GetLootById(id) is null))
            {
                if (await lootRepo.EditLoot(lootModel))
                {
                    _logger.Info($"Edited Loot {id}");
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

        // DELETE: api/Loot/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoots(int id)
        {
            if (await lootRepo.DeleteLoot(id))
            {
                _logger.Info($"Deleted Loot {id}");
                return NoContent();
            }
            return NotFound();
        }
    }
}
