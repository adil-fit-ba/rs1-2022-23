using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika_korisnika_base64",
                table: "KorisnickiNalog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slika_korisnika_base64",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
