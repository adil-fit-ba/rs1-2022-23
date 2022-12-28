using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class kretanjeposistemu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogKretanjePoSistemu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikID = table.Column<int>(type: "int", nullable: true),
                    queryPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isException = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogKretanjePoSistemu", x => x.id);
                    table.ForeignKey(
                        name: "FK_LogKretanjePoSistemu_KorisnickiNalog_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogKretanjePoSistemu_korisnikID",
                table: "LogKretanjePoSistemu",
                column: "korisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogKretanjePoSistemu");
        }
    }
}
