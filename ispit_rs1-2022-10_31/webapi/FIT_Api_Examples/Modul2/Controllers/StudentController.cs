using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    slika_korisnika = s.slika_korisnika,
                })
                .ToList();


            return Ok(data);
        }
        //povratni tip je entity klasa
        //nedostatak: ne može dodati izračunate kolone koje nema u tabeli,
        //nedostatak: treba dodavati include
        //prednost: brže kodiranje

        //povratni tip je VM ili anonimna klasa


    }
}
