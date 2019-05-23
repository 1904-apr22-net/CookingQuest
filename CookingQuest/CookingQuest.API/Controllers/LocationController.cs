using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingQuest.Data.Repository;
using CookingQuest.Library.IRepository;
using CookingQuest.Library.Models.Library;
using Microsoft.AspNetCore.Mvc;

namespace CookingQuest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        // GET api/values

        public ILocationRepo _repo;

        public LocationController(ILocationRepo repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        [HttpGet]
        public async Task<IEnumerable<LocationModel>> Get() => await _repo.GetAll();


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationModel>> Get(int id)
        {
            try
            {

                if (await _repo.Get(id) is LocationModel location)
                {
                    return location; // 200 OK
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


    // POST api/values
    [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationModel location)
        {
           

            int id;
            try
            {
                id = await _repo.Create(location);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            // there's also CreatedAtAction, same purpose
            return CreatedAtRoute("Get", new { Id = id }, Get(id)); // 201 Created
        }

        // PUT api/values/5
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
            return NoContent(); // 204 No Content
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 204 No Content
        }
    }
}
