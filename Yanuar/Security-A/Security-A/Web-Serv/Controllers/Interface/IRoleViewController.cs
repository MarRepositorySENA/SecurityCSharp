using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interface
{
    public interface IRoleViewController
    {
        Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();

        Task<ActionResult<RoleViewDto>> GetById(int id);

        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();

        Task<ActionResult<RoleViewDto>> Save([FromBody] RoleViewDto entity);

        Task<IActionResult> Update([FromBody] RoleViewDto entity);

        Task<IActionResult> Delete(int id);
    }
}
