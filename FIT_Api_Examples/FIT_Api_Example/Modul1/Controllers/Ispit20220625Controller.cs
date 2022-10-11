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
    public class Ispit20220625Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20220625Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        
        [HttpGet]
        public List<DestinacijaVM> Get6Ponuda()
        {
            return Helper.Data.listDestinacije.GetRandomElements(6);
        }

        public class Ispit20220625Posalji
        {
            public string DestinacijaID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Poruka { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
        }


        [HttpPost]
        public ActionResult Add([FromBody] Ispit20220625Posalji x)
        {

            return Ok( new
            {
                poruka = "Uspjesno evidentirana",
                Vrijeme = DateTime.Now,
                BrojRezervacije = Class.RandomString(5)
            });
        }



       
    }
}
