using RotaRural.Models;

namespace RotaRural.ViewModels
{
    // Tudo o que a página "Meus produtos" precisa: a lista e o formulário do modal
    public class ProdutosIndexViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; } = Enumerable.Empty<Produto>();

        public ProdutoFormViewModel Formulario { get; set; } = new();

        // true quando o POST deu erro e o modal precisa reabrir mostrando as mensagens
        public bool AbrirModal { get; set; }
    }
}