namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class StudentGetAllVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public int? opstina_rodjenja_id { get; set; }
        public string? opstina_rodjenja_opis { get; set; }
        public string broj_indeksa { get; set; }
        public string drzava_rodjenja_opis { get; set; }
        public string vrijeme_dodavanja { get; set; }
        public string? slika_korisnika_nova_base64 { get;  set; }

        public byte[]? slika_korisnika_postojeca_base64_DB { get; set; }
        public byte[]? slika_korisnika_postojeca_base64_FS { get; set; }
    }
}
