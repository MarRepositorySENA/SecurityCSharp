using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces.Security
{
    public interface IControllerUserRol
    {
        Task<ActionResult<IEnumerable<UserRoleDto>>> GetAllSelect();
        Task<ActionResult<UserRoleDto>> GetById(int id);
        Task<ActionResult<UserRoleDto>> Save([FromBody] UserRoleDto entity);
        Task<IActionResult> Update(int id, [FromBody] UserRoleDto entity);
        Task<ActionResult> Delete(int id);
    }
}
