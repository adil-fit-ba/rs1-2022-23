using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class AktivacijaTesta
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = String.Empty;
        public float TrajanjeMinute { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj{ get; set; }


        [ForeignKey(nameof(PredmetID))]
        public virtual Predmet Predmet { get; set; } = null!;
        public int PredmetID { get; set; }
    }
}
