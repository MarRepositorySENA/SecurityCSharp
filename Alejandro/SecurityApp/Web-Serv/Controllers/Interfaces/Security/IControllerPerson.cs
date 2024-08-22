using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces.Security
{
    public interface IControllerPerson
    {
        Task<ActionResult<IEnumerable<PersonDto>>> GetAllSelect();
        Task<ActionResult<PersonDto>> GetById(int id);
        Task<ActionResult<PersonDto>> Save([FromBody] PersonDto entity);
        Task<IActionResult> Update(int id, [FromBody] PersonDto entity);
        Task<ActionResult> Delete(int id);
    }
}
