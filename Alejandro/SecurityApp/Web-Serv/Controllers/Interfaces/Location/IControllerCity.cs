using Entity.Dto.Location;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces.Location
{
    public interface IControllerCity
    {
        Task<ActionResult<IEnumerable<CityDto>>> GetAllSelect();
        Task<ActionResult<CityDto>> GetById(int id);
        Task<ActionResult<CityDto>> Save([FromBody] CityDto entity);
        Task<IActionResult> Update(int id, [FromBody] CityDto entity);
        Task<ActionResult> Delete(int id);
    }
}
