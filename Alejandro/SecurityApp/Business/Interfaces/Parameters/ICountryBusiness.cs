using Entity.Dto.Location;
using Entity.Dto;
using Entity.Model.Location;

namespace Business.Interfaces.Location
{
    public interface ICountryBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<CountryDto>> GetAllSelect();
        Task<CountryDto> GetById(int id);
        Task<Country> Save(CountryDto entity);
        Task Update(int id, CountryDto entity);
    }
}
