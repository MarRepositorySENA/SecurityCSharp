using Data.Interfaces;
using Entity.Dto;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Security
{
    public interface IRoleViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<Role_viewDto>> GetAllSelect();
        Task<Role_viewDto> GetById(int id);
        Task<RoleView> Save(Role_viewDto entity);
        Task Update(int id, Role_viewDto entity);
        Task<MenuDto> Menu(int id);
    }
}
