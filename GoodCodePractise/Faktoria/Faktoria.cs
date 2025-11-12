using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


//## Factory

//### Zadanie 1
//1.Stwórzy klasę Wojownik. Utwórz klasy dziedziczące Piechur, Strzelec, Konny.
//1. Stwórz klasę garnizon, która na podstawie nazwy profesji wyszkoli i zwróci nam obiekt odpowiedniego wojownika.
//1. Stwórz tablicę zawierającą 3 piechurów, 3 konnych i 4 strzelców.


namespace GoodCodePractise.Faktoria
{
    public interface IWojownik
    {
        public void KimJestes();
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
   
    class Strzelec: Wojownik, IWojownik
    {
        private int dystans_ataku = 14;
        public string DystansAtaku
        {
            get
            {
                return (this.dystans_ataku).ToString();
            }

            set
            {
                var wartosc = Convert.ToInt32(value);
                if (wartosc >= 0)
                {
                    this.dystans_ataku = wartosc;
                }
            }
        }
        private int czestotliwosc_na_min = 1;
        public string CzestotliwoscNaMin
        {
            get
            {
                return (this.czestotliwosc_na_min).ToString();
            }

            set
            {
               var wartosc = Convert.ToInt32(value);
                if (wartosc >= 0)
                {
                    this.czestotliwosc_na_min = wartosc;
                }
            }
        }
        public void KimJestes()
        {
            Console.WriteLine("Jesteś Strzelcem!");
        }
        public Strzelec(string imie, string wiek, string dystans_ataku, string czestotliwosc_na_min):base(imie, wiek)
        {
            DystansAtaku = dystans_ataku;
            CzestotliwoscNaMin = czestotliwosc_na_min;
        }
    }


    class Piechur : Wojownik, IWojownik
    {
        private bool bron_dluga;
        public string BronDluga{ 
            get{
                return( this.bron_dluga).ToString();
            }
            set{
                var wartosc = Convert.ToBoolean(value);
                this.bron_dluga = wartosc;
                }
        }
        private bool bron_krotka;
        public string BronKrotka {
            get
            {
                return (this.bron_krotka).ToString();
            }
            set
            {
                this.bron_krotka = Convert.ToBoolean(value);
            }
        }
        private bool tarcza;
        public string Tarcza
        {
            get
            {
                return (this.tarcza).ToString();
            }
            set
            {
                var wartosc = Convert.ToBoolean(value);
                this.tarcza = wartosc;
            }
        }
        public void KimJestes()
        {
            Console.WriteLine("Jesteś piechurem!");
        }
        public Piechur(string imie, string wiek, string tarcza, string bron_dluga, string bron_krotka):base(imie, wiek)
        {
            this.Tarcza = tarcza;
            this.BronDluga = bron_dluga;
            this.BronKrotka = bron_krotka;
        }
    }
    class Konny : Wojownik, IWojownik
    {
        private double predkosc_poruszania = 1.2;
        public string PredkoscPoruszania
        {
            get
            {
                return (this.predkosc_poruszania).ToString();
            }
            set
            {
                var wartosc = Convert.ToDouble(value);
                if (wartosc > 0)
                {
                    this.predkosc_poruszania = wartosc;
                }
            }
        }
        private bool gieremek = true;
        public string Gieremek
        {
            get
            {

                return (this.gieremek).ToString();
            }
            set
            {
                this.gieremek = Convert.ToBoolean(value);
            }
        }
        public void KimJestes()
        {
            Console.WriteLine("Jesteś konnicą!");
        }

        public Konny(string imie, string wiek, string gieremek, string predkosc) :base(imie, wiek)
        {
            this.Gieremek = gieremek;
            this.PredkoscPoruszania = predkosc;
        }

    }
    public static class Garnizon
    {
        public static IWojownik CreateWojownik(Dictionary<string, string> wojownik )
        {
            //foreach (var wojownik in woj)
            //{
                if (wojownik.ContainsKey("dystans") && wojownik.ContainsKey("czestotliwosc"))
                {
                    Strzelec o = new Strzelec(wojownik["imie"], wojownik["wiek"], wojownik["dystans"], wojownik["czestotliwosc"]);
                    return o;

                }
                else if (wojownik.ContainsKey("tarcza") && wojownik.ContainsKey("bron_krotka") && wojownik.ContainsKey("bron_dluga"))
                {
                    Piechur p = new Piechur(wojownik["imie"], wojownik["wiek"], wojownik["tarcza"], wojownik["bron_krotka"], wojownik["bron_dluga"]);
                    return p;
            }
                else if (wojownik.ContainsKey("PredkoscPoruszania") && wojownik.ContainsKey("gieremek"))
                {
                    Konny k = new Konny(wojownik["imie"], wojownik["wiek"], wojownik["gieremek"], wojownik["PredkoscPoruszania"]);
                    return k;
            }
                else
                {
                    Console.WriteLine(wojownik);                
                    throw new Exception("Nie mamy takiego wojownika w garnizonie");
                }
            //}

        }
    }
    //Strzelec, Konny

}
