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
    public class EquipmentController : ControllerBase
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public IEquipmentRepo equipmentRepo { get; set; }
        public EquipmentController(IEquipmentRepo equipmentRepo)
        {
            this.equipmentRepo = equipmentRepo ?? throw new ArgumentNullException(nameof(equipmentRepo));
        }

        // GET: api/Equipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentModel>>> GetEquip()
        {
            var equipment = await equipmentRepo.GetAllEquipment();

            if (equipment == null)
            {
                return NotFound();
            }

            _logger.Info($"Returning {equipment.Count()} equipment");

            return Ok(equipment);
        }

        // GET: api/Equipment/5
        [HttpGet("{id}", Name = "GetEquip")]
        public async Task<ActionResult<EquipmentModel>> GetEquip(int id)
        {
            if (await equipmentRepo.GetEquipmentById(id) is EquipmentModel equipmentModel)
            {
                _logger.Info($"Returning {equipmentModel.Name}");
                return equipmentModel;
            }

            return NotFound();
        }

        // POST: api/Equipment
        [HttpPost]
        public async Task<IActionResult> PostEquip([FromBody] EquipmentModel equipmentModel)
        {
            int id;
            try
            {
                id = await equipmentRepo.AddEquipment(equipmentModel);
                _logger.Info($"Adding new Equipment at {id}");
                return CreatedAtRoute("GetEquip", new { Id = id }, GetEquip(id)); // 201 Created
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Equipment/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEquip(int id, [FromBody] EquipmentModel equipmentModel)
        {
            if (id == equipmentModel.EquipmentId && !(await equipmentRepo.GetEquipmentById(id) is null))
            {
                if (await equipmentRepo.EditEquipment(equipmentModel))
                {
                    _logger.Info($"Edited Equipment {id}");
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

        // DELETE: api/Equipment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEquip(int id)
        {
            if (await equipmentRepo.DeleteEquipment(id))
            {
                _logger.Info($"Deleted Equipment {id}");
                return NoContent();
            }
            return NotFound();
        }
    }
}
