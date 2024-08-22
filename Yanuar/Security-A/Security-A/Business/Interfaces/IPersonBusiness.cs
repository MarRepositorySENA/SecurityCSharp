using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IPersonBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<PersonDto> GetById(int id);
        Task<Person> Save(PersonDto entity);
        Task Update( PersonDto entity);
        Person mapearDatos(Person person, PersonDto entity);
        Task<IEnumerable<PersonDto>> GetAll();
    }
}
