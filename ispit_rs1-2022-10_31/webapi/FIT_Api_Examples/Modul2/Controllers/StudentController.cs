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

            if (!string.IsNullOrEmpty(x.slika_korisnika_nova_base64))
            {
                //slika se snima u db
                byte[]? slika_bajtovi = x.slika_korisnika_nova_base64?.ParsirajBase64();
                student.slika_korisnika_bajtovi = slika_bajtovi;

                if (slika_bajtovi == null)
                    return BadRequest("format slike nije base64");

                //slika se snima na File System
                Fajlovi.Snimi(slika_bajtovi, "slike_korisnika/" + student.id + ".png");
            }
           
            _dbContext.SaveChanges();

         
            
            if (student.broj_indeksa != "" )
            {
                student.broj_indeksa = "IB" + x.id;
                student.korisnickoIme = x.broj_indeksa;
                student.lozinka = TokenGenerator.Generate(5);
                _dbContext.SaveChanges();
            }

            return Ok();
        }

        [HttpGet]
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
