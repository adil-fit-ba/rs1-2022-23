using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "slika_korisnika",
                table: "KorisnickiNalog",
                newName: "slika_korisnika_fs");

            migrationBuilder.AddColumn<string>(
                name: "slika_korisnika_base64",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "slika_korisnika_bytes",
                table: "KorisnickiNalog",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika_korisnika_base64",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "slika_korisnika_bytes",
                table: "KorisnickiNalog");

            migrationBuilder.RenameColumn(
                name: "slika_korisnika_fs",
                table: "KorisnickiNalog",
                newName: "slika_korisnika");
        }
    }
}
