using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Location;

namespace Data.Interfaces.Location
{
    public interface IDCity
    {
        Task Delete(int id);
        Task<IEnumerable<CityDto>> GetAllSelect();
        Task<City> GetById(int id);
        Task<City> Save(City entity);
        Task Update(City entity);
        Task<City> GetByCode(int code);
    }
}
