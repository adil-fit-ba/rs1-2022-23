using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class MaticnaKnjigaDetaljiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaDetaljiController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult GetById(int studentid)
        {

            var upisAkGodine = _dbContext.UpisAkGodine
                .Where(s => s.student_id == studentid)
                .Select(a=>new {
                    a.id,
                    akademska_godina_opis = a.akademskaGodina.opis,
                    a.godinastudina,
                    a.jelObnova,
                    a.datumUpisZimski,
                    a.datumOvjeraZimski,
                    a.cijenaSkolarine,
                    evidentirao_korisnik = a.evidentiraoKorisnik.korisnickoIme
                })
                ;

            var povratnavr = _dbContext.Student.Where(s=>s.id==studentid)
                
                .Select(s=>new 
                {
                    student_id=s.id,
                    ime=s.ime,
                    prezime=s.prezime,
                    listaUpisi = upisAkGodine.ToList(),
                    cijenaSkolarine = upisAkGodine.Sum(s => s.cijenaSkolarine)

                })
                .FirstOrDefault();


            return Ok(povratnavr);
        }
    }
}