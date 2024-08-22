using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Business.Interfaces.Security;
using Web_Serv.Controllers.Interfaces.Security;
using Entity.Dto.SecurityDto;

namespace Web_Serv.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolController : ControllerBase, IControllerUserRol
    {
        private readonly IUserRoleBusiness _userRoleBusiness;
        public UserRolController(IUserRoleBusiness userRoleBusiness)
        {
            _userRoleBusiness = userRoleBusiness;
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAllSelect()
        {
            var result = await _userRoleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDto>> GetById(int id)
        {
            var result = await _userRoleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserRoleDto>> Save([FromBody] UserRoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _userRoleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserRoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _userRoleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userRoleBusiness.Delete(id);
            return NoContent();
        }
    }
}
