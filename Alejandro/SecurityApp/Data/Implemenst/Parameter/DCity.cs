using Data.Interfaces.Location;
using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Context;
using Entity.Model.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Location
{
    public class DCity : IDCity
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration Configuration;

        public DCity(AplicationDbContext dbContext, IConfiguration configuration)
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
            DbContext.Citys.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CityDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Citys 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<CityDto>(sql);
        }

        public async Task<City> GetByCode(int code)
        {
            return await DbContext.Citys.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Citys WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

        public async Task<City> Save(City entity)
        {
            DbContext.Citys.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(City entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
    }
}
