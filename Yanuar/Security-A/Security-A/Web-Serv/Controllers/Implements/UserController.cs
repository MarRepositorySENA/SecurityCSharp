using Business.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interface;

namespace Web_Serv.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness= userBusiness;
        }

        [HttpGet("/User")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var result = await _userBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var result = await _userBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("User/select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _userBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost("/User")]
        public async Task<ActionResult<UserDto>> Save([FromBody] UserDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _userBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("/User")]
        public async Task<IActionResult> Update( [FromBody] UserDto entity)
        {
            if (entity == null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _userBusiness.Update(entity);
            return NoContent();
        }

        [HttpDelete("User/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userBusiness.Delete(id);
            return NoContent();
        }
    }
}
