using Microsoft.EntityFrameworkCore.Migrations;

namespace CarrosImportados.Migrations
{
    public partial class alterandoCarro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Carros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Marca",
                table: "Carros",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
