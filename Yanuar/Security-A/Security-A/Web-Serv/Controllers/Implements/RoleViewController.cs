using Business.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web_Serv.Controllers.Interface;

namespace Web_Serv.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class RoleViewController : ControllerBase, IRoleViewController
    {

        private readonly IRoleViewBusiness _roleViewBusiness;

        public RoleViewController(IRoleViewBusiness roleViewBusiness)
        {
            _roleViewBusiness = roleViewBusiness;
        }

        [HttpGet("RoleView")]
        public async Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll()
        {
            var result = await _roleViewBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("RoleView/{id}")]
        public async Task<ActionResult<RoleViewDto>> GetById(int id)
        {
            var result = await _roleViewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("RoleView/select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _roleViewBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost("RoleView")]
        public async Task<ActionResult<RoleViewDto>> Save([FromBody] RoleViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _roleViewBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("RoleView")]
        public async Task<IActionResult> Update( [FromBody] RoleViewDto entity)
        {
            if (entity == null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _roleViewBusiness.Update( entity);
            return NoContent();
        }

        [HttpDelete("RoleView/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleViewBusiness.Delete(id);
            return NoContent();
        }
    }
}
