using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IUserData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<User> GetById(int id);
        Task<User> Save(User entity);
        Task Update(User entity);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByUsername(string username);
        Task<User> GetByPassword(string password);


    }
}
