﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entity.Model.Security;
using Entity.Dto;
using Business.Interfaces;



namespace Controller.Implementacion
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   
        public class ModuloController : ControllerBase
        {
            private readonly IModuloBusiness _moduloBusiness;

            public ModuloController(IModuloBusiness moduloBusiness)
            {
                _moduloBusiness = moduloBusiness;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ModuloDto>>> GetAll()
            {
                var result = await _moduloBusiness.GetAll();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ModuloDto>> GetById(int id)
            {
                var result = await _moduloBusiness.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            [HttpGet("select")]
            public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
            {
                var result = await _moduloBusiness.GetAllSelect();
                return Ok(result);
            }

            [HttpPost]
            public async Task<ActionResult<Modulo>> Save([FromBody] ModuloDto entity)
            {
                if (entity == null)
                {
                    return BadRequest("Entity is null");
                }
                var result = await _moduloBusiness.Save(entity);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] ModuloDto entity)
            {
                if (entity == null || id != entity.Id)
                {
                    return BadRequest();
                }
                await _moduloBusiness.Update(id, entity);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _moduloBusiness.Delete(id);
                return NoContent();
            }
        }


    
}
