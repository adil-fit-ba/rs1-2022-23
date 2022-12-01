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
    public class MaticnaKnjigaDetaljiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaDetaljiController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public class MaticnaKnjigaDetaljiUpisiVM
        {
            public DateTime? zimskiSemestarOvjera { get; set; }
            public DateTime zimskiSemestarUpis { get; set; }
            public bool obnova { get; set; }
            public int godinaStudija { get; set; }
            public string akademskaGodinaOpis { get; set; }
            public int upisAkGodineID { get; set; }
            public string evidentiraoKorisnik { get; set; }
        }


        public class MaticnaKnjigaDetaljiVM
        {
            public int studentid{ get; set; }
            public string ime { get; set; }
            public string prezime { get; set; }

            public List<MaticnaKnjigaDetaljiUpisiVM> AkGodines { get; set; } 

        }

        [HttpGet]
        public ActionResult<MaticnaKnjigaDetaljiVM> GetByID(int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var objstudent = _dbContext.Student.Find(studentid);
            

            var resultvm = new MaticnaKnjigaDetaljiVM
            {
                studentid = studentid,
                prezime = objstudent.prezime,
                ime = objstudent.ime,
                AkGodines = _dbContext.UpisAkGodine.Where(s => s.student_id == studentid)
                    .Select(u =>new MaticnaKnjigaDetaljiUpisiVM
                    {
                        upisAkGodineID = u.id,
                        akademskaGodinaOpis = u.akademskaGodina.opis,
                        godinaStudija = u.godinastudina,
                        obnova = u.jelObnova,
                        zimskiSemestarUpis = u.datumUpisZimski,
                        zimskiSemestarOvjera = u.datumOvjeraZimski,
                        evidentiraoKorisnik = u.evidentiraoKorisnik.korisnickoIme
                        //npr prosjecnaOcjema, Dug, Polozeniispit

                    })
                    .ToList(),
                //npr polozeniPredmeti
                //npr uplate
            };

            return resultvm;
        }

    }
}
