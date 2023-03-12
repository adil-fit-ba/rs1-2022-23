using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul4_SignalRDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestirajSignalRController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<PorukeHub> _porukeHub;

        public TestirajSignalRController(ApplicationDbContext dbContext, IHubContext<PorukeHub> porukeHub)
        {
            this._dbContext = dbContext;
            _porukeHub = porukeHub;
        }
      

        [HttpGet]
        public async Task<ActionResult> PosaljiTrenutnoVrijeme()
        {
            string p = "Trenutno vrijeme je " + DateTime.Now;
            await _porukeHub.Clients.All.SendAsync("slanje_poruke1", p);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> PosaljiPoruku(string p)
        {
            await _porukeHub.Clients.All.SendAsync("slanje_poruke2", p);

            return Ok();
        }

    }
}
