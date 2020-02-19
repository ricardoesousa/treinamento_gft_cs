using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorDeEventos.Migrations
{
    public partial class AddLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalEventoId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocalEventoId",
                table: "Eventos",
                column: "LocalEventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Locais_LocalEventoId",
                table: "Eventos",
                column: "LocalEventoId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Locais_LocalEventoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_LocalEventoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "LocalEventoId",
                table: "Eventos");
        }
    }
}
