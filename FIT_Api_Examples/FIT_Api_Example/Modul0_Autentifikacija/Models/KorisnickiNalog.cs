using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FIT_Api_Example.Modul1.Models;

namespace FIT_Api_Example.Modul0_Autentifikacija.Models
{
    [Table("KorisnickiNalog")]
    public class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        [JsonIgnore]
        public string Lozinka { get; set; }
        public string SlikaKorisnika { get; set; }

        [JsonIgnore]
        public Student? Student => this as Student;

        [JsonIgnore]
        public Nastavnik? Nastavnik => this as Nastavnik;
        public bool isNastavnik => Nastavnik != null;
        public bool isStudent => Student != null;
        public bool isAdmin { get; set; }
        public bool isProdekan { get; set; }
        public bool isDekan { get; set; }
        public bool isStudentskaSluzba { get; set; }
        
 
    }
}
