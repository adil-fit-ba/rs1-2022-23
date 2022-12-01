using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;

namespace FIT_Api_Examples.Modul2.Models
{
    public class UpisAkGodine
    {

        [ForeignKey(nameof(evidentiraoKorisnik))]
        public int evidentiraoKorisnikID { get; set; }
        public KorisnickiNalog evidentiraoKorisnik { get; set; }

        [Key]
        public int id { get; set; }
        public DateTime datumUpisZimski { get; set; }

        public int godinastudina { get; set; }
        public float cijenaSkolarine{ get; set; }
        public bool jelObnova{ get; set; }


        [ForeignKey(nameof(akademskaGodina))]
        public int akademskaGodina_id { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }


        [ForeignKey(nameof(student))]
        public int student_id { get; set; }
        public Student student{ get; set; }
        public DateTime? datumOvjeraZimski { get; set; }
    }
}
