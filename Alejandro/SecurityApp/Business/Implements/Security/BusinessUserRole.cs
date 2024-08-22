using Business.Interfaces.Security;
using Data.Implemenst;
using Data.Interfaces.Security;
using Entity.Dao;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Business.Service.Security
{
    public class BusinessUserRole : IUserRoleBusiness
    {
        private readonly IDUserRol _dUserRole;

        public BusinessUserRole(IDUserRol userRol)
        {
            _dUserRole = userRol;
        }
        public async Task Delete(int id)
        {
            await _dUserRole.Delete(id);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAllSelect()
        {
            return await _dUserRole.GetAllSelect();
        }

        public async Task<UserRoleDto> GetById(int id)
        {
            UserRole userRole = await _dUserRole.GetById(id);
            UserRoleDto userRoleDto = new UserRoleDto();

            userRoleDto.Id = userRole.Id;
            userRoleDto.RoleId = userRole.RoleId;
            userRoleDto.UserId = userRole.UserId;
            userRoleDto.created_at = userRole.created_at;
            userRoleDto.state = userRole.state;

            return userRoleDto;
        }
        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userRole = new UserRole();
            userRole = mapearDatos(userRole, entity);

            return await _dUserRole.Save(userRole);
        }

        public async Task Update(int id, UserRoleDto entity)
        {
            UserRole user_Role = await _dUserRole.GetById(id);
            if (user_Role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user_Role = mapearDatos(user_Role, entity);
            await _dUserRole.Update(user_Role);
        }

        private UserRole mapearDatos(UserRole user_Role, UserRoleDto entity)
        {
            user_Role.Id = entity.Id;
            user_Role.RoleId = entity.RoleId;
            user_Role.UserId = entity.UserId;
            user_Role.created_at = entity.created_at;
            user_Role.state = entity.state;

            return user_Role;
        }
    }
}
