using System.ComponentModel.DataAnnotations;

namespace RotaRural.Models
{
    public abstract class Usuario
    {
        public int Id { get; set; }

        public int? MicrorregiaoId { get; set; }

        public Microrregiao? Microrregiao { get; set;}

        [Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required, StringLength(150), EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Guarda o hash da senha, nunca a senha em texto
        [Required]
        public string SenhaHash { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    }
}
