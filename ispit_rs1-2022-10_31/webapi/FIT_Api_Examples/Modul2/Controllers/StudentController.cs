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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost("{id}")]
        public ActionResult Obrisi2(int id)
        {
            Student student = _dbContext.Student.Find(id);

            if (student == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(student);

            _dbContext.SaveChanges();
            return Ok(student);
        }


        [HttpPost]
        public ActionResult Snimi([FromBody] StudentGetAllVM x)
        {
            Student student;
            if (x.id == 0)
            {
                student = new Student
                {
                    created_time = DateTime.Now,

                };
                _dbContext.Add(student);
            }
            else
            {
                student = _dbContext.Student.FirstOrDefault(s => s.id == x.id);

            }
       

            if (student == null)
                return BadRequest("pogresan ID");

            student.ime = x.ime.RemoveTags();
            student.prezime = x.prezime.RemoveTags();
            student.opstina_rodjenja_id = x.opstina_rodjenja_id;
            _dbContext.SaveChanges();

         
            
            if (student.broj_indeksa == null)
            {
                student.broj_indeksa = "IB" + x.id;
                student.korisnickoIme = x.broj_indeksa;
                student.lozinka = TokenGenerator.Generate(5);
                _dbContext.SaveChanges();
            }

            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll(string ime_prezime)
        {
            var data = _dbContext.Student
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime))
                .OrderByDescending(s => s.id)
                .Take(100)
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

                })
                .ToList();
            //nemojte koristiti entity klase -jer bi onda čitao byte[] za svakog studenta.

            return Ok(data);
        }

        [HttpGet("{korisnikid}")]
        public ActionResult GetSlikaKorisnika(int korisnikid)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");

            byte[] bajtovi = Fajlovi.Ucitaj(Config.SlikeFolder + korisnikid + ".png");

            if (bajtovi == null)
            {
                bajtovi = Fajlovi.Ucitaj(Config.SlikeFolder + "empty.png");
            }

            return File(bajtovi, "image/png");
        }
      

    }
}
