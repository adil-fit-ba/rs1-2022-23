﻿namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class StudentGetAllVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public int? opstina_rodjenja_id { get; set; }
        public string opstina_rodjenja_opis { get; set; }
        public string broj_indeksa { get; set; }
        public string drzava_rodjenja_opis { get; set; }
        public string vrijeme_dodavanja { get; set; }
    }
}
