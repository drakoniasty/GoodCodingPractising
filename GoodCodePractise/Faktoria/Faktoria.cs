using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//## Factory

//### Zadanie 1
//1.Stwórzy klasę Wojownik. Utwórz klasy dziedziczące Piechur, Strzelec, Konny.
//1. Stwórz klasę garnizon, która na podstawie nazwy profesji wyszkoli i zwróci nam obiekt odpowiedniego wojownika.
//1. Stwórz tablicę zawierającą 3 piechurów, 3 konnych i 4 strzelców.


namespace GoodCodePractise.Faktoria
{
    class Garnizon
    {
        public Garnizon(List<Dictionary<string, string>> lista)
        {
            
            foreach (var wojownik in lista)
            {
                if(wojownik.ContainsKey("dystans") && wojownik.ContainsKey("czestotliwosc"))
                {

                }
                else if (wojownik.ContainsKey("tarcza") && wojownik.ContainsKey("bron_krotka") && wojownik.ContainsKey("bron_dluga")){

                }
                else if (wojownik.ContainsKey("predkosc_poruszania") && wojownik.ContainsKey("gieremek"))
                {

                }
                else
                {
                    throw new Exception("Nie mamy takiego wojownika w garnizonie");
                }
            }
            
        }
    }
    class Wojownik
    {
        private string imie = "";
        public string Imie { get
            {
                return this.imie;
            }
            set
            {
                this.imie = value;
            } 
        }
        
        private int wiek = 0;
        public string Wiek {
            get
            {
                return (this.wiek).ToString();
            }
            set
            {
                if (value.GetType() == typeof(string))
                {
                    try
                    {
                        
                        int w = Convert.ToInt32(value);
                        this.wiek = w;
                    }
                    catch
                    {
                        throw new Exception("Wiek musi być liczbą!!!");
                    }
                }
                else if (value.GetType() == typeof(int))
                {
                    this.wiek = Convert.ToInt32(value); 
                }
                else
                {
                    throw new Exception("Wiek musi być liczbą!!!");
                }
                //this.wiek = value;
            } 
        }
        public Wojownik(string imie, string wiek)
        {
            this.Imie = imie;
            this.Wiek = wiek;

        }
    }
   
    class Strzelec: Wojownik
    {
        private int dystans_ataku = 14;
        public int DystansAtaku
        {
            get
            {
                return this.dystans_ataku;
            }

            set
            {
                if (value >= 0)
                {
                    this.dystans_ataku = value;
                }
            }
        }
        private double czestotliwosc_na_min = 0.3;
        public double CzestotliwoscNaMin
        {
            get
            {
                return this.czestotliwosc_na_min;
            }

            set
            {
                if (value >= 0)
                {
                    this.czestotliwosc_na_min = value;
                }
            }
        }

        public Strzelec(string imie, string wiek, int dystans_ataku, double czestotliwosc_na_min):base(imie, wiek)
        {
            DystansAtaku = dystans_ataku;
            CzestotliwoscNaMin = czestotliwosc_na_min;
        }
    }


    class Piechur : Wojownik
    {
        private bool bron_dluga;
        public bool BronDluga{ 
            get{
                return this.bron_dluga;
            }
            set{
                this.BronDluga = value;
                }
        }
        private bool bron_krotka;
        public bool BronKrotka {
            get
            {
                return this.bron_krotka;
            }
            set
            {
                this.bron_krotka = value;
            }
        }
        private bool tarcza;
        public bool Tarcza { get; set; }
        public Piechur(string imie, int wiek, bool tarcza, bool bron_dluga, bool bron_krotka):base(imie, wiek)
        {
            this.Tarcza = tarcza;
            this.BronDluga = bron_dluga;
            this.BronKrotka = bron_krotka;
        }
    }
    class Konny : Wojownik
    {
        private double predkosc_poruszania = 1.2;
        public double PredkoscPoruszania
        {
            get
            {
                return this.predkosc_poruszania;
            }
            set
            {
                if (value > 0)
                {
                    this.predkosc_poruszania = value;
                }
            }
        }
        private bool gieremek = true;
        public bool Gieremek
        {
            get
            {
                return this.gieremek;
            }
            set
            {
                this.gieremek = value;
            }
        }

        public Konny(string imie, string wiek, double predkosc, bool gieremek):base(imie, wiek)
        {
            this.Gieremek = gieremek;
            this.PredkoscPoruszania = predkosc;
        }

    }
  //Strzelec, Konny


    internal class Faktoria
    {


        List<Dictionary<string, string>> obiekty_zewnetrzne = [
                    new Dictionary<string, string>{
                        { "imie", "Jan MęczyBuła" },
                        { "wiek", "34" },
                        { "dystans", "5" },
                        { "czestotliwosc", "0.34" },
                        
                    },
                    new Dictionary<string, string>{
                        { "imie", "Sara" },
                        { "wiek", "21" },
                        { "tarcza", "true" },
                        { "bron_dluga", "false" },
                        { "bron_krotka", "true" },
                    },
                    new Dictionary<string, string>{
                        { "imie", "Krzysztof" },
                        { "wiek", "25" },
                        { "wiek", "25" },
                        { "wiek", "25" },
                        { "wiek", "25" },
                    },
                  
            ];



    }
}
