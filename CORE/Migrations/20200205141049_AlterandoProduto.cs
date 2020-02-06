using Microsoft.EntityFrameworkCore.Migrations;

namespace CORE.Migrations
{
    public partial class AlterandoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "schoolofnet");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaId",
                table: "schoolofnet",
                newName: "IX_schoolofnet_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "schoolofnet",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_schoolofnet",
                table: "schoolofnet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_schoolofnet_Categorias_CategoriaId",
                table: "schoolofnet",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schoolofnet_Categorias_CategoriaId",
                table: "schoolofnet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_schoolofnet",
                table: "schoolofnet");

            migrationBuilder.RenameTable(
                name: "schoolofnet",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_schoolofnet_CategoriaId",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
