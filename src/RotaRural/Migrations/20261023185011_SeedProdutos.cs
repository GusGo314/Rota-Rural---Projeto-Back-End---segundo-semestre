using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaRural.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        // Esvaziada: os produtos de teste agora são criados pelo Data/SemearDados.cs,
        // já com categoria e produtor. Mantida para não quebrar o histórico de migrations.

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}