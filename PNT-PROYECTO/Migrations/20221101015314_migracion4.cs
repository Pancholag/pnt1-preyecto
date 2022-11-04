using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class migracion4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examen_Persona_ProfeLegajo",
                table: "Examen");

            migrationBuilder.DropIndex(
                name: "IX_Examen_ProfeLegajo",
                table: "Examen");

            migrationBuilder.DropColumn(
                name: "ProfeLegajo",
                table: "Examen");

            migrationBuilder.RenameColumn(
                name: "Legajo",
                table: "Examen",
                newName: "ProfeId");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_ProfeId",
                table: "Examen",
                column: "ProfeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Persona_ProfeId",
                table: "Examen",
                column: "ProfeId",
                principalTable: "Persona",
                principalColumn: "Legajo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examen_Persona_ProfeId",
                table: "Examen");

            migrationBuilder.DropIndex(
                name: "IX_Examen_ProfeId",
                table: "Examen");

            migrationBuilder.RenameColumn(
                name: "ProfeId",
                table: "Examen",
                newName: "Legajo");

            migrationBuilder.AddColumn<int>(
                name: "ProfeLegajo",
                table: "Examen",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examen_ProfeLegajo",
                table: "Examen",
                column: "ProfeLegajo");

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Persona_ProfeLegajo",
                table: "Examen",
                column: "ProfeLegajo",
                principalTable: "Persona",
                principalColumn: "Legajo");
        }
    }
}
