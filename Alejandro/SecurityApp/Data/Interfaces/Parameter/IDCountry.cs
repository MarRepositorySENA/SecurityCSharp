using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Location
{
    public interface IDCountry
    {
        Task Delete(int id);
        Task<IEnumerable<CountryDto>> GetAllSelect();
        Task<Country> GetById(int id);
        Task<Country> Save(Country entity);
        Task Update(Country entity);
        Task<Country> GetByCode(int code);
    }
}
