using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PodaciController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PodaciController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Count()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("drzava", _dbContext.Drzava.Count());
            data.Add("Student", _dbContext.Student.Count());
            //data.Add("KorisnickiNalog", _dbContext.KorisnickiNalog.Count());
            data.Add("Opstina", _dbContext.Opstina.Count());
            data.Add("PrijavaIspita", _dbContext.PrijavaIspita.Count());
            data.Add("Predmet", _dbContext.Predmet.Count());

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var drzave = new List<Drzava>();
            var opstine = new List<Opstina>();
            var predmeti = new List<Predmet>();
            var studenti = new List<Student>();
            var nastavnici = new List<Nastavnik>();
            var akademskeGodine = new List<AkademskaGodina>();

            akademskeGodine.Add(new AkademskaGodina { Opis = "2019-20" });
            akademskeGodine.Add(new AkademskaGodina { Opis = "2020-21" });
            akademskeGodine.Add(new AkademskaGodina { Opis = "2021-22" });
            akademskeGodine.Add(new AkademskaGodina { Opis = "2022-23" });

            drzave.Add(new Drzava { Naziv = "BiH" });
            drzave.Add(new Drzava { Naziv = "HR" });
            drzave.Add(new Drzava { Naziv = "Njemacka" });
            drzave.Add(new Drzava { Naziv = "Austrija" });
            drzave.Add(new Drzava { Naziv = "SAD" });
            drzave.Add(new Drzava { Naziv = "Malezija" });

            opstine.Add(new Opstina { description = "Sarajevo", drzava = drzave[0] });
            opstine.Add(new Opstina { description = "Mostar", drzava = drzave[0] });
            opstine.Add(new Opstina { description = "Zenica", drzava = drzave[0] });

            opstine.Add(new Opstina { description = "Split", drzava = drzave[1] });
            opstine.Add(new Opstina { description = "Zagreb", drzava = drzave[1] });

            opstine.Add(new Opstina { description = "Berlin", drzava = drzave[2] });
            opstine.Add(new Opstina { description = "Wiebaden", drzava = drzave[2] });

            opstine.Add(new Opstina { description = "Gratz", drzava = drzave[3] });
            opstine.Add(new Opstina { description = "Klagenfurt", drzava = drzave[3] });

            opstine.Add(new Opstina { description = "Boston", drzava = drzave[4] });
            opstine.Add(new Opstina { description = "New York", drzava = drzave[4] });

            opstine.Add(new Opstina { description = "Kuala Lumpur", drzava = drzave[5] });
            opstine.Add(new Opstina { description = "Subang Jaya", drzava = drzave[5] });

            predmeti.Add(new Predmet { Ects = 5, Naziv = "Programiranje III", Sifra = "RS-PR3" });
            predmeti.Add(new Predmet { Ects = 5, Naziv = "Razvoj softvera I", Sifra = "RS-RS1" });
            predmeti.Add(new Predmet { Ects = 5, Naziv = "Razvoj softvera II", Sifra = "RS-RS2" });

            nastavnici.Add(new Nastavnik { Ime = "Denis", Prezime = "Music", KorisnickoIme = "denis", Lozinka = "test", SlikaKorisnika = Config.SlikeURL + "empty.png", });
            nastavnici.Add(new Nastavnik { Ime = "Emina", Prezime = "Junuz", KorisnickoIme = "emina", Lozinka = "test", SlikaKorisnika = Config.SlikeURL + "empty.png", });
            nastavnici.Add(new Nastavnik { Ime = "Iris",  Prezime = "Memic-Fisic", KorisnickoIme = "iris", Lozinka = "test", SlikaKorisnika = Config.SlikeURL + "empty.png", isProdekan = true });
            nastavnici.Add(new Nastavnik { Ime = "Nina",  Prezime = "Bijedic", KorisnickoIme = "nina", Lozinka = "test", SlikaKorisnika = Config.SlikeURL + "empty.png", isDekan = true });
            nastavnici.Add(new Nastavnik { Ime = "Adil",  Prezime = "Joldic", KorisnickoIme = "adil", Lozinka = "test", SlikaKorisnika = Config.SlikeURL + "empty.png", isAdmin = true });


            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                studenti.Add(new Student
                {
                    BrojIndeksa = $"IB200{i:d}",
                    Ime = TokenGenerator.GenerisiIme(5),
                    Prezime = TokenGenerator.GenerisiIme(5),
                    KorisnickoIme = TokenGenerator.GenerisiIme(5),
                    Lozinka = "test",
                    OpstinaRodjenja = opstine.GetRandomElements(1)[0],
                    SlikaKorisnika = Config.SlikeURL + "empty.png"
                });
            }

            _dbContext.AddRange(nastavnici);
            _dbContext.AddRange(predmeti);
            _dbContext.AddRange(opstine);
            _dbContext.AddRange(drzave);
            _dbContext.AddRange(akademskeGodine);
            _dbContext.AddRange(studenti);
            _dbContext.SaveChanges();

            return Count();
        }





    }
}
