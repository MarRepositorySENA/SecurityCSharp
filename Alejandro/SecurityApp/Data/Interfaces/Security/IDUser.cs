using Entity.Dto;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IDUser
    {
        Task Delete(int id);
        Task<IEnumerable<UserDto>> GetAllSelect();
        Task<User> GetById(int id);
        Task<User> Save(User entity);
        Task Update(User entity);
        Task<User> GetByCode(int code);

        Task<LoginDto> Login(string UserName, string passsword);

    }
}
