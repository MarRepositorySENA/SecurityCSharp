

using Entity.Dto;

namespace Controller.Interface
{
    public interface IViewController
    {

        Task<IEnumerable<ViewDto>> GetAll();
        Task<ViewDto> GetById(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ViewDto> Save(ViewDto entity);
        Task Update(int id, ViewDto entity);
        Task Delete(int id);
    }
}
