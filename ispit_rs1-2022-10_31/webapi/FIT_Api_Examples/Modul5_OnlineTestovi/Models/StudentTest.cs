using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class StudentTest
    {
        public int ID { get; set; }


        [ForeignKey(nameof(AktivacijaTestaID))]
        public virtual AktivacijaTesta AktivacijaTesta { get; set; } = null!;
        public int AktivacijaTestaID { get; set; }


        [ForeignKey(nameof(StudentID))]
        public virtual Student Student { get; set; } = null!;
        public int StudentID { get; set; }

        public DateTime TestPokrenutVrijeme { get; set; }
        public DateTime? TestZavrsenoVrijeme { get; set; }
        public float? Uspjeh { get; set; }

    }
}
