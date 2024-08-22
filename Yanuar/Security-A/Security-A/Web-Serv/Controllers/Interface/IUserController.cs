using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interface
{
    public interface IUserController
    {
        Task<ActionResult<IEnumerable<UserDto>>> GetAll();

        Task<ActionResult<UserDto>> GetById(int id);

        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();

        Task<ActionResult<UserDto>> Save([FromBody] UserDto entity);

        Task<IActionResult> Update([FromBody] UserDto entity);

        Task<IActionResult> Delete(int id);
    }
}
