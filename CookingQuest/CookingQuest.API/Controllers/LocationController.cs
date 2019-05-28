using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingQuest.Data.Repository;
using CookingQuest.Library.IRepository;
using CookingQuest.Library.Models.Library;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CookingQuest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        // GET api/Location

<<<<<<< HEAD
        private ILocationRepo _repo;
=======
       
        public ILocationRepo _repo;
>>>>>>> master

        public LocationController(ILocationRepo repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationModel>>> Get()
        {
            var locations =  await _repo.GetAll();
            if (locations == null)
            {
                return NotFound();
            }
            _logger.Info($"Returning {locations.Count()} locations");
            return Ok(locations);
 

        }


        // GET api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationModel>> Get(int id)
        {
            try
            {

                if (await _repo.Get(id) is LocationModel location)
                {
                    _logger.Info($"Returning location {location.LocationId} ");
                    return Ok(location); // 200 OK
                }
                else
                {
                    return NotFound(); // 404 Not Found
                }
            }

            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Location/Loot/{LocationId}
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<LootModel>>> Loot(int id)
        {
            var loot = await _repo.GetLocationLoot(id);

            if (loot == null)
            {
                return NotFound();
            }
            _logger.Info($"Returning {loot.Count()} for location {id}");
            return Ok(loot);
        }

        // GET: api/Location/Quest/{LocationId}
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<LootModel>>> Quest(int id)
        {

            int LocationId = id;
            try
            {
                var success = await _repo.GetQuestLoot(LocationId);
                if (success==null)
                {
                    return NotFound(); // 400 Bad Request
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request
            }
            _logger.Info($"Returning quest loot {id}");
            return NoContent(); // 204 No Content
        }

        // POST api/Location
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationModel location)
        {
           

            int id;
            try
            {
                id = await _repo.Create(location);
                _logger.Info($"Adding new location at {id}");
                // there's also CreatedAtAction, same purpose
                return CreatedAtRoute("Get", new { Id = id }, Get(id)); // 201 Created
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LocationModel location)
        {
            if (Get(id) is null)
            {
                return NotFound(); // 404 Not Found
            }
            location.LocationId = id;
            try
            {
                var success = await _repo.Update(location);
                if (!success)
                {
                    return BadRequest("invalid request"); // 400 Bad Request
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request
            }
            _logger.Info($"Updated location at {id}");
            return NoContent(); // 204 No Content
        }


      

        // DELETE api/Location/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            _logger.Info($"Deleting location at {id}");
            if (!success)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 204 No Content
        }
    }
}
