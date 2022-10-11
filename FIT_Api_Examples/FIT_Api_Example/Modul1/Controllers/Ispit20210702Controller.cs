using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Modul1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ispit20210702Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20210702Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        
        [HttpGet]
        public List<Student4VM> Get4Studenta()
        {
            return Helper.Data.listRadnici.GetRandomElements(4);
        }
        [HttpGet]
        public List<Student4VM> Get8Studenta()
        {
            return Helper.Data.listRadnici.GetRandomElements(8);
        }
        
        [HttpPost]
        public Ispit20210702Posalji Add([FromBody] Ispit20210702Posalji x)
        {
            var novi = new Ispit20210702Posalji
            {
                ImePrezime = x.ImePrezime,
                Naslov = x.Naslov,
                Poruka = x.Poruka,
                Telefon = x.Telefon,
          
                DatumVrijeme = DateTime.Now
            };
            _dbContext.Add(novi);
            _dbContext.SaveChanges();

            return novi;
        }

        [HttpGet]
        public List<Ispit20210702Posalji> Get()
        {
            return _dbContext.Ispit20210702Posalji.OrderByDescending(s => s.ID).Take(50).ToList();
        }
    }
}
