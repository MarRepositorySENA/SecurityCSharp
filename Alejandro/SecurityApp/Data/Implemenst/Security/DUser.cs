using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.SecurityDto;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Security
{
    public class DUser : IDUser
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DUser(AplicationDbContext context, IConfiguration configuration)
        {
            DbContext = context;
            this.configuration = configuration;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            DbContext.Users.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Users 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<UserDto>(sql);
        }
        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Users WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }
        public async Task<User> Save(User entity)
        {
            DbContext.Users.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(User entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<User> GetByCode(int code)
        {
            return await DbContext.Users.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

        public async Task<LoginDto> Login(string UserName, string passsword)
        {
            var sql = @"SELECT u.id, ur.RoleId
                        FROM dbo.Users AS u
                        INNER JOIN dbo.Userroles AS ur ON ur.UserId = u.id
                        WHERE u.UserName = @username
                        AND u.passsword = @password;";
            return await DbContext.QueryFirstOrDefaultAsync<LoginDto>(sql, new { username = UserName, password = passsword });
        }
    }
}
