using Data.Interfaces.Security;
using Entity.Dto.SecurityDto;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Security
{
    public class DUserRol : IDUserRol
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DUserRol(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Userroles.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserRoleDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Userroles 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<UserRoleDto>(sql);
        }
        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Userroles WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<UserRole>(sql, new { Id = id });
        }
        public async Task<UserRole> Save(UserRole entity)
        {
            DbContext.Userroles.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(UserRole entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<UserRole> GetByCode(int code)
        {
            return await DbContext.Userroles.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

        
    }
}
