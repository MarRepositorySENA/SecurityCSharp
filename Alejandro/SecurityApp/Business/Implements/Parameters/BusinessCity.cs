using Business.Interfaces.Location;
using Data.Interfaces.Location;
using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Location;

namespace Business.Service.Location
{
    public class BusinessCity : ICityBusiness
    {
        private readonly IDCity _dcity;

        public BusinessCity( IDCity dcity )
        {
            _dcity = dcity;
        }

        public async Task Delete(int id)
        {
            await _dcity.Delete(id);
        }

        public async Task<IEnumerable<CityDto>> GetAllSelect()
        {
            return await _dcity.GetAllSelect();
        }

        public async Task<CityDto> GetById(int id)
        {
            City city = await _dcity.GetById(id);
            CityDto cityDto = new CityDto();

            cityDto.Id = city.Id;
            cityDto.name = city.name;
            cityDto.description = city.description;
            cityDto.countryId = city.countryId;
            cityDto.create_at = city.create_at;
            cityDto.update_at = city.update_at;
            cityDto.delete_at = city.delete_at;
            cityDto.state = city.state;

            return cityDto;
        }

        public async Task<City> Save(CityDto entity)
        {
            City city = new City();
            city = mapearDatos(city, entity);

            return await _dcity.Save(city);
        }

        public async Task Update(int id, CityDto entity)
        {
            City city = await _dcity.GetById(id);
            if (city == null)
            {
                throw new Exception("Registro no encontrado");
            }
            city = mapearDatos(city, entity);
            city.Id = id;
            await _dcity.Update(city);
        }

        private City mapearDatos(City city, CityDto entity)
        {
            city.Id = entity.Id;
            city.name = entity.name;
            city.description = entity.description;
            city.countryId = entity.countryId;
            city.create_at = entity.create_at;
            city.update_at = entity.update_at;
            city.delete_at = entity.delete_at;
            city.state = entity.state;

            return city;
        }
    }
}
