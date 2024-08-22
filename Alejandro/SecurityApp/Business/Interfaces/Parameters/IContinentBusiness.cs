using Entity.Dto;
using Entity.Dto.Location;
using Entity.Model.Location;

namespace Business.Interfaces.Location
{
    public interface IContinentBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<ContinentDto>> GetAllSelect();
        Task<ContinentDto> GetById(int id);
        Task<Continent> Save(ContinentDto entity);
        Task Update(int id, ContinentDto entity);
    }
}
