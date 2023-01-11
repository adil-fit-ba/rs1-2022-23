using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITApiExamples.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AkademskaGodina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkademskaGodina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    isProdekan = table.Column<bool>(type: "bit", nullable: false),
                    isDekan = table.Column<bool>(type: "bit", nullable: false),
                    isStudentskaSluzba = table.Column<bool>(type: "bit", nullable: false),
                    slikakorisnikabajtovi = table.Column<byte[]>(name: "slika_korisnika_bajtovi", type: "varbinary(max)", nullable: true),
                    isAktiviran = table.Column<bool>(type: "bit", nullable: false),
                    aktivacijaGUID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ECTS = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzavaid = table.Column<int>(name: "drzava_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.id);
                    table.ForeignKey(
                        name: "FK_Opstina_Drzava_drzava_id",
                        column: x => x.drzavaid,
                        principalTable: "Drzava",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    twoFCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    twoFJelOtkljucano = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id");
                });

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
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Nastavnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nastavnik", x => x.id);
                    table.ForeignKey(
                        name: "FK_Nastavnik_KorisnickiNalog_id",
                        column: x => x.id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumkreiranja = table.Column<DateTime>(name: "datum_kreiranja", type: "datetime2", nullable: false),
                    evidentiraoKorisnikID = table.Column<int>(type: "int", nullable: false),
                    izmijenioKorisnikID = table.Column<int>(type: "int", nullable: false),
                    datumupdate = table.Column<DateTime>(name: "datum_update", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.id);
                    table.ForeignKey(
                        name: "FK_Obavijest_KorisnickiNalog_evidentiraoKorisnikID",
                        column: x => x.evidentiraoKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Obavijest_KorisnickiNalog_izmijenioKorisnikID",
                        column: x => x.izmijenioKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AktivacijaTesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrajanjeMinute = table.Column<float>(type: "real", nullable: false),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivacijaTesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AktivacijaTesta_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ispit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false),
                    DatumIspita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ispit_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PredmetOblast",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredmetOblast", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PredmetOblast_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojindeksa = table.Column<string>(name: "broj_indeksa", type: "nvarchar(max)", nullable: false),
                    opstinarodjenjaid = table.Column<int>(name: "opstina_rodjenja_id", type: "int", nullable: true),
                    createdtime = table.Column<DateTime>(name: "created_time", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_KorisnickiNalog_id",
                        column: x => x.id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Opstina_opstina_rodjenja_id",
                        column: x => x.opstinarodjenjaid,
                        principalTable: "Opstina",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredmetOblastID = table.Column<int>(type: "int", nullable: false),
                    TekstPitanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodoviPozitivni = table.Column<int>(type: "int", nullable: false),
                    BodoviNegativni = table.Column<int>(type: "int", nullable: false),
                    ParcijalnoBodovanje = table.Column<bool>(type: "bit", nullable: false),
                    TipPitanja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pitanje_PredmetOblast_PredmetOblastID",
                        column: x => x.PredmetOblastID,
                        principalTable: "PredmetOblast",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OmiljeniPredmeti",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OmiljeniPredmeti", x => x.id);
                    table.ForeignKey(
                        name: "FK_OmiljeniPredmeti_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OmiljeniPredmeti_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PrijavaIspita",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    IspitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaIspita", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrijavaIspita_Ispit_IspitID",
                        column: x => x.IspitID,
                        principalTable: "Ispit",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PrijavaIspita_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StudentTest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AktivacijaTestaID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    TestPokrenutVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestZavrsenoVrijeme = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Uspjeh = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentTest_AktivacijaTesta_AktivacijaTestaID",
                        column: x => x.AktivacijaTestaID,
                        principalTable: "AktivacijaTesta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentTest_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UpisAkGodine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evidentiraoKorisnikID = table.Column<int>(type: "int", nullable: false),
                    datumUpisZimski = table.Column<DateTime>(type: "datetime2", nullable: false),
                    godinastudina = table.Column<int>(type: "int", nullable: false),
                    cijenaSkolarine = table.Column<float>(type: "real", nullable: false),
                    jelObnova = table.Column<bool>(type: "bit", nullable: false),
                    akademskaGodinaid = table.Column<int>(name: "akademskaGodina_id", type: "int", nullable: false),
                    studentid = table.Column<int>(name: "student_id", type: "int", nullable: false),
                    datumOvjeraZimski = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisAkGodine", x => x.id);
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_AkademskaGodina_akademskaGodina_id",
                        column: x => x.akademskaGodinaid,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_KorisnickiNalog_evidentiraoKorisnikID",
                        column: x => x.evidentiraoKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_Student_student_id",
                        column: x => x.studentid,
                        principalTable: "Student",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PitanjaPonudjeneOpcije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PitanjeID = table.Column<int>(type: "int", nullable: false),
                    JelTacno = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitanjaPonudjeneOpcije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PitanjaPonudjeneOpcije_Pitanje_PitanjeID",
                        column: x => x.PitanjeID,
                        principalTable: "Pitanje",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StudentTestPitanja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentTestID = table.Column<int>(type: "int", nullable: false),
                    PitanjeID = table.Column<int>(type: "int", nullable: false),
                    MaxBodovi = table.Column<float>(type: "real", nullable: false),
                    OstvareniBodovi = table.Column<float>(type: "real", nullable: false),
                    OznaceniOdgovoriIDsString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTestPitanja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentTestPitanja_Pitanje_PitanjeID",
                        column: x => x.PitanjeID,
                        principalTable: "Pitanje",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StudentTestPitanja_StudentTest_StudentTestID",
                        column: x => x.StudentTestID,
                        principalTable: "StudentTest",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AktivacijaTesta_PredmetID",
                table: "AktivacijaTesta",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Ispit_PredmetID",
                table: "Ispit",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_LogKretanjePoSistemu_korisnikID",
                table: "LogKretanjePoSistemu",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_evidentiraoKorisnikID",
                table: "Obavijest",
                column: "evidentiraoKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_izmijenioKorisnikID",
                table: "Obavijest",
                column: "izmijenioKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_OmiljeniPredmeti_PredmetID",
                table: "OmiljeniPredmeti",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_OmiljeniPredmeti_StudentID",
                table: "OmiljeniPredmeti",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Opstina_drzava_id",
                table: "Opstina",
                column: "drzava_id");

            migrationBuilder.CreateIndex(
                name: "IX_PitanjaPonudjeneOpcije_PitanjeID",
                table: "PitanjaPonudjeneOpcije",
                column: "PitanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_PredmetOblastID",
                table: "Pitanje",
                column: "PredmetOblastID");

            migrationBuilder.CreateIndex(
                name: "IX_PredmetOblast_PredmetID",
                table: "PredmetOblast",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspita_IspitID",
                table: "PrijavaIspita",
                column: "IspitID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspita_StudentID",
                table: "PrijavaIspita",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_opstina_rodjenja_id",
                table: "Student",
                column: "opstina_rodjenja_id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_AktivacijaTestaID",
                table: "StudentTest",
                column: "AktivacijaTestaID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_StudentID",
                table: "StudentTest",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestPitanja_PitanjeID",
                table: "StudentTestPitanja",
                column: "PitanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestPitanja_StudentTestID",
                table: "StudentTestPitanja",
                column: "StudentTestID");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_akademskaGodina_id",
                table: "UpisAkGodine",
                column: "akademskaGodina_id");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_evidentiraoKorisnikID",
                table: "UpisAkGodine",
                column: "evidentiraoKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_student_id",
                table: "UpisAkGodine",
                column: "student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "LogKretanjePoSistemu");

            migrationBuilder.DropTable(
                name: "Nastavnik");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "OmiljeniPredmeti");

            migrationBuilder.DropTable(
                name: "PitanjaPonudjeneOpcije");

            migrationBuilder.DropTable(
                name: "PrijavaIspita");

            migrationBuilder.DropTable(
                name: "StudentTestPitanja");

            migrationBuilder.DropTable(
                name: "UpisAkGodine");

            migrationBuilder.DropTable(
                name: "Ispit");

            migrationBuilder.DropTable(
                name: "Pitanje");

            migrationBuilder.DropTable(
                name: "StudentTest");

            migrationBuilder.DropTable(
                name: "AkademskaGodina");

            migrationBuilder.DropTable(
                name: "PredmetOblast");

            migrationBuilder.DropTable(
                name: "AktivacijaTesta");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Opstina");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
