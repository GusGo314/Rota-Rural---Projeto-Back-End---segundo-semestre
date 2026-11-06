using Microsoft.EntityFrameworkCore;
using RotaRural.Models;

namespace RotaRural.Data;

/// <summary>
/// Contexto do banco de dados da aplicação.
/// </summary>
public class DataBaseContext : DbContext
{
    // Id fixo da microrregião semeada em OnModelCreating; usado pelo produtor de teste
    private const int MicrorregiaoTesteId = 1;

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Produtor> Produtores => Set<Produtor>();
    public DbSet<Comprador> Compradores => Set<Comprador>();

    public DbSet<Produto> Produto => Set<Produto>();
    public DbSet<CategoriaProduto> CategoriasProduto => Set<CategoriaProduto>();

    public DbSet<Microrregiao> Microrregioes => Set<Microrregiao>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // ---------- Usuário  ----------
        mb.Entity<Usuario>(e =>
        {
            e.ToTable("Usuarios");
            e.HasKey(u => u.Id);

            e.Property(u => u.Nome).IsRequired().HasMaxLength(100);

            e.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            e.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("UQ_Usuarios_Email");
            e.HasOne(u => u.Microrregiao)
                .WithMany()
                .HasForeignKey(u => u.MicrorregiaoId)
                .OnDelete(DeleteBehavior.Restrict);
            e.Property(u => u.SenhaHash)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        // ---------- Produtor (herda de Usuario, fica na mesma tabela) ----------
        mb.Entity<Produtor>(e =>
        {
            // Filtrado: em SQL Server um UNIQUE aceita apenas um NULL. Sem o filtro,
            // o segundo Comprador (Cpf NULL) violaria este indice.
            e.HasIndex(p => p.Cpf)
                .IsUnique()
                .HasFilter("[Cpf] IS NOT NULL")
                .HasDatabaseName("UQ_Usuarios_Cpf");

            // TEMPORÁRIO: produtor de teste, remover quando o login existir
            e.HasData(new Produtor
            {
                Id = 1,
                Nome = "Responsável Teste",
                Email = "boasemente@teste.com",
                SenhaHash = "PROVISORIO",
                Cpf = "123.456.789-00",
                NomeUnidadeFamiliar = "Sítio Boa Semente",
                Caf = "CAF-MG-65214",
                EnderecoPropriedade = "Estrada Rural km 4, Poços de Caldas - MG",
                StatusAprovacao = StatusAprovacao.Aprovado,
                CriadoEm = new DateTime(2026, 1, 1),
                MicrorregiaoId = MicrorregiaoTesteId
            });
        });

        // ---------- Comprador ----------
        // Em TPH o EF nao compartilha a coluna entre irmaos: gera Comprador_Cpf separada,
        // entao a unicidade de CPF entre perfis diferentes fica a cargo do ContaController.
        mb.Entity<Comprador>(e =>
        {
            e.HasIndex(c => c.Cpf)
                .IsUnique()
                .HasFilter("[Comprador_Cpf] IS NOT NULL")
                .HasDatabaseName("UQ_Usuarios_Comprador_Cpf");
        });

        // ---------- Microrregião ----------
        mb.Entity<Microrregiao>(e =>
        {
            e.ToTable("Microrregioes");

            // TEMPORÁRIO: microrregião do produtor de teste. As demais vêm da API do IBGE.
            e.HasData(new Microrregiao
            {
                Id = MicrorregiaoTesteId,
                nomeMunicipio = "Poços de Caldas",
                CodigoMunicipioIbge = 3151800
            });
            e.HasIndex(m => m.CodigoMunicipioIbge).IsUnique();
        });

        // ---------- Categoria de produto ----------
        mb.Entity<CategoriaProduto>(e =>
        {
            e.ToTable("CategoriasProduto");

            e.HasIndex(c => c.Nome)
                .IsUnique()
                .HasDatabaseName("UQ_CategoriasProduto_Nome");

            e.HasData(
                new CategoriaProduto { Id = 1, Nome = "Hortaliças", Icone = "🥬" },
                new CategoriaProduto { Id = 2, Nome = "Frutas", Icone = "🍎" },
                new CategoriaProduto { Id = 3, Nome = "Ovos", Icone = "🥚" },
                new CategoriaProduto { Id = 4, Nome = "Laticínios", Icone = "🧀" },
                new CategoriaProduto { Id = 5, Nome = "Processados", Icone = "🫙" }
            );
        });

        // ---------- Produto ----------
        mb.Entity<Produto>(e =>
        {
            e.HasQueryFilter(p => !p.Excluido);
            e.HasOne(p => p.Produtor)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.ProdutorId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}