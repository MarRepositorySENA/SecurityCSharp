using Business.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interface;

namespace Web_Serv.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase, IRoleController
    {
        private readonly IRoleBusiness _roleBusiness;

        public RoleController(IRoleBusiness roleBusiness)
        {
            _roleBusiness = roleBusiness;
        }

        [HttpGet("/Role")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var result = await _roleBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("Role/{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            var result = await _roleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Role/select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _roleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost("/Role")]
        public async Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _roleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("/Role")]
        public async Task<IActionResult> Update( [FromBody] RoleDto entity)
        {
            if (entity == null ||  entity.Id == 0)
            {
                return BadRequest();
            }
            await _roleBusiness.Update( entity);
            return NoContent();
        }

        [HttpDelete("Role/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleBusiness.Delete(id);
            return NoContent();
        }

        
    }
}
