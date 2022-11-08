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
        public Drzava Snimi([FromBody] DrzavaAddVM x)
        {
            Drzava? objekat;

            if (x.ID == 0)
            {
                objekat = new Drzava();
                _dbContext.Add(objekat);//priprema sql
            }
            else
            {
                objekat = _dbContext.Drzava.Find(x.ID);
            }

            objekat.naziv = x.opis;
            objekat.skrecenica = x.skrecenica;

            _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
            return objekat;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Drzava
                .OrderBy(s => s.naziv)
                .Select(s => new 
                {
                    id = s.id,
                    opis = s.naziv,
                    skrecenica = s.skrecenica,
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }
    }
}
