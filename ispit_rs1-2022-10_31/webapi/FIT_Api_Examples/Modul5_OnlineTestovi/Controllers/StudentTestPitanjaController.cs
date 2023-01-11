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
using FIT_Api_Examples.Modul5_OnlineTestovi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentTestPitanjaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentTestPitanjaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult GetAll(int studentTestId)
        {

            var pitanja = _dbContext.StudentTestPitanja
                .Where(s => s.ID == studentTestId)
                .Include(s => s.Pitanje)
                .ToList();

            var test = _dbContext.StudentTest
                .Include(s => s.AktivacijaTesta)
                .Include(s => s.Student)
                .SingleOrDefault(t => t.ID == studentTestId);

            return Ok(new
            {
                test,
                pitanja
            });
        }

        public class SnimiVM
        {
            public class SnimiPitanjaVM
            {
                public int StudentTestPitanjaID { get; set; }
                public List<int> OznaceniOdgovoriIDs { get; set; }
                
            }
            public int StudentTestID { get; set; }
            public List<SnimiPitanjaVM> Pitanjas { get; set; }

        }

        [HttpPost]
        [Autorizacija(studentskaSluzba: false, prodekan: false, dekan: false, studenti: true, nastavnici: false)]
        public ActionResult Snimi([FromBody] SnimiVM x)
        {
            var test = _dbContext.StudentTest
                .SingleOrDefault(t => t.ID == x.StudentTestID);

            if (test == null)
                return BadRequest();

            foreach (SnimiVM.SnimiPitanjaVM pVM in x.Pitanjas)
            {
                StudentTestPitanja? pEntity = _dbContext.StudentTestPitanja.Find(pVM.StudentTestPitanjaID);
                if (pEntity == null)
                    return BadRequest();

                if (pEntity.StudentTestID != test.ID)
                    return BadRequest();

                pEntity.OznaceniOdgovoriIDs = pVM.OznaceniOdgovoriIDs;
                pEntity.OstvareniBodovi = 0;
            }

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}