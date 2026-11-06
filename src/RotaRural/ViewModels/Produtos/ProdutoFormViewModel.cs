using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using RotaRural.Models;

namespace RotaRural.ViewModels
{
    public class ProdutoFormViewModel : IValidatableObject
    {
        // Nulo ao criar, preenchido ao editar
        public int? Id { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [StringLength(80, ErrorMessage = "O nome pode ter no máximo 80 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Escolha uma categoria.")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Unidade")]
        [Required(ErrorMessage = "Escolha a unidade.")]
        public UnidadeMedida? Unidade { get; set; }

        [Display(Name = "Preço (R$)")]
        [Required(ErrorMessage = "Informe o preço.")]
        [Range(0.01, 99999.99, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal? Preco { get; set; }

        [Display(Name = "Quantidade em estoque")]
        [Required(ErrorMessage = "Informe a quantidade.")]
        [Range(0, 100000, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int? Quantidade { get; set; }

        [Display(Name = "Retirada")]
        public bool AceitaRetirada { get; set; }

        [Display(Name = "Entrega agendada")]
        public bool AceitaEntregaAgendada { get; set; }

        [Display(Name = "Foto do produto")]
        public IFormFile? Foto { get; set; }

        // Para mostrar a foto atual no modal de edição
        public string? FotoAtualUrl { get; set; }

        // Opções do <select> de categoria (não vêm do formulário: o controller preenche)
        public IEnumerable<SelectListItem> Categorias { get; set; } = Enumerable.Empty<SelectListItem>();

        // Regras que envolvem mais de um campo
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!AceitaRetirada && !AceitaEntregaAgendada)
            {
                yield return new ValidationResult(
                    "Escolha pelo menos uma forma de entrega.",
                    new[] { nameof(AceitaRetirada) });
            }
        }
    }
}