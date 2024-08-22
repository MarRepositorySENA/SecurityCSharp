using Business.Interfaces.Location;
using Entity.Dto;
using Entity.Dto.Location;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interfaces.Location;

namespace Web_Serv.Controllers.Location
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase, IControllerCity
    {
        private readonly ICityBusiness _cityBusiness;

        public CityController(ICityBusiness cityBusiness)
        {
            _cityBusiness = cityBusiness;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _cityBusiness.Delete(id);
            return NoContent();
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAllSelect()
        {
            var result = await _cityBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            var result = await _cityBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<ActionResult<CityDto>> Save([FromBody] CityDto entity)
        //{
        //    if (entity == null)
        //    {
        //        return BadRequest("Hay error en la entity");
        //    }

        //    var result = await _cityBusiness.Save(entity);
        //    return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CityDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _cityBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> Save([FromBody] CityDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _cityBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
