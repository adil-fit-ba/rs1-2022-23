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
    public class PredmetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PredmetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public class PredmetAddVM
        {
            public string sifraPredmeta { get; set; }
            public string nazivPredmeta { get; set; }
            public int ectsBodov { get; set; }
        }

        [HttpPost]
        public Predmet Add([FromBody] PredmetAddVM x)
        {
            var noviZapis = new Predmet
            {
                Naziv = x.nazivPredmeta,
                Sifra = x.sifraPredmeta,
                Ects = x.ectsBodov,
            };

            _dbContext.Add(noviZapis);//priprema sql
            _dbContext.SaveChanges();//exceute sql -- insert into Predmet
            return noviZapis;
        }



       

        [HttpGet]
        public List<PredmetGetAllVM> GetAll()
        {
            var pripremaUpita = _dbContext.Predmet
                .Where(p=>p.Naziv.StartsWith("A"))
                .OrderBy(p => p.Naziv)
                .ThenBy(p=>p.Sifra)
                .Take(100)
                .Select(p=>new PredmetGetAllVM
                {
                    ECTS = p.Ects,
                    Naziv = p.Naziv,
                    ProsjecnaOcjena = 0
                })
                ;


            return pripremaUpita
                .ToList(); //exceute sql -- select top 100 * from Predmet where naziv like 'A%' order by naziv, sifra
        }
    }
}
