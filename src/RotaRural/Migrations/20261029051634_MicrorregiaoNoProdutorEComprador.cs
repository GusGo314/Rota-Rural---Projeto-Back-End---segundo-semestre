using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaRural.Migrations
{
    /// <inheritdoc />
    public partial class MicrorregiaoNoProdutorEComprador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Microrregioes_microrregiaoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_microrregiaoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "microrregiaoUsuarioId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "Comprador_Cpf",
                table: "Usuarios",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Usuarios",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MicrorregiaoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "MicrorregiaoId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MicrorregiaoId",
                table: "Usuarios",
                column: "MicrorregiaoId");

            // O diferencador do EF nao detecta mudanca de filter em indice existente:
            // recriado aqui para o banco ficar igual ao snapshot.
            migrationBuilder.DropIndex(
                name: "UQ_Usuarios_Cpf",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "UQ_Usuarios_Cpf",
                table: "Usuarios",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_Usuarios_Comprador_Cpf",
                table: "Usuarios",
                column: "Comprador_Cpf",
                unique: true,
                filter: "[Comprador_Cpf] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Microrregioes_MicrorregiaoId",
                table: "Usuarios",
                column: "MicrorregiaoId",
                principalTable: "Microrregioes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Microrregioes_MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "UQ_Usuarios_Comprador_Cpf",
                table: "Usuarios");
            migrationBuilder.DropColumn(
                name: "Comprador_Cpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MicrorregiaoId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            // Desfaz a recriacao filtrada de UQ_Usuarios_Cpf
            migrationBuilder.DropIndex(
                name: "UQ_Usuarios_Cpf",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "UQ_Usuarios_Cpf",
                table: "Usuarios",
                column: "Cpf",
                unique: true);

            migrationBuilder.AddColumn<int>(
                name: "microrregiaoUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
