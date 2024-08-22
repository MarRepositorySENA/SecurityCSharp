using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces.Security
{
    public interface IControllerRole
    {
        Task<ActionResult<IEnumerable<RoleDto>>> GetAllSelect();
        Task<ActionResult<RoleDto>> GetById(int id);
        Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity);
        Task<IActionResult> Update(int id, [FromBody] RoleDto entity);
        Task<ActionResult> Delete(int id);
    }
}
