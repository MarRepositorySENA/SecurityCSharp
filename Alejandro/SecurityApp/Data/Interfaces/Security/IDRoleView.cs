using Entity.Dao;
using Entity.Dto;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Security
{
    public interface IDRoleView
    {
        Task Delete(int id);
        Task<IEnumerable<Role_viewDto>> GetAllSelect();
        Task<RoleView> GetById(int id);
        Task<RoleView> Save(RoleView entity);
        Task Update(RoleView entity);
        Task<RoleView> GetByCode(int code);
        Task<MenuDto> Menu(int id);
    }
}
