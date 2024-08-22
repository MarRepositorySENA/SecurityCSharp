using Business.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_Service.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize]
    public class RoleViewController : ControllerBase
    {
        private readonly IRoleViewBusiness _RoleViewBusiness;
        public RoleViewController(IRoleViewBusiness RoleViewBusiness)
        {
            _RoleViewBusiness = RoleViewBusiness;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll()
        {
            var result = await _RoleViewBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("RoleView/{id}")]
        public async Task<ActionResult<RoleViewDto>> GetById(int id)
        {
            var result = await _RoleViewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("RoleView/select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _RoleViewBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost("RoleView/post")]
        public async Task<ActionResult<RoleViewDto>> Save([FromBody] RoleViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _RoleViewBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("RoleView/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleViewDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _RoleViewBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("RoleView/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RoleViewBusiness.Delete(id);
            return NoContent();

        }
    }
    }
