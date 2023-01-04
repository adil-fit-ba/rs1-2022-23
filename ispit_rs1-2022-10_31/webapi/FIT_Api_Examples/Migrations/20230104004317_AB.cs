using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class AB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "twofCode",
                table: "AutentifikacijaToken",
                newName: "twoFCodeShort");

            migrationBuilder.AddColumn<string>(
                name: "twoFCodeLong",
                table: "AutentifikacijaToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "twoFCodeLong",
                table: "AutentifikacijaToken");

            migrationBuilder.RenameColumn(
                name: "twoFCodeShort",
                table: "AutentifikacijaToken",
                newName: "twofCode");
        }
    }
}
