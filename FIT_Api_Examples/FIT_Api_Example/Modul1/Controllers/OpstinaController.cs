using FIT_Api_Example.Data;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul1.Controllers
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
        public Opstina Add([FromBody] OpstinaAddVM x)
        {
            var newEmployee = new Opstina
            {
                description = x.opis,
                DrzavaID = x.drzava_id,
            };

            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        [HttpGet]
        public ActionResult GetByDrzava(int drzava_id)
        {
            var data = _dbContext.Opstina.Where(x => x.DrzavaID == drzava_id)
                .OrderBy(s => s.description)
                .Select(s => new 
                {
                    id = s.ID,
                    opis = s.drzava.Naziv + " - " + s.description,
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }

        [HttpGet]
        public ActionResult GetByAll()
        {
            var data = _dbContext.Opstina
                .OrderBy(s => s.description)
                .Select(s => new 
                {
                    id = s.ID,
                    opis = s.drzava.Naziv + " - " + s.description,
                })
                .AsQueryable();
            return Ok(data.Take(100).ToList());
        }
    }
}
