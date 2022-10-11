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
    public class Ispit20210925Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20210925Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
       
        [HttpGet]
        public List<Student4VM> FindByExpertType(string type)
        {
            return Helper.Data.listRadnici.Where(s=> string.IsNullOrEmpty(type) || s.RadnoMjesto == type).ToList().GetRandomElements(4);
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
    }
}
