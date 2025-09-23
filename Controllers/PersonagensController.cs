// ====================================================
// CONTROLLER DE PERSONAGENS - TORMENTA 20
// ====================================================
// Gerencia operações CRUD de personagens

using Microsoft.AspNetCore.Mvc;
using ArtoniumApi.Services;
using ArtoniumApi.Models;

namespace ArtoniumApi.Controllers;

/// <summary>
/// Controller para gerenciar personagens de Tormenta 20
/// </summary>
[ApiController]
[Route("api/[controller]")]
/// <summary>
/// Controller para gerenciar personagens de Tormenta 20 usando MongoDB
/// </summary>
public class PersonagensController : ControllerBase
{
    private readonly PersonagemService _service;

    /// <summary>
    /// Construtor que recebe o serviço de personagens via Dependency Injection
    /// </summary>
    public PersonagensController(PersonagemService service)
    {
        _service = service;
    }

    /// <summary>
    /// Lista todos os personagens
    /// </summary>
    /// <returns>Lista de personagens</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
    {
        var personagens = await _service.GetAllAsync();
        return Ok(personagens);
    }

    /// <summary>
    /// Busca um personagem por ID
    /// </summary>
    /// <param name="id">ID do personagem (MongoDB ObjectId)</param>
    /// <returns>Personagem encontrado ou 404</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Personagem>> GetPersonagem(string id)
    {
        var personagem = await _service.GetByIdAsync(id);
        if (personagem == null)
        {
            return NotFound($"Personagem com ID {id} não encontrado");
        }
        return Ok(personagem);
    }

    /// <summary>
    /// Cria um novo personagem
    /// </summary>
    /// <param name="personagem">Dados do personagem</param>
    /// <returns>Personagem criado</returns>
    [HttpPost]
    public async Task<ActionResult<Personagem>> CreatePersonagem(Personagem personagem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        personagem.CriadoEm = DateTime.UtcNow;
        await _service.CreateAsync(personagem);
        return CreatedAtAction(
            nameof(GetPersonagem),
            new { id = personagem.Id.ToString() },
            personagem);
    }

    /// <summary>
    /// Atualiza um personagem existente
    /// </summary>
    /// <param name="id">ID do personagem (MongoDB ObjectId)</param>
    /// <param name="personagem">Novos dados do personagem</param>
    /// <returns>204 No Content ou erro</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersonagem(string id, Personagem personagem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existente = await _service.GetByIdAsync(id);
        if (existente == null)
        {
            return NotFound($"Personagem com ID {id} não encontrado");
        }
    await _service.UpdateAsync(id, personagem);
        return NoContent();
    }

    /// <summary>
    /// Remove um personagem
    /// </summary>
    /// <param name="id">ID do personagem (MongoDB ObjectId)</param>
    /// <returns>204 No Content ou erro</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonagem(string id)
    {
        var existente = await _service.GetByIdAsync(id);
        if (existente == null)
        {
            return NotFound($"Personagem com ID {id} não encontrado");
        }
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
