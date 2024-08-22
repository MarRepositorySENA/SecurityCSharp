using Data.Interfaces.Location;
using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Context;
using Entity.Model.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Location
{
    public class DCountry : IDCountry
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration Configuration;

        public DCountry(AplicationDbContext dbContext, IConfiguration configuration)
        {
            DbContext = dbContext;
            this.Configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.delete_at = DateTime.Parse(DateTime.Today.ToString());
            DbContext.Countrys.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CountryDto>> GetAllSelect()
        {
            var sql = @"SELECT *
                        FROM dbo.[Countrys] 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<CountryDto>(sql);
        }

        public async Task<Country> GetByCode(int code)
        {
            return await DbContext.Countrys.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

        public async Task<Country> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Countrys WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });
        }

        public async Task<Country> Save(Country entity)
        {
            DbContext.Countrys.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Country entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
    }
}
