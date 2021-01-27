using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sdt.Data.Migrations
{
    public partial class AutorPhoto_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Autoren",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoMimeType",
                table: "Autoren",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Autoren");

            migrationBuilder.DropColumn(
                name: "PhotoMimeType",
                table: "Autoren");
        }
    }
}
