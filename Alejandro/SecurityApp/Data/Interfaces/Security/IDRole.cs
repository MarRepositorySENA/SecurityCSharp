using Entity.Dto.SecurityDto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Security
{
    public interface IDRole
    {
        Task Delete(int id);
        Task<IEnumerable<RoleDto>> GetAllSelect();
        Task<Role> GetById(int id);
        Task<Role> Save(Role entity);
        Task Update(Role entity);
        Task<Role> GetByCode(int code);

    }
}
