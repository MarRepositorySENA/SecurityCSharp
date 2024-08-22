using Entity.Dto.Location;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces.Location
{
    public interface IControllerCountry
    {
        Task<ActionResult<IEnumerable<CountryDto>>> GetAllSelect();
        Task<ActionResult<CountryDto>> GetById(int id);
        Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity);
        Task<IActionResult> Update(int id, [FromBody] CountryDto entity);
        Task<ActionResult> Delete(int id);
    }
}
