using Business.Interfaces.Location;
using Data.Implemenst.Location;
using Data.Interfaces.Location;
using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Location;

namespace Business.Service.Location
{
    public class BusinessCountry : ICountryBusiness
    {
        private readonly IDCountry _dcountry;

        public BusinessCountry(IDCountry dcountry)
        {
            _dcountry = dcountry;
        }

        public async Task Delete(int id)
        {
            await _dcountry.Delete(id);
        }

        public async Task<IEnumerable<CountryDto>> GetAllSelect()
        {
            return await _dcountry.GetAllSelect();
        }

        public async Task<CountryDto> GetById(int id)
        {
            Country country = await _dcountry.GetById(id);
            CountryDto countryDto = new CountryDto();

            countryDto.Id = country.Id;
            countryDto.name = country.name;
            countryDto.continentId = country.continentId;
            countryDto.description = country.description;
            countryDto.create_at = country.create_at;
            countryDto.update_at = country.update_at;
            countryDto.delete_at = country.delete_at;
            countryDto.state = country.state;

            return countryDto;
        }

        public async Task<Country> Save(CountryDto entity)
        {
            Country country = new Country();
            country = mapearDatos(country, entity);

            return await _dcountry.Save(country);
        }

        public async Task Update(int id, CountryDto entity)
        {
            Country country = await _dcountry.GetById(id);
            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }
            country = mapearDatos(country, entity);
            await _dcountry.Update(country);
        }

        private Country mapearDatos(Country country, CountryDto entity)
        {
            country.Id = entity.Id;
            country.name = entity.name;
            country.description = entity.description;
            country.continentId = entity.continentId;
            country.create_at = entity.create_at;
            country.update_at = entity.update_at;
            country.delete_at = entity.delete_at;
            country.state = entity.state;

            return country;
        }
    }
}
