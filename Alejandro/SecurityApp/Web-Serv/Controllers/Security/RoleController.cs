using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Business.Interfaces.Security;
using Web_Serv.Controllers.Interfaces.Security;
using Entity.Dto.SecurityDto;

namespace Web_Serv.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase, IControllerRole
    {
        private readonly IRoleBusiness _roleBusiness;

        public RoleController(IRoleBusiness roleBusiness)
        {
            _roleBusiness = roleBusiness;
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllSelect()
        {
            var result = await _roleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            var result = await _roleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _roleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _roleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _roleBusiness.Delete(id);
            return NoContent();
        }
    }
}
