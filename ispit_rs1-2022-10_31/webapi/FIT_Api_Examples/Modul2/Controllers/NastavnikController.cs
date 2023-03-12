using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class NastavnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public NastavnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{guid}")]
        public ActionResult Aktivacija(string guid)
        {
            var nastavnik = _dbContext.Nastavnik.FirstOrDefault(s => s.aktivacijaGUID == guid);
            if (nastavnik != null)
            {
                nastavnik.isAktiviran = true;
                _dbContext.SaveChanges();
                return Redirect("http://localhost:4200/");
            }

            return BadRequest("pogresan URL");
        }


        [HttpPost]
        [Autorizacija(studentskaSluzba: false, prodekan: true, dekan: true, studenti: false, nastavnici: false)]
        public ActionResult Snimi([FromBody] NastavnikSnimiVM x)
        {
            Nastavnik? nastavnik;
            if (x.id == 0)
            {
                nastavnik = new Nastavnik
                {
                    lozinka = "test"
                };
                _dbContext.Add(nastavnik);

                nastavnik.aktivacijaGUID = Guid.NewGuid().ToString();
                

            }
            else
            {
                nastavnik = _dbContext.Nastavnik.FirstOrDefault(s => s.id == x.id);

            }
       

            if (nastavnik == null)
                return BadRequest("pogresan ID");

            nastavnik.ime = x.ime.RemoveTags();
            nastavnik.prezime = x.prezime.RemoveTags();
            nastavnik.email = x.email;
            nastavnik.korisnickoIme = x.korisnickoIme;


            EmailLog.noviNastavnik(nastavnik, HttpContext);

            return Ok();
        }

        [HttpGet]
        [Autorizacija(studentskaSluzba: true, prodekan: true, dekan: true, studenti: false, nastavnici: true)]
        public ActionResult GetAll(string? ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s=>s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime))
                .OrderByDescending(s => s.id)
                .Select(s => new StudentGetAllVM()
                {
                    id = s.id,
                    ime = s.ime,
                    prezime = s.prezime,
                    broj_indeksa = s.broj_indeksa,
                    opstina_rodjenja_opis = s.opstina_rodjenja.description,
                    drzava_rodjenja_opis = s.opstina_rodjenja.drzava.naziv,
                    opstina_rodjenja_id = s.opstina_rodjenja_id,
                    vrijeme_dodavanja = s.created_time.ToString("dd.MM.yyyy"),
                    slika_korisnika_postojeca_base64_DB = s.slika_korisnika_bajtovi,//varijanta 1: slika iz DB
                })
                .ToList();
            
            data.ForEach(s=>
            {
                //varijanta 2: slika sa File systema
                s.slika_korisnika_postojeca_base64_FS = Fajlovi.Ucitaj("slike_korisnika/" + s.id + ".png")
                                                        ?? Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");//ako je null

                s.slika_korisnika_postojeca_base64_DB ??= Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");//ako je null
            });

            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult GetSlikaDB(int id)
        {
            byte[]? bajtovi_slike = _dbContext.Student.Find(id).slika_korisnika_bajtovi 
                                   ?? Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");
            if (bajtovi_slike == null)
                throw new Exception();//bug

            return File(bajtovi_slike, "image/png");
        }

        [HttpGet("{id}")]
        public ActionResult GetSlikaFS(int id)
        {
            byte[]? bajtovi_slike = Fajlovi.Ucitaj("slike_korisnika/" + id + ".png") 
                                   ?? Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");

            if (bajtovi_slike == null)
                throw new Exception();//bug

            return File(bajtovi_slike, "image/png");
        }

    }
}
