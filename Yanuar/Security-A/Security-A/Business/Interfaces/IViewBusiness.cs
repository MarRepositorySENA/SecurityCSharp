using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ViewDto> GetById(int id);
        Task<View> Save(ViewDto entity);
        Task Update( ViewDto entity);
        View mapearDatos(View view, ViewDto entity);
        Task<IEnumerable<ViewDto>> GetAll();
    }
}
