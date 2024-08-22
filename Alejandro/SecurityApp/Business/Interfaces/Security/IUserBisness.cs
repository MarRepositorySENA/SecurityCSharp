using Data.Interfaces;
using Entity.Dao;
using Entity.Dto;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Business.Interfaces.Security
{
    public interface IUserBisness
    {
        Task Delete(int id);
        Task<IEnumerable<UserDto>> GetAllSelect();
        Task<UserDto> GetById(int id);
        Task<User> Save(UserDto entity);
        Task Update(int id, UserDto entity);
        //Task<LoginDao> Login(string username, string password);
        Task<(LoginDao loginDao, MenuDto menuDto)> Login(string username, string password);

    }

}
