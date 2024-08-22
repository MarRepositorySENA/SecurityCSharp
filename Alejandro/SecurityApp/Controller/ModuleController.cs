//using Microsoft.AspNetCore.Mvc;


//namespace Controller
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ModuleController
//    {
//        private readonly IModuleBusiness _moduleBusiness;

//        public ModuleController(IModuleBusiness moduleBusiness)
//        {
//            _moduleBusiness = moduleBusiness;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
//        {
//            return await _moduleBusiness.GetAllSelect();
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<ModuleDto>> GetById(int id)
//        {
//            return await _moduleBusiness.GetById(id);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Module>> Save(ModuleDto entity)
//        {
//            return await _moduleBusiness.Save(entity);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> Update(int id, ModuleDto entity)
//        {
//            await _moduleBusiness.Update(id, entity);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(int id)
//        {
//            await _moduleBusiness.Delete(id);
//            return NoContent();
//        }
//    }
//}
