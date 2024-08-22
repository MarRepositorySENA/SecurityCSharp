using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Location;

namespace Data.Interfaces.Location
{
    public interface IDContinent
    {
        Task Delete(int id);
        Task<IEnumerable<ContinentDto>> GetAllSelect();
        Task<Continent> GetById(int id);
        Task<Continent> Save(Continent entity);
        Task Update(Continent entity);
        Task<Continent> GetByCode(int code);
    }
}
