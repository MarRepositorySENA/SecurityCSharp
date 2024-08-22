using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Data.Interfaces.Security;
using Entity.Dto.SecurityDto;

namespace Data.Implemenst.Security
{
    public class DRole : IDRole
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DRole(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Role.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<RoleDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Role 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<RoleDto>(sql);
        }
        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Role WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }
        public async Task<Role> Save(Role entity)
        {
            DbContext.Role.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Role entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<Role> GetByCode(int code)
        {
            return await DbContext.Role.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

    }
}
