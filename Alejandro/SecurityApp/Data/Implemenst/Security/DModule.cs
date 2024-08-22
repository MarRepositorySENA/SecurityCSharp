using Data.Interfaces.Security;
using Entity.Dto.SecurityDto;
using Entity.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Security
{
    public class DModule : IDModule
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DModule(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Modules.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ModuleDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Modules 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<ModuleDto>(sql);
        }

        public async Task<Entity.Model.Security.Module> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Modules WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<Entity.Model.Security.Module>(sql, new { Id = id });
        }

        public async Task<Entity.Model.Security.Module> Save(Entity.Model.Security.Module entity)
        {
            DbContext.Modules.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Entity.Model.Security.Module entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task<Entity.Model.Security.Module> GetByCode(int code)
        {
            return await DbContext.Modules.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

    }
}
