using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class zadatak2b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datumOvjeraZimski",
                table: "UpisAkGodine",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "evidentiraoKorisnikID",
                table: "UpisAkGodine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_evidentiraoKorisnikID",
                table: "UpisAkGodine",
                column: "evidentiraoKorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_UpisAkGodine_KorisnickiNalog_evidentiraoKorisnikID",
                table: "UpisAkGodine",
                column: "evidentiraoKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpisAkGodine_KorisnickiNalog_evidentiraoKorisnikID",
                table: "UpisAkGodine");

            migrationBuilder.DropIndex(
                name: "IX_UpisAkGodine_evidentiraoKorisnikID",
                table: "UpisAkGodine");

            migrationBuilder.DropColumn(
                name: "datumOvjeraZimski",
                table: "UpisAkGodine");

            migrationBuilder.DropColumn(
                name: "evidentiraoKorisnikID",
                table: "UpisAkGodine");
        }
    }
}
