using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Security
{
    public interface IViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<ViewDto>> GetAllSelect();
        Task<ViewDto> GetById(int id);
        Task<View> Save(ViewDto entity);
        Task Update(int id, ViewDto entity);
    }
}
