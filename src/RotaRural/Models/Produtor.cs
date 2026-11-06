using System.ComponentModel.DataAnnotations;

namespace RotaRural.Models
{
    public enum StatusAprovacao
    {
        [Display(Name = "Aguardando aprovação")] Pendente,
        [Display(Name = "Aprovado pela administração")] Aprovado,
        [Display(Name = "Recusado")] Recusado
    }

    public class Produtor : Usuario
    {
        [Required, StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string NomeUnidadeFamiliar { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string Caf { get; set; } = string.Empty;

        // Opcional: só é exigido para produtos processados
        [StringLength(30)]
        public string? RegistroIma { get; set; }

        [Required, StringLength(200)]
        public string EnderecoPropriedade { get; set; } = string.Empty;

        public StatusAprovacao StatusAprovacao { get; set; } = StatusAprovacao.Pendente;

        [StringLength(300)]
        public string? MotivoRecusa { get; set; }

        // Atribuída automaticamente a partir do endereço; opcional até a carga do IBGE existir

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}