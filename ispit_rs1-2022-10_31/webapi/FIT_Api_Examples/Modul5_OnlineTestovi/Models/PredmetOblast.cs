using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class PredmetOblast
    {
        public int ID { get; set; }
        public string Naziv { get; set; } = string.Empty;

        [ForeignKey(nameof(PredmetID))]
        public Predmet Predmet { get; set; } = null!;
        public int PredmetID { get; set; }




    }
}
