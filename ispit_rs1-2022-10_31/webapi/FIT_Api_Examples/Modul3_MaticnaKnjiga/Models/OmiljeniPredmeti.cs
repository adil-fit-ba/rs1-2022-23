using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;

namespace FIT_Api_Examples.Modul2.Models
{
    public class OmiljeniPredmeti
    {

        [Key]
        public int id { get; set; }



        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }
        public Student Student { get; set; }

       

        [ForeignKey(nameof(Predmet))]
        public int PredmetID { get; set; }
        public Predmet Predmet { get; set; }

    }
}
