// ====================================================
// MODELO DE PERSONAGEM - TORMENTA 20
// ====================================================
// Esta classe representa um personagem no sistema
// Por enquanto apenas ID e Nome, mas vai crescer!

using System.ComponentModel.DataAnnotations;

namespace ArtoniumApi.Models;

/// <summary>
/// Representa um personagem de Tormenta 20
/// </summary>
public class Personagem
{
    /// <summary>
    /// Identificador único do personagem
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do personagem (obrigatório, máximo 100 caracteres)
    /// </summary>
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Data de criação do personagem (automaticamente preenchida)
    /// </summary>
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
