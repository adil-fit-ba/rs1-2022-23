namespace FIT_Api_Examples.Modul5_OnlineTestovi.ViewModels
{
    public class StudentTestPitanjaSnimiVM
    {
        public class SnimiPitanjaVM
        {
            public int StudentTestPitanjaID { get; set; }
            public List<int> OznaceniOdgovoriIDs { get; set; }

        }
        public int StudentTestID { get; set; }
        public List<SnimiPitanjaVM> Pitanjas { get; set; }

    }
}
