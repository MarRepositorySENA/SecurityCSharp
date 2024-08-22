using Entity.Dto.SecurityDto;

namespace Data.Interfaces.Security
{
    public interface IDModule
    {
        Task Delete(int id);
        Task<IEnumerable<ModuleDto>> GetAllSelect();
        Task<Entity.Model.Security.Module> GetById(int id);
        Task<Entity.Model.Security.Module> Save(Entity.Model.Security.Module entity);

        Task Update(Entity.Model.Security.Module entity);

        Task<Entity.Model.Security.Module> GetByCode(int code);
    }
}
