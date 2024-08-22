using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Entity.Dto;
using Entity.Dao;
using Business.Interfaces.Security;
using Web_Serv.Controllers.Interfaces.Security;
using Entity.Dto.SecurityDto;

namespace Web_Serv.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase, IControllerUser
    {
        private readonly IUserBisness _userBusiness;
        public UserController(IUserBisness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllSelect()
        {
            var result = await _userBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _userBusiness.Login(loginDto.UserName, loginDto.password);

                var response = new
                {
                    LoginDao = result.loginDao,
                    MenuDao = result.menuDto
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var result = await _userBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Save([FromBody] UserDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _userBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _userBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userBusiness.Delete(id);
            return NoContent();
        }
    }
}
