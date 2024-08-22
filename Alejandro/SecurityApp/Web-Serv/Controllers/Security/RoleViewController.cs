using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Business.Interfaces.Security;
using Web_Serv.Controllers.Interfaces.Security;
using Entity.Dto.SecurityDto;

namespace Web_Serv.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleViewController : ControllerBase, IControllerRoleView
    {
        private readonly IRoleViewBusiness _roleViewBusiness;
        public RoleViewController(IRoleViewBusiness roleViewBusiness)
        {
            _roleViewBusiness = roleViewBusiness;
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<Role_viewDto>>> GetAllSelect()
        {
            var result = await _roleViewBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role_viewDto>> GetById(int id)
        {
            var result = await _roleViewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Role_viewDto>> Save([FromBody] Role_viewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _roleViewBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Role_viewDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _roleViewBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _roleViewBusiness.Delete(id);
            return NoContent();
        }
    }
}
