using Business.Interfaces.Security;
using Data.Implemenst;
using Data.Interfaces.Security;
using Entity.Dao;
using Entity.Dto;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Business.Service.Security
{
    public class BusinessRoleView : IRoleViewBusiness
    {
        private readonly IDRoleView _dRoleView;

        public BusinessRoleView(IDRoleView role_View)
        {
            _dRoleView = role_View;
        }
        public async Task Delete(int id)
        {
            await _dRoleView.Delete(id);
        }

        public async Task<IEnumerable<Role_viewDto>> GetAllSelect()
        {
            return await _dRoleView.GetAllSelect();
        }

        public async Task<Role_viewDto> GetById(int id)
        {
            RoleView role_View = await _dRoleView.GetById(id);
            Role_viewDto role_ViewDto = new Role_viewDto();

            role_ViewDto.Id = role_View.Id;
            role_ViewDto.RoleId = role_View.RoleId;
            role_ViewDto.ViewId = role_View.ViewId;
            role_ViewDto.state = role_View.state;

            return role_ViewDto;
        }

        public async Task<RoleView> Save(Role_viewDto entity)
        {
            RoleView role_View = new RoleView();
            role_View = mapearDatos(role_View, entity);

            return await _dRoleView.Save(role_View);
        }

        public async Task Update(int id, Role_viewDto entity)
        {
            RoleView role_View = await _dRoleView.GetById(id);
            if (role_View == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role_View = mapearDatos(role_View, entity);
            await _dRoleView.Update(role_View);
        }

        private RoleView mapearDatos(RoleView role_View, Role_viewDto entity)
        {
            role_View.Id = entity.Id;
            role_View.RoleId = entity.RoleId;
            role_View.ViewId = entity.ViewId;
            role_View.state = entity.state;

            return role_View;
        }
        public async Task<MenuDto> Menu(int id)
        {
            return await _dRoleView.Menu(id);
        }
    }
}
