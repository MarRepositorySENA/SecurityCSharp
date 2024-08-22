using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.SecurityDto;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Security
{
    public class DRoleView : IDRoleView
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DRoleView(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.RoleView.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Role_viewDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Roleview 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<Role_viewDto>(sql);
        }
        public async Task<RoleView> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Roleview WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<RoleView>(sql, new { Id = id });
        }
        public async Task<RoleView> Save(RoleView entity)
        {
            DbContext.RoleView.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(RoleView entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<RoleView> GetByCode(int code)
        {
            return await DbContext.RoleView.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

        public async Task<MenuDto> Menu(int id)
        {
            var sql = @"SELECT 
                v.name AS ViewName, 
                m.name AS ModuleName, 
                v.id AS viewId,
                m.id AS moduleId
                FROM dbo.RoleView AS rv
                INNER JOIN dbo.[Views] AS v ON v.id = rv.ViewId
                INNER JOIN dbo.[Modules] AS m ON m.id = v.moduleId
                WHERE rv.id = @Id;";

            // Ejecutar la consulta y mapear los resultados a MenuDto
            return await DbContext.QueryFirstOrDefaultAsync<MenuDto>(sql, new { Id = id });
        }

    }
}
