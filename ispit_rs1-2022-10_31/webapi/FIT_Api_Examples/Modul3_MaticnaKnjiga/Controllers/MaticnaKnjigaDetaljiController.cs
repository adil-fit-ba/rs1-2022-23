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

            Student s = _dbContext.Student.Find(studentid);

            List<UpisAkGodine> upisAkGodine= _dbContext.UpisAkGodine
                .Include(s=>s.akademskaGodina)
                .Include(s=>s.evidentiraoKorisnik)
                .Where(s => s.student_id == studentid).ToList();

            float cijenaSkolarine= upisAkGodine.Sum(s => s.cijenaSkolarine);

            return Ok(new
            {
                s,
                upisAkGodine,
                cijenaSkolarine
            });
        }
    }
}