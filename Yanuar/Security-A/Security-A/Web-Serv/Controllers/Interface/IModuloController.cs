using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interface
{
    public interface IModuloController
    {
        Task<ActionResult<IEnumerable<ModuloDto>>> GetAll();
        Task<ActionResult<ModuloDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();



    }
}
