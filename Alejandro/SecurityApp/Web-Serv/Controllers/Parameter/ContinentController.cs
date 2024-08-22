using Business.Interfaces.Location;
using Business.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Location;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interfaces.Location;

namespace Web_Serv.Controllers.Location
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContinentController : ControllerBase, IControllerContinent
    {
        private readonly IContinentBusiness _continentBusiness;

        public ContinentController(IContinentBusiness continentBusiness)
        {
            _continentBusiness = continentBusiness;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _continentBusiness.Delete(id);
            return NoContent();
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<ContinentDto>>> GetAllSelect()
        {
            var result = await _continentBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContinentDto>> GetById(int id)
        {
            var result = await _continentBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ContinentDto>> Save([FromBody] ContinentDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _continentBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContinentDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _continentBusiness.Update(id, entity);
            return NoContent();
        }
    }
}
