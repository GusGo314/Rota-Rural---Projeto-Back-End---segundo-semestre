using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaRural.Migrations
{
    /// <inheritdoc />
    public partial class AjusteMicrorregiao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nomeMesorregiao",
                table: "Microrregioes");

            migrationBuilder.DropColumn(
                name: "nomeMicrorregiao",
                table: "Microrregioes");

            migrationBuilder.DropColumn(
                name: "nomeRegiao",
                table: "Microrregioes");

            migrationBuilder.DropColumn(
                name: "nomeUF",
                table: "Microrregioes");

            migrationBuilder.AddColumn<int>(
                name: "CodigoMunicipioIbge",
                table: "Microrregioes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Microrregioes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CodigoMunicipioIbge",
                value: 3151800);

            migrationBuilder.CreateIndex(
                name: "IX_Microrregioes_CodigoMunicipioIbge",
                table: "Microrregioes",
                column: "CodigoMunicipioIbge",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Microrregioes_CodigoMunicipioIbge",
                table: "Microrregioes");

            migrationBuilder.DropColumn(
                name: "CodigoMunicipioIbge",
                table: "Microrregioes");

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

            migrationBuilder.UpdateData(
                table: "Microrregioes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "nomeMesorregiao", "nomeMicrorregiao", "nomeRegiao", "nomeUF" },
                values: new object[] { "Sul/Sudoeste de Minas", "Poços de Caldas", "Sudeste", "MG" });
        }
    }
}
