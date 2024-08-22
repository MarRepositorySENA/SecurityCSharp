using Business.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Implements
{
    public class ModuloBusiness : IModuloBusiness
    {
        private readonly IModuloData data;

        public ModuloBusiness(IModuloData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            IEnumerable<Modulo> modulos = await this.data.GetAll();
            var moduloDtos = modulos.Select(modulo => new ModuloDto
            {
                Id = modulo.Id,
                Name = modulo.Name,
                Description = modulo.Description,
                State = modulo.State
            });

            return moduloDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<ModuloDto> GetById(int id)
        {
            Modulo modulo = await this.data.GetById(id);
            ModuloDto ModuloDto = new ModuloDto();

            ModuloDto.Id = modulo.Id;
            ModuloDto.Name = modulo.Name;
            ModuloDto.Description = modulo.Description;
            ModuloDto.State = modulo.State;
            return ModuloDto;
        }

        public Modulo mapearDatos(Modulo modulo, ModuloDto entity)
        {
            modulo.Id = entity.Id;
            modulo.Name = entity.Name;
            modulo.Description = entity.Description;
            modulo.State = entity.State;
            return modulo;
        }

        public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo();
            modulo = this.mapearDatos(modulo, entity);

            return await this.data.Save(modulo);
        }

        public async Task Update( ModuloDto entity)
        {
            Modulo modulo = await this.data.GetById(entity.Id);
            if (modulo == null)
            {
                throw new Exception("Registro no encontrado");
            }
            modulo = this.mapearDatos(modulo, entity);

            await this.data.Update(modulo);
        }
    }
}
