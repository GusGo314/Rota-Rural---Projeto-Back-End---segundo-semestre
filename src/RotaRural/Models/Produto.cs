using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RotaRural.Models
{
    public enum UnidadeMedida
    {
        [Display(Name = "unid.")] Unidade,
        [Display(Name = "dúzia")] Duzia,
        [Display(Name = "maço")] Maco,
        [Display(Name = "litro")] Litro,
    }

    public class Produto
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Nome { get; set; } = string.Empty;

        public int CategoriaId { get; set; }
        public CategoriaProduto Categoria { get; set; } = null!;

        public UnidadeMedida Unidade { get; set; }

        [Precision(10, 2)]
        public decimal Preco { get; set; }

        public int Quantidade { get; private set; }

        [StringLength(200)]
        public string? FotoUrl { get; set; }

        public bool AceitaRetirada { get; set; }

        public bool AceitaEntregaAgendada { get; set; }

        // Controlado pelo produtor (pausar/reativar a venda)
        public bool EstaDisponivel { get; set; } = true;
        
        // Produto removido pelo produtor: some das telas, mas continua no banco
        // porque pedidos antigos (ItemPedido) apontam para ele
        public bool Excluido { get; private set; }

        public void Excluir()
        {
            Excluido = true;
            EstaDisponivel = false;
        }

        // Calculado, não vira coluna no banco
        [NotMapped]
        public bool Esgotado => Quantidade == 0;

        public int ProdutorId { get; set; }
        public Produtor Produtor { get; set; } = null!;

        public void DefinirEstoque(int quantidade)
        {
            if (quantidade < 0)
                throw new InvalidOperationException("O estoque não pode ser negativo.");

            Quantidade = quantidade;
        }

        public void AtualizarEstoque(int variacao) => DefinirEstoque(Quantidade + variacao);

        public void AtualizarDisponibilidade(bool status) => EstaDisponivel = status;
    }
}