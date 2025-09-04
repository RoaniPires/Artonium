// ====================================================
// CONTROLLER DE PERSONAGENS - TORMENTA 20
// ====================================================
// Gerencia operações CRUD de personagens

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtoniumApi.Data;
using ArtoniumApi.Models;

namespace ArtoniumApi.Controllers;

/// <summary>
/// Controller para gerenciar personagens de Tormenta 20
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PersonagensController : ControllerBase
{
    private readonly ArtoniumDbContext _context;

    /// <summary>
    /// Construtor que recebe o contexto do banco via Dependency Injection
    /// </summary>
    public PersonagensController(ArtoniumDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Lista todos os personagens
    /// </summary>
    /// <returns>Lista de personagens</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
    {
        var personagens = await _context.Personagens
            .OrderBy(p => p.Nome)
            .ToListAsync();

        return Ok(personagens);
    }

    /// <summary>
    /// Busca um personagem por ID
    /// </summary>
    /// <param name="id">ID do personagem</param>
    /// <returns>Personagem encontrado ou 404</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Personagem>> GetPersonagem(int id)
    {
        var personagem = await _context.Personagens.FindAsync(id);

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
        // Valida o modelo
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Define a data de criação
        personagem.CriadoEm = DateTime.UtcNow;

        // Adiciona ao contexto
        _context.Personagens.Add(personagem);
        await _context.SaveChangesAsync();

        // Retorna 201 Created com o personagem criado
        return CreatedAtAction(
            nameof(GetPersonagem), 
            new { id = personagem.Id }, 
            personagem);
    }

    /// <summary>
    /// Atualiza um personagem existente
    /// </summary>
    /// <param name="id">ID do personagem</param>
    /// <param name="personagem">Novos dados do personagem</param>
    /// <returns>204 No Content ou erro</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersonagem(int id, Personagem personagem)
    {
        if (id != personagem.Id)
        {
            return BadRequest("ID da URL não confere com ID do personagem");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Verifica se o personagem existe
        var personagemExistente = await _context.Personagens.FindAsync(id);
        if (personagemExistente == null)
        {
            return NotFound($"Personagem com ID {id} não encontrado");
        }

        // Atualiza apenas os campos permitidos
        personagemExistente.Nome = personagem.Nome;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return Conflict("Erro de concorrência. Tente novamente.");
        }

        return NoContent();
    }

    /// <summary>
    /// Remove um personagem
    /// </summary>
    /// <param name="id">ID do personagem</param>
    /// <returns>204 No Content ou erro</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonagem(int id)
    {
        var personagem = await _context.Personagens.FindAsync(id);
        
        if (personagem == null)
        {
            return NotFound($"Personagem com ID {id} não encontrado");
        }

        _context.Personagens.Remove(personagem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
