using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class migracion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Persona_ProfeLegajo",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_ProfeLegajo",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "ProfeLegajo",
                table: "Material");

            migrationBuilder.RenameColumn(
                name: "Legajo",
                table: "Material",
                newName: "ProfeId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_ProfeId",
                table: "Material",
                column: "ProfeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Persona_ProfeId",
                table: "Material",
                column: "ProfeId",
                principalTable: "Persona",
                principalColumn: "Legajo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Persona_ProfeId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_ProfeId",
                table: "Material");

            migrationBuilder.RenameColumn(
                name: "ProfeId",
                table: "Material",
                newName: "Legajo");

            migrationBuilder.AddColumn<int>(
                name: "ProfeLegajo",
                table: "Material",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_ProfeLegajo",
                table: "Material",
                column: "ProfeLegajo");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Persona_ProfeLegajo",
                table: "Material",
                column: "ProfeLegajo",
                principalTable: "Persona",
                principalColumn: "Legajo");
        }
    }
}
