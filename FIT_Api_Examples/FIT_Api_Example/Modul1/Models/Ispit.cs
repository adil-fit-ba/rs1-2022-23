using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.Models
{
    public class Ispit
    {      

        [Key]
        public int ID { get; set; }

        public DateTime Datum { get; set; }
        public string Naziv { get; set; }

        [ForeignKey("PredmetID")]//opcionalno --- strogo preporuceno
        public Predmet Predmet { get; set; }
        public int PredmetID { get; set; }
    }
}
