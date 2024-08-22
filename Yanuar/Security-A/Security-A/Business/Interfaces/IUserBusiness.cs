using Entity.Dto;
using Entity.Model.Security;


namespace Business.Interfaces
{
    public interface IUserBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<UserDto> GetById(int id);
        Task<User> Save(UserDto entity);
        Task Update( UserDto entity);
        User mapearDatos(User user,UserDto entity);
        Task<IEnumerable<UserDto>> GetAll();
    }
}
