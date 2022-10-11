using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Api_Examples.Helper
{
    public class Student4VM
    {
        public string ImePrezime { get; set; }
        public string RadnoMjesto { get; set; }
        public string Opis { get; set; }
        public string SlikaPutanja { get; set; }
        public string ID { get; set; }
    }

    public class DestinacijaVM
    {
        public int ID { get; set; }
        public string Drzava { get; set; }
        public string SlikaUrl { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public string Firma{ get; set; }
    }
    public class Data
    {
        public static List<DestinacijaVM> listDestinacije => new List<DestinacijaVM>
        {
            new DestinacijaVM
            {
                ID=1,
                Drzava="Turska: Istanbul + Ankara",
                Cijena=2000,
                Opis="21.06.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-01.jpg"
            } ,

            new DestinacijaVM
            {
                ID=2,
                Drzava="Španija: Madrid",
                Cijena=3000,
                Opis="29.06.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-02.jpg"
            } ,

            new DestinacijaVM
            {
                ID=3,
                Drzava="Velika Britanija: London",
                Cijena=5000,
                Opis="27.06.2022. - 5 dana - Hotel ****"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-03.jpg"
            } ,
                        new DestinacijaVM
            {
                ID=4,
                Drzava="Eastern Europe: ",
                Cijena=2000,
                Opis="21.09.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-04.jpg"
            } ,
                                    new DestinacijaVM
            {
                ID=5,
                Drzava="Italija",
                Cijena=2000,
                Opis="04.07.2022. - 3 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-05.jpg"
            } ,
                                                new DestinacijaVM
            {
                ID=6,
                Drzava="Švicarske alpe",
                Cijena=5100,
                Opis="05.07.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-06.jpg"
            } ,

                                                  new DestinacijaVM
            {
                ID=7,
                Drzava="Turska: Ankara",
                Cijena=2000,
                Opis="21.07.2022. - 5 dana - Hotel ****"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-01.jpg"
            } ,

            new DestinacijaVM
            {
                ID=8,
                Drzava="Španija i Portugal",
                Cijena=2800,
                Opis="29.07.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-02.jpg"
            } ,

            new DestinacijaVM
            {
                ID=9,
                Drzava="United Kingdom: London",
                Cijena=5000,
                Opis="27.08.2022. - 8 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-03.jpg"
            } ,
                        new DestinacijaVM
            {
                ID=10,
                Drzava="Bosnia and Hercegovina: Mostar",
                Cijena=2000,
                Opis="21.09.2022. - 4 dana - Hotel ****"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-Mostar.jpg"
            } ,
                                    new DestinacijaVM
            {
                ID=11,
                Drzava="Italija i Hrvatska",
                Cijena=2000,
                Opis="04.07.2022. - 3 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-05.jpg"
            } ,
                                                new DestinacijaVM
            {
                ID=12,
                Drzava="Swiss Alps :-)",
                Cijena=5100,
                Opis="05.07.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl="https://restapiexample.wrd.app.fit.ba/destinacije/box-offer-06.jpg"
            }
        };
        public static List<Student4VM> listRadnici => new List<Student4VM>
            {
                new Student4VM
                {   ID = "1",
                    ImePrezime = "Radnik 00001",
                    RadnoMjesto = "Programiranje",
                    Opis = "Phasellus 1 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team2.png"
                }  ,
                new Student4VM
                {   ID = "2",
                    ImePrezime = "Radnik 00002",
                    RadnoMjesto = "Programiranje",
                    Opis = "Phasellus 2 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team3.png"
                },
                new Student4VM
                {   ID = "3",
                    ImePrezime = "Radnik 00003",
                    RadnoMjesto = "Programiranje",
                    Opis = "Phasellus 3 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team4.png"
                },
                new Student4VM
                {   ID = "4",
                    ImePrezime = "Radnik 00004",
                    RadnoMjesto = "Programiranje",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team1.png"
                }
                ,
                new Student4VM
                {   ID = "5",
                    ImePrezime = "Radnik 00005",
                    RadnoMjesto = "Web development",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team5.png"
                },
                new Student4VM
                {   ID = "6",
                    ImePrezime = "Radnik 00006",
                    RadnoMjesto = "Web development",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team6.png"
                },
                new Student4VM
                {   ID = "7",
                    ImePrezime = "Radnik 00007",
                    RadnoMjesto = "Web development",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team7.png"
                },
                new Student4VM
                {   ID = "8",
                    ImePrezime = "Radnik 00008",
                    RadnoMjesto = "Web development",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team8.png"
                }
                ,
                new Student4VM
                {   ID = "9",
                    ImePrezime = "Radnik 00009",
                    RadnoMjesto = "Web design",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team9.png"
                },
                new Student4VM
                {   ID = "10",
                    ImePrezime = "Radnik 00010",
                    RadnoMjesto = "Web design",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team10.png"
                },
                new Student4VM
                {   ID = "11",
                    ImePrezime = "Radnik 00011",
                    RadnoMjesto = "Web design",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team11.png"
                },
                new Student4VM
                {   ID = "12",
                    ImePrezime = "Radnik 00012",
                    RadnoMjesto = "Web design",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team12.png"
                }
            };

        public static List<string> opcije
        {
            get
            {
                List<string> a = new List<string>();

                a.Add("Soba 1: krevet 1 + 3");
                a.Add("Soba 2: krevet 2 + 2");
                a.Add("Soba 3: krevet 1 + 1");
                a.Add("Soba 4: krevet 1 + 3, balkon");
                a.Add("Soba 5: krevet 3 + 3");
                a.Add("Soba 6: krevet 2 + 3");
                a.Add("Soba 7: krevet 2 + 3");
                a.Add("Soba 8: krevet 3 + 3");

                return a;
            }
        }
    }
}
