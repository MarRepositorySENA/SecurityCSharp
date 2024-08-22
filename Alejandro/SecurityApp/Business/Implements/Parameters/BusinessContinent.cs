using Business.Interfaces.Location;
using Data.Interfaces.Location;
using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Location;

namespace Business.Service.Location
{
    public class BusinessContinent : IContinentBusiness
    {
        private readonly IDContinent _dcontinent;

        public BusinessContinent(IDContinent dcontinent)
        {
            _dcontinent = dcontinent;
        }

        public async Task Delete(int id)
        {
            await _dcontinent.Delete(id);
        }

        public async Task<IEnumerable<ContinentDto>> GetAllSelect()
        {
            return await _dcontinent.GetAllSelect();
        }

        public async Task<ContinentDto> GetById(int id)
        {
            Continent continent = await _dcontinent.GetById(id);
            ContinentDto continentDto = new ContinentDto();

            continentDto.Id = continent.Id;
            continentDto.name = continent.name;
            continentDto.description = continent.description;
            continentDto.create_at = continent.create_at;
            continentDto.update_at = continent.update_at;
            continentDto.delete_at = continent.delete_at;
            continentDto.state = continent.state;

            return continentDto;
        }

        public async Task<Continent> Save(ContinentDto entity)
        {
            Continent continent = new Continent();
            continent = mapearDatos(continent, entity);
            return await _dcontinent.Save(continent);
        }

        public async Task Update(int id, ContinentDto entity)
        {
            Continent continent = await _dcontinent.GetById(id);
            if (continent == null)
            {
                throw new Exception("Registro no encontrado");
            }
            continent = mapearDatos(continent, entity);
            await _dcontinent.Update(continent);
        }

        public Continent mapearDatos(Continent continent, ContinentDto entity)
        {
            continent.Id = entity.Id;
            continent.name = entity.name;
            continent.description = entity.description;
            continent.create_at = entity.create_at;
            continent.update_at = entity.update_at;
            continent.delete_at = entity.delete_at;
            continent.state = entity.state;

            return continent;
        }
    }
}
