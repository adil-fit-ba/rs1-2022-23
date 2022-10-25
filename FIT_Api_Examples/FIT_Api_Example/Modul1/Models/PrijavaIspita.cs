using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Example.Modul2.Models;

namespace FIT_Api_Example.Modul1.Models
{
    public class PrijavaIspita
    {      

        [Key]
        public int ID { get; set; }

        public DateTime DatumPrijave { get; set; }

        [ForeignKey("IspitID")]//opcionalno --- strogo preporuceno
        public Ispit Ispit{ get; set; }
        public int IspitID { get; set; }


        [ForeignKey("StudentID")]//opcionalno --- strogo preporuceno
        public Student Student { get; set; }
        public int StudentID { get; set; }
    }
}
