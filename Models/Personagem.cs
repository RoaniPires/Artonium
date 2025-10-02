using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtoniumApi.Models;

[Table("personagens")]
public class Personagem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
    [Column("nome")]
    public string Nome { get; private set; } = string.Empty;

    [Column("criado_em")]
    public DateTime CriadoEm { get; private set; }

    private Personagem() { }
    public Personagem(string nome)
    {
        SetNome(nome);
        CriadoEm = DateTime.UtcNow;
    }

    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio", nameof(nome));

        if (nome.Length > 100)
            throw new ArgumentException("Nome deve ter no máximo 100 caracteres", nameof(nome));

        Nome = nome.Trim();
    }

    public bool IsValido() => !string.IsNullOrWhiteSpace(Nome) && Nome.Length <= 100;
}
