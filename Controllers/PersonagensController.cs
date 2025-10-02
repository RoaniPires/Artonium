using Microsoft.AspNetCore.Mvc;
using ArtoniumApi.Services;
using ArtoniumApi.DTOs;

namespace ArtoniumApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonagensController : ControllerBase
{
    private readonly IPersonagemService _service;

    public PersonagensController(IPersonagemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonagemResponseDto>>> GetPersonagens()
    {
        var result = await _service.GetAllAsync();

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok(result.Value);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PersonagemResponseDto>> GetPersonagem(int id)
    {
        var result = await _service.GetByIdAsync(id);

        if (!result.IsSuccess)
            return NotFound(result.ErrorMessage);

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<ActionResult<PersonagemResponseDto>> CreatePersonagem(CreatePersonagemDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _service.CreateAsync(dto);

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return CreatedAtAction(
            nameof(GetPersonagem),
            new { id = result.Value!.Id },
            result.Value);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePersonagem(int id, UpdatePersonagemDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _service.UpdateAsync(id, dto);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePersonagem(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result.IsSuccess)
        {
            return NotFound(result.ErrorMessage);
        }

        return NoContent();
    }
}
