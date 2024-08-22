using Entity.Dto.SecurityDto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Security
{
    public interface IDView
    {
        Task Delete(int id);
        Task<IEnumerable<ViewDto>> GetAllSelect();
        Task<View> GetById(int id);
        Task<View> Save(View entity);
        Task Update(View entity);
        Task<View> GetByCode(int code);
    }
}
