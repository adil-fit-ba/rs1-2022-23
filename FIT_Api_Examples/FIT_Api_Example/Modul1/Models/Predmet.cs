using System.ComponentModel.DataAnnotations;
using FIT_Api_Example.Modul2.Models;

namespace FIT_Api_Example.Modul1.Models
{
    public class Predmet
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }   
        public string Sifra { get; set; }   
        public int Ects { get; set; }

    }
}
