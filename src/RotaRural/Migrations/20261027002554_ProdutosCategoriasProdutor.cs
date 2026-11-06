using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RotaRural.Migrations
{
    /// <inheritdoc />
    public partial class ProdutosCategoriasProdutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "categoria",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "foto",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "Produto",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "preco",
                table: "Produto",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Produto",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "estaDisponivel",
                table: "Produto",
                newName: "EstaDisponivel");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Produto",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Caf",
                table: "Usuarios",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPropriedade",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MicrorregiaoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivoRecusa",
                table: "Usuarios",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeUnidadeFamiliar",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistroIma",
                table: "Usuarios",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusAprovacao",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produto",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<bool>(
                name: "AceitaEntregaAgendada",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AceitaRetirada",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Produto",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutorId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Unidade",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoriasProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Icone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Microrregioes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microrregioes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CategoriasProduto",
                columns: new[] { "Id", "Ativa", "Icone", "Nome" },
                values: new object[,]
                {
                    { 1, true, "🥬", "Hortaliças" },
                    { 2, true, "🍎", "Frutas" },
                    { 3, true, "🥚", "Ovos" },
                    { 4, true, "🧀", "Laticínios" },
                    { 5, true, "🫙", "Processados" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Caf", "Cpf", "CriadoEm", "Discriminator", "Email", "EnderecoPropriedade", "MicrorregiaoId", "MotivoRecusa", "Nome", "NomeUnidadeFamiliar", "RegistroIma", "SenhaHash", "StatusAprovacao" },
                values: new object[] { 1, "CAF-MG-65214", "123.456.789-00", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Produtor", "boasemente@teste.com", "Estrada Rural km 4, Poços de Caldas - MG", null, null, "Responsável Teste", "Sítio Boa Semente", null, "PROVISORIO", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MicrorregiaoId",
                table: "Usuarios",
                column: "MicrorregiaoId");

            migrationBuilder.CreateIndex(
                name: "UQ_Usuarios_Cpf",
                table: "Usuarios",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ProdutorId",
                table: "Produto",
                column: "ProdutorId");

            migrationBuilder.CreateIndex(
                name: "UQ_CategoriasProduto_Nome",
                table: "CategoriasProduto",
                column: "Nome",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_CategoriasProduto_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "CategoriasProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuarios_ProdutorId",
                table: "Produto",
                column: "ProdutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Microrregioes_MicrorregiaoId",
                table: "Usuarios",
                column: "MicrorregiaoId",
                principalTable: "Microrregioes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_CategoriasProduto_CategoriaId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuarios_ProdutorId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Microrregioes_MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "CategoriasProduto");

            migrationBuilder.DropTable(
                name: "Microrregioes");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "UQ_Usuarios_Cpf",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_ProdutorId",
                table: "Produto");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Caf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPropriedade",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MotivoRecusa",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NomeUnidadeFamiliar",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RegistroIma",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "StatusAprovacao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AceitaEntregaAgendada",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "AceitaRetirada",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ProdutorId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Unidade",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produto",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produto",
                newName: "preco");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Produto",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "EstaDisponivel",
                table: "Produto",
                newName: "estaDisponivel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produto",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Usuarios",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Produto",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<string>(
                name: "categoria",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "foto",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
