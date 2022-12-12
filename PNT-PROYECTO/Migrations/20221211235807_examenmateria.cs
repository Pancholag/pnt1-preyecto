using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class examenmateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamenMaterial");

            migrationBuilder.AddColumn<int>(
                name: "ExamenId",
                table: "Material",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_ExamenId",
                table: "Material",
                column: "ExamenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Examen_ExamenId",
                table: "Material",
                column: "ExamenId",
                principalTable: "Examen",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Examen_ExamenId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_ExamenId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "ExamenId",
                table: "Material");

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
                name: "IX_ExamenMaterial_MaterialesId",
                table: "ExamenMaterial",
                column: "MaterialesId");
        }
    }
}
