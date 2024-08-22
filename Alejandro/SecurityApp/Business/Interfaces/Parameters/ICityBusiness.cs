using Entity.Dto.Location;
using Entity.Dto;
using Entity.Model.Location;

namespace Business.Interfaces.Location
{
    public interface ICityBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<CityDto>> GetAllSelect();
        Task<CityDto> GetById(int id);
        Task<City> Save(CityDto entity);
        Task Update(int id, CityDto entity);
    }
}
