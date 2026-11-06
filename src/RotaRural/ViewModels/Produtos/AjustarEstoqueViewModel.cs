using System.ComponentModel.DataAnnotations;

namespace RotaRural.ViewModels
{
    public class AjustarEstoqueViewModel
    {
        public int Id { get; set; }

        // Só para exibir no modal (não vêm do formulário: o controller preenche)
        public string Nome { get; set; } = string.Empty;
        public string Unidade { get; set; } = string.Empty;
        public int QuantidadeAtual { get; set; }

        [Display(Name = "Nova quantidade")]
        [Required(ErrorMessage = "Informe a quantidade.")]
        [Range(0, 100000, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int? NovaQuantidade { get; set; }
    }
}