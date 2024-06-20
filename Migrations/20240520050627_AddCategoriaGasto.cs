using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GastosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Gasto",
                table: "Gasto");

            migrationBuilder.RenameTable(
                name: "Gasto",
                newName: "Gastos");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Gastos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaGastoId",
                table: "Gastos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gastos",
                table: "Gastos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CategoriaGastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaGastos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CategoriaGastos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Lazer" },
                    { 2, "Contas" },
                    { 3, "Aluguel" },
                    { 4, "Comida" },
                    { 5, "Trasporte" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_CategoriaGastoId",
                table: "Gastos",
                column: "CategoriaGastoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_CategoriaGastos_CategoriaGastoId",
                table: "Gastos",
                column: "CategoriaGastoId",
                principalTable: "CategoriaGastos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_CategoriaGastos_CategoriaGastoId",
                table: "Gastos");

            migrationBuilder.DropTable(
                name: "CategoriaGastos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gastos",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_CategoriaGastoId",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "CategoriaGastoId",
                table: "Gastos");

            migrationBuilder.RenameTable(
                name: "Gastos",
                newName: "Gasto");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Gasto",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gasto",
                table: "Gasto",
                column: "Id");
        }
    }
}
