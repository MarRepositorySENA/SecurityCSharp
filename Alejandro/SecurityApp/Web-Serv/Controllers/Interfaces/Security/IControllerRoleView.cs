using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces.Security
{
    public interface IControllerRoleView
    {
        Task<ActionResult<IEnumerable<Role_viewDto>>> GetAllSelect();
        Task<ActionResult<Role_viewDto>> GetById(int id);
        Task<ActionResult<Role_viewDto>> Save([FromBody] Role_viewDto entity);
        Task<IActionResult> Update(int id, [FromBody] Role_viewDto entity);
        Task<ActionResult> Delete(int id);
    }
}
