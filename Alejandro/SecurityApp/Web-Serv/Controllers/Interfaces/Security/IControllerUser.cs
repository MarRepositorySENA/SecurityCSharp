using Data.Interfaces;
using Entity.Dto;
using Entity.Dto.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces.Security
{
    public interface IControllerUser
    {
        Task<ActionResult<IEnumerable<UserDto>>> GetAllSelect();
        Task<ActionResult<UserDto>> GetById(int id);
        Task<ActionResult<UserDto>> Save([FromBody] UserDto entity);
        Task<IActionResult> Update(int id, [FromBody] UserDto entity);
        Task<ActionResult> Delete(int id);
        Task<ActionResult> Login([FromBody] LoginDto loginDto);
    }
}
