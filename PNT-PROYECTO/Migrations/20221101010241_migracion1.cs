using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Persona",
                newName: "NombreApellido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreApellido",
                table: "Persona",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Persona",
                type: "TEXT",
                nullable: true);
        }
    }
}
