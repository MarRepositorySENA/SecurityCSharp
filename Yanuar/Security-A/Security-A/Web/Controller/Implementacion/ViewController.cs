using Business.Interfaces;
using Controller.Interface;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller.Implementacion
{
    public class ViewController : ControllerBase
    {
        private readonly IViewBusiness _ViewBusines;
        public ViewController(IViewBusiness ViewBusiness)
        {
            _ViewBusines = ViewBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewDto>>> GetAll()
        {
            var result = await _ViewBusines.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewDto>> GetById(int id)
        {
            var result = await _ViewBusines.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _ViewBusines.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _ViewBusines.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ViewDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _ViewBusines.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ViewBusines.Delete(id);
            return NoContent();

        }

      
    }
}
