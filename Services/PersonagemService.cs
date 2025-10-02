using ArtoniumApi.Data;
using ArtoniumApi.Models;
using ArtoniumApi.DTOs;
using ArtoniumApi.Common;
using Microsoft.EntityFrameworkCore;

namespace ArtoniumApi.Services;

public class PersonagemService : IPersonagemService
{
    private readonly ArtoniumContext _context;

    public PersonagemService(ArtoniumContext context)
    {
        _context = context;
    }

    public async Task<Result<List<PersonagemResponseDto>>> GetAllAsync()
    {
        try
        {
            var personagens = await _context.Personagens
                .OrderBy(p => p.Nome)
                .ToListAsync();

            var dtos = personagens.Select(p => new PersonagemResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                CriadoEm = p.CriadoEm
            }).ToList();

            return Result<List<PersonagemResponseDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<List<PersonagemResponseDto>>.Failure($"Erro ao buscar personagens: {ex.Message}");
        }
    }

    public async Task<Result<PersonagemResponseDto>> GetByIdAsync(int id)
    {
        try
        {
            var personagem = await _context.Personagens.FindAsync(id);
            if (personagem == null)
                return Result<PersonagemResponseDto>.Failure("Personagem não encontrado");

            var dto = new PersonagemResponseDto
            {
                Id = personagem.Id,
                Nome = personagem.Nome,
                CriadoEm = personagem.CriadoEm
            };

            return Result<PersonagemResponseDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<PersonagemResponseDto>.Failure($"Erro ao buscar personagem: {ex.Message}");
        }
    }

    public async Task<Result<PersonagemResponseDto>> CreateAsync(CreatePersonagemDto dto)
    {
        try
        {
            var personagem = new Personagem(dto.Nome);

            _context.Personagens.Add(personagem);
            await _context.SaveChangesAsync();

            var responseDto = new PersonagemResponseDto
            {
                Id = personagem.Id,
                Nome = personagem.Nome,
                CriadoEm = personagem.CriadoEm
            };

            return Result<PersonagemResponseDto>.Success(responseDto);
        }
        catch (ArgumentException ex)
        {
            return Result<PersonagemResponseDto>.Failure(ex.Message);
        }
        catch (Exception ex)
        {
            return Result<PersonagemResponseDto>.Failure($"Erro ao criar personagem: {ex.Message}");
        }
    }

    public async Task<Result> UpdateAsync(int id, UpdatePersonagemDto dto)
    {
        try
        {
            var personagem = await _context.Personagens.FindAsync(id);
            if (personagem == null)
                return Result.Failure("Personagem não encontrado");

            personagem.SetNome(dto.Nome);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (ArgumentException ex)
        {
            return Result.Failure(ex.Message);
        }
        catch (Exception ex)
        {
            return Result.Failure($"Erro ao atualizar personagem: {ex.Message}");
        }
    }

    public async Task<Result> DeleteAsync(int id)
    {
        try
        {
            var personagem = await _context.Personagens.FindAsync(id);
            if (personagem == null)
                return Result.Failure("Personagem não encontrado");

            _context.Personagens.Remove(personagem);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Erro ao deletar personagem: {ex.Message}");
        }
    }
}
