using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class hola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfeLegajo",
                table: "Material",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfeLegajo",
                table: "Examen",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExamenMaterial",
                columns: table => new
                {
                    ExamenesId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenMaterial", x => new { x.ExamenesId, x.MaterialesId });
                    table.ForeignKey(
                        name: "FK_ExamenMaterial_Examen_ExamenesId",
                        column: x => x.ExamenesId,
                        principalTable: "Examen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamenMaterial_Material_MaterialesId",
                        column: x => x.MaterialesId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_ProfeLegajo",
                table: "Material",
                column: "ProfeLegajo");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_ProfeLegajo",
                table: "Examen",
                column: "ProfeLegajo");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenMaterial_MaterialesId",
                table: "ExamenMaterial",
                column: "MaterialesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Persona_ProfeLegajo",
                table: "Examen",
                column: "ProfeLegajo",
                principalTable: "Persona",
                principalColumn: "Legajo");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Persona_ProfeLegajo",
                table: "Material",
                column: "ProfeLegajo",
                principalTable: "Persona",
                principalColumn: "Legajo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examen_Persona_ProfeLegajo",
                table: "Examen");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_Persona_ProfeLegajo",
                table: "Material");

            migrationBuilder.DropTable(
                name: "ExamenMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Material_ProfeLegajo",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Examen_ProfeLegajo",
                table: "Examen");

            migrationBuilder.DropColumn(
                name: "ProfeLegajo",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "ProfeLegajo",
                table: "Examen");
        }
    }
}
