using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IRoleViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<RoleViewDto> GetById(int id);
        Task<RoleView> Save(RoleViewDto entity);
        Task Update( RoleViewDto entity);
        RoleView mapearDatos(RoleView roleView, RoleViewDto entity);
        Task<IEnumerable<RoleViewDto>> GetAll();
    }
}
