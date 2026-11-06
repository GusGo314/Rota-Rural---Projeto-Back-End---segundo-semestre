using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaRural.Migrations
{
    /// <inheritdoc />
    public partial class MicrorregiaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Microrregioes_MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Microrregioes");

            migrationBuilder.AddColumn<int>(
                name: "microrregiaoUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nomeMesorregiao",
                table: "Microrregioes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nomeMicrorregiao",
                table: "Microrregioes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nomeMunicipio",
                table: "Microrregioes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nomeRegiao",
                table: "Microrregioes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nomeUF",
                table: "Microrregioes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Microrregioes",
                columns: new[] { "Id", "nomeMesorregiao", "nomeMicrorregiao", "nomeMunicipio", "nomeRegiao", "nomeUF" },
                values: new object[] { 1, "Sul/Sudoeste de Minas", "Poços de Caldas", "Poços de Caldas", "Sudeste", "MG" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "microrregiaoUsuarioId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_microrregiaoUsuarioId",
                table: "Usuarios",
                column: "microrregiaoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Microrregioes_microrregiaoUsuarioId",
                table: "Usuarios",
                column: "microrregiaoUsuarioId",
                principalTable: "Microrregioes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Microrregioes_microrregiaoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_microrregiaoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DeleteData(
                table: "Microrregioes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "microrregiaoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "nomeMesorregiao",
                table: "Microrregioes");

            migrationBuilder.DropColumn(
                name: "nomeMicrorregiao",
                table: "Microrregioes");

            migrationBuilder.DropColumn(
                name: "nomeMunicipio",
                table: "Microrregioes");

            migrationBuilder.DropColumn(
                name: "nomeRegiao",
                table: "Microrregioes");

            migrationBuilder.DropColumn(
                name: "nomeUF",
                table: "Microrregioes");

            migrationBuilder.AddColumn<int>(
                name: "MicrorregiaoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Microrregioes",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "MicrorregiaoId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MicrorregiaoId",
                table: "Usuarios",
                column: "MicrorregiaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Microrregioes_MicrorregiaoId",
                table: "Usuarios",
                column: "MicrorregiaoId",
                principalTable: "Microrregioes",
                principalColumn: "Id");
        }
    }
}
