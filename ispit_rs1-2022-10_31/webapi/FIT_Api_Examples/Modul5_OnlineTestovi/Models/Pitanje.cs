using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public enum TipPitanja
    {
        SCMA, MCMA
    }
    public class Pitanje
    {
        public int ID { get; set; }

        [ForeignKey(nameof(PredmetOblastID))]
        public virtual PredmetOblast PredmetOblast { get; set; } = null!;
        public int PredmetOblastID { get; set; }

        public string TekstPitanja { get; set; } = string.Empty;
        public int BodoviPozitivni{ get; set; }
        public int BodoviNegativni{ get; set; }
        public bool ParcijalnoBodovanje { get; set; }
        public TipPitanja TipPitanja { get; set; }

        public virtual List<PitanjaPonudjeneOpcije> PitanjaPonudjeneOpcijes { get; set; } = null!;
    }
}
