using Business.Interfaces.Security;
using Data.Implemenst;
using Data.Interfaces.Security;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;


namespace Business.Service.Security
{

    public class BusinessPerson : IPersonBusiness
    {
        private readonly IDPerson _person;

        public BusinessPerson(IDPerson person)
        {
            _person = person;
        }
        public async Task Delete(int id)
        {
            await _person.Delete(id);
        }

        public async Task<IEnumerable<PersonDto>> GetAllSelect()
        {
            return await _person.GetAllSelect();
        }

        public async Task<PersonDto> GetById(int id)
        {
            Person person = await _person.GetById(id);
            PersonDto personDto = new PersonDto();

            personDto.Id = person.Id;
            personDto.first_name = person.first_name;
            personDto.last_name = person.last_name;
            personDto.email = person.email;
            personDto.gender = person.gender;
            personDto.document = (uint)person.document;
            personDto.type_document = person.type_document;
            personDto.direction = person.direction;
            personDto.phone = person.phone;
            personDto.birthday = person.birthday;
            personDto.create_at = person.created_at;
            personDto.cityId = person.cityId;
            personDto.state = person.state;

            return personDto;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();
            person = mapearDatos(person, entity);

            return await _person.Save(person);
        }

        public async Task Update(int id, PersonDto entity)
        {
            Person person = await _person.GetById(id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = mapearDatos(person, entity);
            await _person.Update(person);
        }

        private Person mapearDatos(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.first_name = entity.first_name;
            person.last_name = entity.last_name;
            person.email = entity.email;
            person.gender = entity.gender;
            person.document = entity.document;
            person.type_document = entity.type_document;
            person.direction = entity.direction;
            person.phone = entity.phone;
            person.birthday = entity.birthday;
            person.created_at = entity.create_at;
            person.cityId = entity.cityId;
            person.state = entity.state;

            return person;
        }
    }
}
