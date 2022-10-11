using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul2.Models
{
    public class Opstina
    { 
        [Key]
        public int id { get; set; }
        public string description { get; set; }
        [ForeignKey(nameof(drzava))]
        public int drzava_id { get; set; }
        public Drzava drzava { get; set; }
    }
}
