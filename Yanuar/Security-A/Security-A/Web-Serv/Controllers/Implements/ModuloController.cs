using Business.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interface;


namespace Web_Serv.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class ModuloController : ControllerBase, IModuloController
    {

        private readonly IModuloBusiness _moduloBusiness;

        public ModuloController(IModuloBusiness moduloBusiness)
        {
            _moduloBusiness = moduloBusiness;
        }

        [HttpGet("Modulo")]
        public async Task<ActionResult<IEnumerable<ModuloDto>>> GetAll()
        {
            var result = await _moduloBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("Modulo/{id}")]
        public async Task<ActionResult<ModuloDto>> GetById(int id)
        {
            var result = await _moduloBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Modulo/select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _moduloBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost("Modulo")]
        public async Task<ActionResult<Modulo>> Save([FromBody] ModuloDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _moduloBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("Modulo")]
        public async Task<IActionResult> Update([FromBody] ModuloDto entity)
        {
            if (entity == null ||  entity.Id == 0)
            {
                return BadRequest();
            }
            await _moduloBusiness.Update( entity);
            return NoContent();
        }

        [HttpDelete("Modulo/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _moduloBusiness.Delete(id);
            return NoContent();
        }
    }
}
