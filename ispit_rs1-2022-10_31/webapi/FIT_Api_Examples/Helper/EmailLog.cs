using AutoMapper.QueryableExtensions;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Helper
{
    public class EmailLog
    {
        public static void uspjesnoLogiranKorisnik(AutentifikacijaToken token, HttpContext httpContext)
        {
            var logiraniKorisnik = token.korisnickiNalog;
            if (logiraniKorisnik.isNastavnik ||logiraniKorisnik.isAdmin)
            {
                var poruka =  $"Postovani {logiraniKorisnik.korisnickoIme}, <br> " +
                              $"Code za 2F je <br>" +
                              $"{token.twoFCode}<br>" +
                              $"Login info {DateTime.Now}";


                EmailSender.Posalji("jirawix168@tohup.com", "Code za 2F autorizaciju", poruka, true);
            }
        }

        public static void noviNastavnik(Nastavnik nastavnik, HttpContext httpContext)
        {
            if (!nastavnik.isAktiviran)
            {
                var Request = httpContext.Request;
                var location = $"{Request.Scheme}://{Request.Host}";
                

                string url = location +"/nastavnik/Aktivacija/" + nastavnik.aktivacijaGUID;
                string poruka = $"Postovani/a {nastavnik.ime}, <br> Link za aktivaciju <a href='{url}'>{url}</a>... {DateTime.Now}";
                EmailSender.Posalji("jirawix168@tohup.com", "Aktivacija korisnika", poruka, true);

            }
        }
    }
}
