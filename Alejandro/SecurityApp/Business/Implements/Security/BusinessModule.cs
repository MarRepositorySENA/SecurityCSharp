using Business.Interfaces.Security;
using Data.Implemenst;
using Data.Interfaces.Security;
using Entity.Dto.SecurityDto;
using Entity.Model.Security;

namespace Business.Service.Security
{
    public class BusinessModule : IModuleBusiness
    {
        private readonly IDModule _module;

        public BusinessModule(IDModule module)
        {
            _module = module;
        }
        public async Task Delete(int id)
        {
            await _module.Delete(id);
        }

        //public Task<Module> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IEnumerable<ModuleDto>> GetAllSelect()
        {
            return await _module.GetAllSelect();
        }

        public async Task<ModuleDto> GetById(int id)
        {
            Module module = await _module.GetById(id);
            ModuleDto moduleDto = new ModuleDto();

            moduleDto.Id = module.Id;
            moduleDto.Name = module.Name;
            moduleDto.Description = module.Description;
            moduleDto.create_at = module.created_at;
            moduleDto.state = module.state;

            return moduleDto;
        }

        public async Task<Module> Save(ModuleDto entity)
        {
            Module module = new Module();
            module = mapearDatos(module, entity);

            return await _module.Save(module);
        }

        public async Task Update(int id, ModuleDto entity)
        {
            Module module = await _module.GetById(id);
            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }
            module = mapearDatos(module, entity);
            await _module.Update(module);
        }
        private Module mapearDatos(Module module, ModuleDto entity)
        {
            module.Id = entity.Id;
            module.Name = entity.Name;
            module.Description = entity.Description;
            module.created_at = entity.create_at;
            module.state = entity.state;

            return module;
        }
    }
}
