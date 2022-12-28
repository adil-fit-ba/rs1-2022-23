using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PredmetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PredmetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }



        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Predmet
                .OrderBy(s => s.Naziv)
                .Select(s => new 
                {
                    id = s.ID,
                    opis = s.Naziv,
                })
                .ToList();
            return Ok(data);
        }
    }
}
