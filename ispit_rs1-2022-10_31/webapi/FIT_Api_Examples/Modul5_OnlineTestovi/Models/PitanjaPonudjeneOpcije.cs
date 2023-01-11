using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class PitanjaPonudjeneOpcije
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        [ForeignKey(nameof(PitanjeID))]
        [JsonIgnore]
        public virtual Pitanje Pitanje { get; set; } = null!;
        public int PitanjeID { get; set; }
        [JsonIgnore]
        public bool JelTacno { get; set; }
    }
}
