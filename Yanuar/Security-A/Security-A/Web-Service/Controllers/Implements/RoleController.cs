using Business.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_Service.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleBusiness _RoleBusiness;
        public RoleController(IRoleBusiness RoleBusiness)
        {
            _RoleBusiness = RoleBusiness;
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var result = await _RoleBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("Role/{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            var result = await _RoleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _RoleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost("Role/post")]
        public async Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _RoleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("Role/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _RoleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("Role/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RoleBusiness.Delete(id);
            return NoContent();
        }
    }
    }
