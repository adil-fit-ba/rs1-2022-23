namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class StudentGetAllVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public int? opstina_rodjenja_id { get; set; }
        public string opstina_rodjenja_opis { get; set; }
        public int prosjecnaOcjena { get; set; }
        public int brojPolozenihPredmta { get; set; }
        public string datum_dodavanja { get; set; }
    }
}
