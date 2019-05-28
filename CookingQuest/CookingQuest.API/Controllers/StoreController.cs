using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingQuest.Data.Entities;
using CookingQuest.Data.Repository;
using CookingQuest.Library.Models.Library;
using Microsoft.AspNetCore.Mvc;

namespace CookingQuest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreRepo _repo;
        public StoreController(StoreRepo repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET api/values
        [HttpGet]
        public IEnumerable<StoreModel> Get() => _repo.GetAll();
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<StoreModel> Get(int id)
        {
            if(_repo.Get(id) is StoreModel store)
            {
                return store;
            }
            return NotFound(); // 404 Not Found
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] StoreModel store)
        {
            int id;
            try
            {
                id = _repo.Create(store);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtRoute("Get", new { Id = id }, Get(id));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StoreModel store)
        {
            if(Get(id) is null)
            {
                return NotFound(); // 404 Not Found
            }
            store.StoreId = id;
            try
            {
                var success = _repo.Update(store);
                if (!success)
                {
                    return BadRequest("Invalid request"); // 400 Bad Request
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
        public IActionResult Delete(int id)
        {
            var success = _repo.Delete(id);
            if (!success)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 204 No Content
        }
    }
}
