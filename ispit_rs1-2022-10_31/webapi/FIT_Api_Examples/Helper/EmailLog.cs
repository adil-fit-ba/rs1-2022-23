using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Helper
{
    public class EmailLog
    {
        public static void uspjesnoLogiranKorisnik(AutentifikacijaToken t, HttpContext httpContext)
        {
            KorisnickiNalog k = t.korisnickiNalog;
            if (k.isNastavnik)
            {
                var Request = httpContext.Request;
                var location = $"{Request.Scheme}://{Request.Host}";
                string url = location + "/Autentifikacija/otkljucaj2fLong/" + t.twoFCodeLong;

                EmailSender.Posalji(k.email, "2f code ", $"Postovani {k.korisnickoIme}, <br> " +
                                                         $"Code za 2-faktor autorizaciju je <br>" +
                                                         $"{t.twoFCodeShort} <br><br> ili <br>" +
                                                         $"<a href='{url}'>{url}</a>" +

                                                         $"Login info {DateTime.Now}", true);
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
