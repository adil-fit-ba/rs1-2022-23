using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrzavaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DrzavaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public Drzava Snimi([FromBody] DrzavaSnimiVM x)
        {
            Drzava? objekat;

            if (x.id == 0)
            {
                objekat = new Drzava();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Drzava.Find(x.id);
            }

            objekat.naziv = x.naziv;
            objekat.skrecenica = x.skracenica;

            _dbContext.SaveChanges();
            return objekat;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Drzava
                .OrderBy(s => s.naziv)
                .Select(s => new DrzavaGetAllVM()
                {
                    id = s.id,
                    skracenica = s.skrecenica,
                    naziv = s.naziv,
                })
                .Take(100);
            return Ok(data.ToList());
        }
    }

   
}
