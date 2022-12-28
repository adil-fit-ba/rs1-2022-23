using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FIT_Api_Examples.Helper.AutentifikacijaAutorizacija
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool studentskaSluzba, bool prodekan, bool dekan, bool studenti, bool nastavnici)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { studentskaSluzba, prodekan, dekan, studenti, nastavnici };
        }
    }


    public class MyAuthorizeImpl : IActionFilter
    {
        private readonly bool _studentskaSluzba;
        private readonly bool _prodekan;
        private readonly bool _dekan;
        private readonly bool _studenti;
        private readonly bool _nastavnici;

        public MyAuthorizeImpl(bool studentskaSluzba, bool prodekan, bool dekan, bool studenti, bool nastavnici)
        {
            _studentskaSluzba = studentskaSluzba;
            _prodekan = prodekan;
            _dekan = dekan;
            _studenti = studenti;
            _nastavnici = nastavnici;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            KretanjePoSistemu.Save(filterContext.HttpContext);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MyAuthTokenExtension.LoginInformacije loginInfo = filterContext.HttpContext.GetLoginInfo();
            if (!loginInfo.isLogiran || loginInfo.korisnickiNalog == null)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            if (!loginInfo.korisnickiNalog.isAktiviran)
            {
                filterContext.Result = new UnauthorizedObjectResult("korisnik nije aktiviran - provjerite email poruke " + loginInfo.korisnickiNalog.email);
                return;
            }


            if (loginInfo.korisnickiNalog.isAdmin)
            {
                return;//ok - ima pravo pristupa
            }

            if (loginInfo.korisnickiNalog.isNastavnik && _nastavnici)
            {
                return;//ok - ima pravo pristupa
            }
            if (loginInfo.korisnickiNalog.isStudent && _studenti)
            {
                return;//ok - ima pravo pristupa
            }

            if (loginInfo.korisnickiNalog.isDekan && _dekan)
            {
                return;//ok - ima pravo pristupa
            }

            if ((loginInfo.korisnickiNalog.isProdekan || loginInfo.korisnickiNalog.isDekan) && _prodekan)
            {
                return;//ok - ima pravo pristupa
            }
            if ((loginInfo.korisnickiNalog.isStudentskaSluzba || loginInfo.korisnickiNalog.isDekan || loginInfo.korisnickiNalog.isProdekan) && _studentskaSluzba)
            {
                return;//ok - ima pravo pristupa
            }


            //else nema pravo pristupa
            filterContext.Result = new UnauthorizedResult();
        }
    }
}
