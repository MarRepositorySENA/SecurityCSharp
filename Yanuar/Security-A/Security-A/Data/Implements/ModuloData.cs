using Microsoft.Extensions.Configuration;
using Data.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements
{
    public class ModuloData : IModuloData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ModuloData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.Deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.Modulos.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Description) AS TextoMostrar 
                    FROM 
                        Modulo
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Modulo> GetById(int id)
        {
            var sql = @"SELECT * FROM Modulo WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Modulo>(sql, new { Id = id });
        }

        public async Task<Modulo> GetByName(string name)
        {
            return await this.context.Modulos.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Modulo> Save(Modulo entity)
        {
            context.Modulos.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Modulo entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Modulo>> GetAll()
        {
            var sql = @"SELECT * FROM Modulo ORDER BY Id ASC";
            return await this.context.QueryAsync<Modulo>(sql);
        }
    }
}
