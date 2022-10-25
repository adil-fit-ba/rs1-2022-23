using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
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

        public class IspitDodajVM
        {
            public string naziv { get; set; }
            public int predmetid { get; set; }
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
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.Ispit
                .OrderBy(s => s.Datum)
                .Select(s => new CmbStavke()
                {
                    id = s.ID,
                    opis = s.Naziv + s.Predmet.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
