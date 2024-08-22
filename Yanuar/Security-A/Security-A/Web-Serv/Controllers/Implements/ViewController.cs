using Business.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interface;

namespace Web_Serv.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class ViewController : ControllerBase, IViewController
    {
        private readonly IViewBusiness _viewBusiness;

        public ViewController(IViewBusiness viewBusiness)
        {
             _viewBusiness = viewBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewDto>>> GetAll()
        {
            var result = await _viewBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("View/{id}")]
        public async Task<ActionResult<ViewDto>> GetById(int id)
        {
            var result = await _viewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("View/select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _viewBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _viewBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ViewDto entity)
        {
            if (entity == null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _viewBusiness.Update( entity);
            return NoContent();
        }

        [HttpDelete("ViewDto/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _viewBusiness.Delete(id);
            return NoContent();
        }

    }
}
