using ArtoniumApi.Models;
using ArtoniumApi.DTOs;
using ArtoniumApi.Common;

namespace ArtoniumApi.Services;

public interface IPersonagemService
{
    Task<Result<List<PersonagemResponseDto>>> GetAllAsync();
    Task<Result<PersonagemResponseDto>> GetByIdAsync(int id);
    Task<Result<PersonagemResponseDto>> CreateAsync(CreatePersonagemDto dto);
    Task<Result> UpdateAsync(int id, UpdatePersonagemDto dto);
    Task<Result> DeleteAsync(int id);
}
