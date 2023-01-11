using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace FIT_Api_Examples.Modul5_OnlineTestovi.Models
{
    public class StudentTestPitanja
    {
        public int ID { get; set; }

        [ForeignKey(nameof(StudentTestID))]
        public virtual StudentTest StudentTest { get; set; } = null!;
        public int StudentTestID { get; set; }


        [ForeignKey(nameof(PitanjeID))]
        public virtual Pitanje Pitanje { get; set; } = null!;
        public int PitanjeID { get; set; }

        public float MaxBodovi { get; set; }
        public float OstvareniBodovi { get; set; }

        
        [JsonIgnore]
        public string? OznaceniOdgovoriIDsString { get; set; }

        [NotMapped]
        public List<int> OznaceniOdgovoriIDs { 
            get => JsonSerializer.Deserialize<List<int>>(OznaceniOdgovoriIDsString??"[]")??new List<int>();
            set => OznaceniOdgovoriIDsString = JsonSerializer.Serialize(value);
        }

       // public virtual List<PitanjaPonudjeneOpcije> OznaceniOdgovoriIDs { get; set; } = new();

    }
}
