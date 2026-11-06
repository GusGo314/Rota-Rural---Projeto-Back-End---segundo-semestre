using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RotaRural.Models;

namespace RotaRural.Data
{
    public static class SemearDados
    {
        private const int ProdutorTesteId = 1;   // criado pelo HasData no DataBaseContext

        // Ids das categorias criadas pelo HasData
        private const int Hortalicas = 1;
        private const int Frutas = 2;
        private const int Laticinios = 4;

        public static void Inicializar(IServiceProvider serviceProvider)
        {
            using var context = new DataBaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataBaseContext>>());

            if (context.Produto.Any())
                return;

            context.Produto.AddRange(
                CriarProduto("Alface",           Hortalicas, UnidadeMedida.Unidade, 5.40m,  240, retirada: true, entrega: true),
                CriarProduto("Banana",           Frutas,     UnidadeMedida.Duzia,   2.40m,  212, retirada: true, entrega: false),
                CriarProduto("Queijo artesanal", Laticinios, UnidadeMedida.Unidade, 20.99m, 5,   retirada: true, entrega: true),
                CriarProduto("Alho",             Hortalicas, UnidadeMedida.Unidade, 7.40m,  120, retirada: true, entrega: false),
                CriarProduto("Alho poró",        Hortalicas, UnidadeMedida.Maco,    10.40m, 240, retirada: false, entrega: true),
                CriarProduto("Leite",            Laticinios, UnidadeMedida.Litro,   4.00m,  0,   retirada: true, entrega: false)
            );

            context.SaveChanges();
        }

        private static Produto CriarProduto(string nome, int categoriaId, UnidadeMedida unidade,
                                            decimal preco, int quantidade, bool retirada, bool entrega)
        {
            var produto = new Produto
            {
                Nome = nome,
                CategoriaId = categoriaId,
                Unidade = unidade,
                Preco = preco,
                ProdutorId = ProdutorTesteId,
                AceitaRetirada = retirada,
                AceitaEntregaAgendada = entrega,
                EstaDisponivel = true
            };

            produto.DefinirEstoque(quantidade);
            return produto;
        }
    }
}