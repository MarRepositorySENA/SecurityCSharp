using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Business.Interfaces.Security
{
    public interface IPersonBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<PersonDto>> GetAllSelect();
        Task<PersonDto> GetById(int id);
        Task<Person> Save(PersonDto entity);
        Task Update(int id, PersonDto entity);
    }
}
