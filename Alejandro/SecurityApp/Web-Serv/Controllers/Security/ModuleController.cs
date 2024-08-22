using Business.Interfaces.Security;
using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interfaces.Security;

namespace Web_Serv.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModuleController : ControllerBase, IControllerModule
    {
        private readonly IModuleBusiness _moduleBusiness;

        public ModuleController(IModuleBusiness moduleBusiness)
        {
            _moduleBusiness = moduleBusiness;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAll()
        //{
        //    var result = await _moduleBusiness.GetAll();
        //    return Ok(result);
        //}

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAllSelect()
        {
            var result = await _moduleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> GetById(int id)
        {
            var result = await _moduleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _moduleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModuleDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _moduleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _moduleBusiness.Delete(id);
            return NoContent();
        }
    }
}
