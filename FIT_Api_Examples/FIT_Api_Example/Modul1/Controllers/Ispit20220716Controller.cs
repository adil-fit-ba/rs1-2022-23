using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FIT_Api_Examples.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ispit20220716Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20220716Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public class Destinacija2VM
        {
            public string Mjesto { get; set; }
            public string ImageUrl { get; set; }
            public double CijenaDolar { get; set; }
            public string Opis { get; set; }
            public List<string> Opcije { get; set; }


        }

        private List<Destinacija2VM> listDestinacije => new List<Destinacija2VM>
        {
            new Destinacija2VM
            {
                Mjesto="Turska: Istanbul + Ankara",
                CijenaDolar=2000,
                Opis="21.06.2022. - 5 dana - Hotel ***"     ,
                Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-01.jpg"
            } ,

            new Destinacija2VM
            {
                Mjesto="Španija: Madrid",
                CijenaDolar=3000,
                Opis="29.06.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-02.jpg"
            } ,

            new Destinacija2VM
            {
                Mjesto="Velika Britanija: London",
                CijenaDolar=5000,
                Opis="27.06.2022. - 5 dana - Hotel ****"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-03.jpg"
            } ,
                        new Destinacija2VM
            {
                Mjesto="Eastern Europe: ",
                CijenaDolar=2000,
                Opis="21.09.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-04.jpg"
            } ,
                                    new Destinacija2VM
            {
                Mjesto="Italija",
                CijenaDolar=2000,
                Opis="04.07.2022. - 3 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-05.jpg"
            } ,
                                                new Destinacija2VM
            {
                Mjesto="Švicarske alpe",
                CijenaDolar=5100,
                Opis="05.07.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-06.jpg"
            } ,

                                                  new Destinacija2VM
            {
                Mjesto="Turska: Ankara",
                CijenaDolar=2000,
                Opis="21.07.2022. - 5 dana - Hotel ****"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-01.jpg"
            } ,

            new Destinacija2VM
            {
                Mjesto="Španija i Portugal",
                CijenaDolar=2800,
                Opis="29.07.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-02.jpg"
            } ,

            new Destinacija2VM
            {
                Mjesto="United Kingdom: London",
                CijenaDolar=5000,
                Opis="27.08.2022. - 8 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-03.jpg"
            } ,
                        new Destinacija2VM
            {
                Mjesto="Bosnia and Hercegovina: Mostar",
                CijenaDolar=2000,
                Opis="21.09.2022. - 4 dana - Hotel ****"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-Mostar.jpg"
            } ,
                                    new Destinacija2VM
            {
                Mjesto="Italija i Hrvatska",
                CijenaDolar=2000,
                Opis="04.07.2022. - 3 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-05.jpg"
            } ,
                                                new Destinacija2VM
            {
                Mjesto="Swiss Alps :-)",
                CijenaDolar=5100,
                Opis="05.07.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-06.jpg"
            }
        };

        private List<string> GetOpcije()
        {
            return Helper.Data.opcije.GetRandomElements(4).OrderBy(a=>a).ToList();
        }

        [HttpGet]
        public object Get6Ponuda()
        {
            return new
            {
                datumPonude = DateTime.Now.ToString("g"),
                podaci = listDestinacije.GetRandomElements(6)
            };
        }

        public class Ispit20220716Posalji
        {
            public string DestinacijaSoba { get; set; }
            public string ImeGosta { get; set; }
            public string PrezimeGosta { get; set; }
            public string Poruka { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
        }


        [HttpPost]
        public ActionResult Add([FromBody] Ispit20220716Posalji x)
        {
            if (string.IsNullOrEmpty(x.Email) )
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Email",
                    Vrijeme = DateTime.Now,
                    BrojRezervacije = ""
                });

            if ( string.IsNullOrEmpty(x.Telefon))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Telefon",
                    Vrijeme = DateTime.Now,
                    BrojRezervacije = ""
                });

            if (string.IsNullOrEmpty(x.ImeGosta) || string.IsNullOrEmpty(x.PrezimeGosta) )
                return Ok(new
                {
                    poruka = "Podaci su neispravni: ImeGosta ili PrezimeGosta",
                    Vrijeme = DateTime.Now,
                    BrojRezervacije = ""
                });

            return Ok( new
            {
                poruka = "Uspjesno evidentirana",
                Vrijeme = DateTime.Now,
                BrojRezervacije = Class.RandomString(5)
            });
        }



       
    }
}
