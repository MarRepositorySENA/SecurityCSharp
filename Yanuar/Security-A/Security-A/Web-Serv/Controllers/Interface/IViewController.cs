using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interface
{
    public interface IViewController
    {
        Task<ActionResult<IEnumerable<ViewDto>>> GetAll();

        Task<ActionResult<ViewDto>> GetById(int id);

        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();

        Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity);

        Task<IActionResult> Update([FromBody] ViewDto entity);

        Task<IActionResult> Delete(int id);
    }
}
