using Business.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Implements
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserData data;

        public UserBusiness(IUserData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<UserDto> GetById(int id)
        {
            User user = await this.data.GetById(id);
            UserDto UserDto = new UserDto();

            UserDto.Id = user.Id;
            UserDto.Username = user.Username;
            UserDto.Password = user.Password;
            UserDto.Person_id = user.Person_id;
            UserDto.State = user.State;
            return UserDto;
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user = this.mapearDatos(user, entity);

            return await this.data.Save(user);
        }

        public async Task Update( UserDto entity)
        {
            User user = await this.data.GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.mapearDatos(user,entity);

            await this.data.Update(user);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<User> users = await this.data.GetAll();
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Person_id = user.Person_id,
                State = user.State
            });

            return userDtos;
        }

        public User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.Person_id = entity.Person_id;
            user.State = entity.State;
            return user;
        }

    }
}
