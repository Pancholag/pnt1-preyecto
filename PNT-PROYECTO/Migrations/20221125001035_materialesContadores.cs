using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class materialesContadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examen_Persona_AlumnoLegajo",
                table: "Examen");

            migrationBuilder.DropIndex(
                name: "IX_Examen_AlumnoLegajo",
                table: "Examen");

            migrationBuilder.DropColumn(
                name: "AlumnoLegajo",
                table: "Examen");

            migrationBuilder.AddColumn<int>(
                name: "VecesDescargado",
                table: "Material",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VecesVisto",
                table: "Material",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VecesDescargado",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "VecesVisto",
                table: "Material");

            migrationBuilder.AddColumn<int>(
                name: "AlumnoLegajo",
                table: "Examen",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examen_AlumnoLegajo",
                table: "Examen",
                column: "AlumnoLegajo");

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Persona_AlumnoLegajo",
                table: "Examen",
                column: "AlumnoLegajo",
                principalTable: "Persona",
                principalColumn: "Legajo");
        }
    }
}
