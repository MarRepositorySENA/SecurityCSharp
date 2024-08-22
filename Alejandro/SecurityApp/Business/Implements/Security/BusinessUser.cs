using Business.Interfaces.Security;
using Data.Implemenst;
using Data.Interfaces.Security;
using Entity.Dao;
using Entity.Dto;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Business.Service.Security
{
    public class BusinessUser : IUserBisness
    {
        private readonly IDUser _dUser;
        private readonly IDRoleView _dRoleView;

        public BusinessUser(IDUser dUser, IDRoleView dRoleView)
        {
            _dUser = dUser;
            _dRoleView = dRoleView;
        }
        public async Task Delete(int id)
        {
            await _dUser.Delete(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllSelect()
        {
            return await _dUser.GetAllSelect();
        }

        public async Task<UserDto> GetById(int id)
        {
            User user = await _dUser.GetById(id);
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.UserName = user.UserName;
            userDto.passsword = user.passsword;
            userDto.PersonId = user.PersonId;
            userDto.state = user.state;

            return userDto;
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user = mapearDatos(user, entity);

            return await _dUser.Save(user);
        }

        public async Task Update(int id, UserDto entity)
        {
            User user = await _dUser.GetById(id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = mapearDatos(user, entity);
            await _dUser.Update(user);
        }

        public async Task<(LoginDao loginDao, MenuDto menuDto)> Login(string username, string password)
        {
            LoginDto userl = await _dUser.Login(username, password);
            if (userl == null)
            {
                throw new Exception("Usuario o contraseña incorrectos");
            }

            LoginDao loginDao = new LoginDao
            {
                Id = userl.Id,
                RoleId = userl.RoleId
            };

            MenuDto menuDto = await _dRoleView.Menu(loginDao.RoleId);

            return (loginDao, menuDto);
        }

        private User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.UserName = entity.UserName;
            user.passsword = entity.passsword;
            user.PersonId = entity.PersonId;
            user.state = entity.state;

            return user;
        }

    }
}
