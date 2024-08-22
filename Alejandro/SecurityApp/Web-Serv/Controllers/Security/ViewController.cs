using Business.Interfaces.Security;
using Data.Interfaces;
using Entity.Dto.SecurityDto;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interfaces.Security;

namespace Web_Serv.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewController : ControllerBase, IControllerView
    {
        public readonly IViewBusiness _viewBusiness;
        public ViewController(IViewBusiness viewBusiness)
        {
            _viewBusiness = viewBusiness;
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<ViewDto>>> GetAllSelect()
        {
            var result = await _viewBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewDto>> GetById(int id)
        {
            var result = await _viewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _viewBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _viewBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _viewBusiness.Delete(id);
            return NoContent();
        }
    }
}
