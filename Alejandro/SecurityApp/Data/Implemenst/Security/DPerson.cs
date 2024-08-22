using Data.Interfaces.Security;
using Entity.Dto.SecurityDto;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Security
{
    public class DPerson : IDPerson
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DPerson(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Person.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<PersonDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Person 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<PersonDto>(sql);
        }
        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM Service_Segurity.dbo.Person WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }
        public async Task<Person> Save(Person entity)
        {
            DbContext.Person.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Person entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<Person> GetByCode(int code)
        {
            return await DbContext.Person.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }
    }
}
