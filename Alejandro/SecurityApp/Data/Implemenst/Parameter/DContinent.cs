using Data.Interfaces.Location;
using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Context;
using Entity.Model.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Location
{
    public class DContinent : IDContinent
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DContinent(AplicationDbContext dbContext, IConfiguration configuration)
        {
            DbContext = dbContext;
            this.configuration = configuration;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.delete_at = DateTime.Parse(DateTime.Today.ToString());
            DbContext.Continents.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContinentDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.[Modules] 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<ContinentDto>(sql);
        }

        public async Task<Continent> GetByCode(int code)
        {
            return await DbContext.Continents.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

        public async Task<Continent> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Continents WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<Continent>(sql, new { Id = id });
        }

        public async Task<Continent> Save(Continent entity)
        {
            DbContext.Continents.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Continent entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
    }
}
