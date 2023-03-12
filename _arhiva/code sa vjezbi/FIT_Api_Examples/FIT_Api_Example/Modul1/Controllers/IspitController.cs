using FIT_Api_Example.Data;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class IspitController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public IspitController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

      
        [HttpPost]
        public Ispit Add([FromBody] IspitDodajVM x)
        {
            var ispit = new Ispit
            {
                Naziv = x.naziv,
                Datum = DateTime.Now,
                PredmetID = x.predmetid
            };

            _dbContext.Add(ispit);
            _dbContext.SaveChanges();
            return ispit;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Ispit
                .OrderBy(s => s.Datum)
                .Select(s => new 
                {
                    id = s.ID,
                    opis = s.Naziv + s.Predmet.Naziv,
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }
    }
}
