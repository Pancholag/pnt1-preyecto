using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class contentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Material",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Material");
        }
    }
}
