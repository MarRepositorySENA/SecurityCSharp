using Business.Interfaces.Security;
using Data.Implemenst;
using Data.Interfaces.Security;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Business.Service.Security
{
    public class BusinessView : IViewBusiness
    {
        private readonly IDView _dView;

        public BusinessView(IDView view)
        {
            _dView = view;
        }
        public async Task Delete(int id)
        {
            await _dView.Delete(id);
        }

        public async Task<IEnumerable<ViewDto>> GetAllSelect()
        {
            return await _dView.GetAllSelect();
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await _dView.GetById(id);
            ViewDto viewDto = new ViewDto();

            viewDto.Id = view.Id;
            viewDto.name = view.name;
            viewDto.description = view.description;
            viewDto.route = view.route;
            viewDto.moduleId = view.moduleId;
            viewDto.state = view.state;

            return viewDto;
        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view = mapearDatos(view, entity);

            return await _dView.Save(view);
        }

        public async Task Update(int id, ViewDto entity)
        {
            View view = await _dView.GetById(id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = mapearDatos(view, entity);
            await _dView.Update(view);
        }

        private View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.name = entity.name;
            view.description = entity.description;
            view.route = entity.route;
            view.moduleId = entity.moduleId;
            view.state = entity.state;

            return view;
        }
    }
}
