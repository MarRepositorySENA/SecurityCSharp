using Business.Interfaces;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller.Implementacion
{
    public class UsercController : ControllerBase
    {
        private readonly IUserBusiness _UserBusiness;
        public UsercController(IUserBusiness UserBusines) {
            _UserBusiness = UserBusines; 
        }        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var result = await _UserBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var result = await _UserBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _UserBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Save([FromBody] UserDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _UserBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _UserBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _UserBusiness.Delete(id);
            return NoContent();

        }
    }
}
