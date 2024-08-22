using Business.Interfaces.Security;
using Data.Implemenst;
using Data.Interfaces.Security;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Business.Service.Security
{
    public class BusinessRole : IRoleBusiness
    {
        private readonly IDRole _role;

        public BusinessRole(IDRole role)
        {
            _role = role;
        }
        public async Task Delete(int id)
        {
            await _role.Delete(id);
        }

        public async Task<IEnumerable<RoleDto>> GetAllSelect()
        {
            return await _role.GetAllSelect();
        }

        public async Task<RoleDto> GetById(int id)
        {
            Role role = await _role.GetById(id);
            RoleDto roleDto = new RoleDto();

            roleDto.Name = role.Name;
            roleDto.Description = role.Description;
            roleDto.create_at = role.created_at;
            roleDto.state = role.state;

            return roleDto;
        }

        public async Task<Role> Save(RoleDto entity)
        {
            Role role = new Role();
            role = mapearDatos(role, entity);

            return await _role.Save(role);
        }

        public async Task Update(int id, RoleDto entity)
        {
            Role role = await _role.GetById(id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role = mapearDatos(role, entity);
            await _role.Update(role);
        }

        private Role mapearDatos(Role role, RoleDto entity)
        {
            role.Name = entity.Name;
            role.Description = entity.Description;
            role.created_at = entity.create_at;
            role.state = entity.state;

            return role;
        }
    }
}
