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
        private static readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();

        public IPlayerRepo PlayerRepo { get; set; }
        public PlayerController(IPlayerRepo PlayerRepo)
        {
            this.PlayerRepo = PlayerRepo ?? throw new ArgumentNullException(nameof(PlayerRepo));
        }

        // GET: api/Player
        [HttpGet]
        public IEnumerable<PlayerModel> Get()
        {
            return PlayerRepo.GetAllPlayers();
        }

        // GET: api/Player/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<PlayerModel>> Get(int id)
        {
            if(await PlayerRepo.GetPlayerById(id) is PlayerModel playerModel)
            {
                return playerModel;
            }
            return NoContent();
        }

        // POST: api/Player
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Player/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
