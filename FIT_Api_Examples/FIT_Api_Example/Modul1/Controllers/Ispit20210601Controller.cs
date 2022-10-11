using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Modul1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ispit20210601Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20210601Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public Ispit20210601Posalji Add([FromBody] Ispit20210601Posalji x)
        {
            var novi = new Ispit20210601Posalji
            {
                Ime = x.Ime,
                Adresa = x.Adresa,
                Grad = x.Grad,
                LicniBrojKupca = x.LicniBrojKupca,
                Upit = x.Upit,
            };
            _dbContext.Add(novi);
            _dbContext.SaveChanges();

            return novi;
        }

        [HttpGet]
        public List<Ispit20210601Posalji> Get()
        {
            return _dbContext.Ispit20210601Posalji.OrderByDescending(s=>s.ID).Take(50).ToList();
        }

    }
}
