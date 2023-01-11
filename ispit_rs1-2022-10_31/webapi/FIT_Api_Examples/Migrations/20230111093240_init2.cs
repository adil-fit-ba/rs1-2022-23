using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITApiExamples.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AkademskaGodina_KorisnickiNalog_evidentiraoKorisnikid",
                table: "AkademskaGodina");

            migrationBuilder.DropForeignKey(
                name: "FK_AkademskaGodina_KorisnickiNalog_izmijenioKorisnikid",
                table: "AkademskaGodina");

            migrationBuilder.DropIndex(
                name: "IX_AkademskaGodina_evidentiraoKorisnikid",
                table: "AkademskaGodina");

            migrationBuilder.DropIndex(
                name: "IX_AkademskaGodina_izmijenioKorisnikid",
                table: "AkademskaGodina");

            migrationBuilder.DropColumn(
                name: "evidentiraoKorisnikid",
                table: "AkademskaGodina");

            migrationBuilder.DropColumn(
                name: "izmijenioKorisnikid",
                table: "AkademskaGodina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "evidentiraoKorisnikid",
                table: "AkademskaGodina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "izmijenioKorisnikid",
                table: "AkademskaGodina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AkademskaGodina_evidentiraoKorisnikid",
                table: "AkademskaGodina",
                column: "evidentiraoKorisnikid");

            migrationBuilder.CreateIndex(
                name: "IX_AkademskaGodina_izmijenioKorisnikid",
                table: "AkademskaGodina",
                column: "izmijenioKorisnikid");

            migrationBuilder.AddForeignKey(
                name: "FK_AkademskaGodina_KorisnickiNalog_evidentiraoKorisnikid",
                table: "AkademskaGodina",
                column: "evidentiraoKorisnikid",
                principalTable: "KorisnickiNalog",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AkademskaGodina_KorisnickiNalog_izmijenioKorisnikid",
                table: "AkademskaGodina",
                column: "izmijenioKorisnikid",
                principalTable: "KorisnickiNalog",
                principalColumn: "id");
        }
    }
}
