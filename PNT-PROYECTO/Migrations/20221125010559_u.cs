using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class u : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Legajo",
                table: "Ingreso",
                newName: "usuarioLegajo");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_usuarioLegajo",
                table: "Ingreso",
                column: "usuarioLegajo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingreso_Persona_usuarioLegajo",
                table: "Ingreso",
                column: "usuarioLegajo",
                principalTable: "Persona",
                principalColumn: "Legajo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_Persona_usuarioLegajo",
                table: "Ingreso");

            migrationBuilder.DropIndex(
                name: "IX_Ingreso_usuarioLegajo",
                table: "Ingreso");

            migrationBuilder.RenameColumn(
                name: "usuarioLegajo",
                table: "Ingreso",
                newName: "Legajo");
        }
    }
}
