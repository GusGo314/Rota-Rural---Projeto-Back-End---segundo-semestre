using System.ComponentModel.DataAnnotations;

namespace RotaRural.Models
{
    public class CategoriaProduto
    {
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Nome { get; set; } = string.Empty;

        // Emoji exibido na listagem quando o produto não tem foto (ex.: "🥬")
        [StringLength(8)]
        public string? Icone { get; set; }

        // Em vez de apagar uma categoria que já tem produtos, desativa
        public bool Ativa { get; set; } = true;

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}