using Business.Interfaces.Security;
using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interfaces.Security;

namespace Web_Serv.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase, IControllerPerson
    {
        private readonly IPersonBusiness _personBusiness;
        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAllSelect()
        {
            var result = await _personBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            var result = await _personBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Save([FromBody] PersonDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _personBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _personBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
