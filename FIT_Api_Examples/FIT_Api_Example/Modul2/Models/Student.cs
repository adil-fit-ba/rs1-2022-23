using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul2.Models
{
    public class Student
    { 
        [Key]
        public int id { get; set; }
        public string ime { get; set; }
        public string  prezime{ get; set; }
        public string broj_indeksa { get; set; }
        [ForeignKey(nameof(opstina_rodjenja))]
        public int? opstina_rodjenja_id { get; set; }
        public Opstina opstina_rodjenja { get; set; }
        public DateTime? datum_rodjenja { get; set; }
        public DateTime created_time { get; set; }
        public string slika_studenta { get; set; }
    }
}
