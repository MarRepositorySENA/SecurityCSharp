using Entity.Dto;
using Entity.Dto.Location;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces.Location
{
    public interface IControllerContinent
    {
        Task<ActionResult<IEnumerable<ContinentDto>>> GetAllSelect();
        Task<ActionResult<ContinentDto>> GetById(int id);
        Task<ActionResult<ContinentDto>> Save([FromBody] ContinentDto entity);
        Task<IActionResult> Update(int id, [FromBody] ContinentDto entity);
        Task<ActionResult> Delete(int id);
    }
}
