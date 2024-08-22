using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interface
{
    public interface IRoleController
    {


        Task<ActionResult<IEnumerable<RoleDto>>> GetAll();

        Task<ActionResult<RoleDto>> GetById(int id);

        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();

        Task<ActionResult<RoleDto>> Save([FromBody] RoleDto entity);

        Task<IActionResult> Update( [FromBody] RoleDto entity);

        Task<IActionResult> Delete(int id);
    }
}
