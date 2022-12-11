using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    public partial class archivosxd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Material");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Material",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Material",
                type: "TEXT",
                nullable: true);
        }
    }
}
