﻿using Business.Interfaces;
using Entity.Dto;

using Microsoft.AspNetCore.Mvc;

namespace Web_Service.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;
        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll()
        {
            var result = await _personBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("Person/{id}")]
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            var result = await _personBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Person/select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _personBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Save([FromBody] PersonDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _personBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("Person/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _personBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("Person/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
