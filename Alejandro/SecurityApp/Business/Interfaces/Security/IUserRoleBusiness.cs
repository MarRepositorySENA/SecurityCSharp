using Data.Interfaces;
using Entity.Dao;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Security
{
    public interface IUserRoleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<UserRoleDto>> GetAllSelect();
        Task<UserRoleDto> GetById(int id);
        Task<UserRole> Save(UserRoleDto entity);
        Task Update(int id, UserRoleDto entity);
    }
}
