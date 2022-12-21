using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class OpstinaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public OpstinaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Opstina> Add([FromBody] OpstinaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var opstina = new Opstina
            {
                description = x.opis,
                drzava_id = x.drzava_id,
            };

            _dbContext.Add(opstina);
            _dbContext.SaveChanges();
            return opstina;
        }

        [HttpGet]
        public ActionResult GetByDrzava(int drzava_id)
        {
            var data = _dbContext.Opstina.Where(x => x.drzava_id == drzava_id)
                .OrderBy(s => s.description)
                .Select(s => new {
                    id = s.id,
                    opis = s.drzava.naziv + " - " + s.description,
                })
                .ToList();
            return Ok(data);
        }

        [HttpGet]
        public ActionResult GetByAll()
        {
            var data = _dbContext.Opstina
                .OrderBy(s => s.description)
                .Select(s => new 
                {
                    id = s.id,
                    opis = s.drzava.naziv + " - " + s.description,
                })
                .ToList();
            return Ok(data);
        }
    }
}
