using Entity.Dto.SecurityDto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Security
{
    public interface IDPerson
    {
        Task Delete(int id);
        Task<IEnumerable<PersonDto>> GetAllSelect();
        Task<Person> GetById(int id);
        Task<Person> Save(Person entity);
        Task Update(Person entity);
        Task<Person> GetByCode(int code);
    }
}
