using Business.Interfaces.Location;
using Entity.Dto;
using Entity.Dto.Location;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interfaces.Location;

namespace Web_Serv.Controllers.Location
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase, IControllerCountry
    {
        private readonly ICountryBusiness _countryBusiness;
        public CountryController(ICountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _countryBusiness.Delete(id);
            return NoContent();
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAllSelect()
        {
            var result = await _countryBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var result = await _countryBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _countryBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CountryDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _countryBusiness.Update(id, entity);
            return NoContent();
        }
    }
}
