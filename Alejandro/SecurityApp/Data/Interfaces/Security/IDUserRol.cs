using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IDUserRol
    {
        Task Delete(int id);
        
        Task<IEnumerable<UserRoleDto>> GetAllSelect();
        Task<UserRole> GetById(int id);
        Task<UserRole> Save(UserRole entity);
        Task Update(UserRole entity);
        Task<UserRole> GetByCode(int code);
    }
}
