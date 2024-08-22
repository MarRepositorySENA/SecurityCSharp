using Business.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interface;

namespace Web_Serv.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class UserRoleController : ControllerBase, IUserRoleController
    {
        private readonly IUserRoleBusiness _userRoleBusiness;

        public UserRoleController(IUserRoleBusiness userRoleBusiness)
        {
            _userRoleBusiness = userRoleBusiness;
        }

        [HttpGet("UserRole")]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll()
        {
            var result = await _userRoleBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("UserRole/{id}")]
        public async Task<ActionResult<UserRoleDto>> GetById(int id)
        {
            var result = await _userRoleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("UserRole/select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _userRoleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost("/RoleView")]
        public async Task<ActionResult<UserRoleDto>> Save([FromBody] UserRoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _userRoleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("/RoleView")]
        public async Task<IActionResult> Update([FromBody] UserRoleDto entity)
        {
            if (entity == null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _userRoleBusiness.Update(entity);
            return NoContent();
        }

        [HttpDelete("UserRole/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRoleBusiness.Delete(id);
            return NoContent();
        }

    }
}
