using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarrosImportados.Migrations
{
    public partial class AddCarro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(nullable: false),
                    Marca = table.Column<int>(nullable: false),
                    Cor = table.Column<string>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Sobre = table.Column<string>(nullable: false),
                    Imagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");
        }
    }
}
