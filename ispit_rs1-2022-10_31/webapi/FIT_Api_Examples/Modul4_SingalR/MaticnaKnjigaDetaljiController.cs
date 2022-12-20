using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Hubs;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PosaljiPorukuController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<FeedHub> _feedHub;

        public PosaljiPorukuController(ApplicationDbContext dbContext, IHubContext<FeedHub> feedHub)
        {
            this._dbContext = dbContext;
            this._feedHub = feedHub;
        }


        [HttpGet]
        public async Task<ActionResult> PosaljiVrijeme()
        {
            await _feedHub.Clients.All.SendAsync($"slanje_poruke1", $"Vrijeme je {DateTime.Now}");


            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> PosaljiPoruku(string p)
        {
            await _feedHub.Clients.All.SendAsync($"slanje_poruke2", "p = " + p);


            return Ok();
        }
    }
}