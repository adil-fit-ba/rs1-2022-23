using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Helper
{
    public class EmailLog
    {
        public static void uspjesnoLogiranKorisnik(KorisnickiNalog logiraniKorisnik, HttpContext httpContext)
        {
            if (logiraniKorisnik.isNastavnik)
            {
                EmailSender.Posalji(logiraniKorisnik.email, "Logiran korisnik", $"Login info {DateTime.Now}");
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
                EmailSender.Posalji(nastavnik.email, "Aktivacija korisnika", poruka, true);

            }
        }
    }
}
