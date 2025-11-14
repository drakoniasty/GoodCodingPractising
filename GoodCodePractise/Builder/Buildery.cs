using GoodCodePractise.Faktoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Builder
{
    public abstract class WarriorBuilder
    {
        public object objekt;
        void krok1()
        {
            Console.WriteLine("Zapisano do armii!");
        }
        void krok2()
        {
            Console.WriteLine("Pobranie broni...");
        }
        void krok3()
        {
            Console.WriteLine("Trening...");
        }
    }
    class PiechurBuilder:WarriorBuilder
    {
        public static IWojownik StworzWoja(Dictionary<string, string>dane)
        {
            if(dane.ContainsKey("tarcza") && dane.ContainsKey("bron_krotka") && dane.ContainsKey("bron_dluga"))
                {
                Piechur p = new Piechur(dane["imie"], dane["wiek"], dane["tarcza"], dane["bron_krotka"], dane["bron_dluga"]);
                return p;
            }


            else
            {
                Console.WriteLine(dane);
                throw new Exception("Nie mamy takiego wojownika w garnizonie");
            }
        }
    }
    class StrzelecBuilder:WarriorBuilder
    {
        public static IWojownik StworzWoja(Dictionary<string, string> dane)
        {

            if (dane.ContainsKey("dystans") && dane.ContainsKey("czestotliwosc"))
            {
                Strzelec o = new Strzelec(dane["imie"], dane["wiek"], dane["dystans"], dane["czestotliwosc"]);
                return o;

            }

            else
            {
                Console.WriteLine(dane);
                throw new Exception("Nie mamy takiego wojownika w garnizonie");
            }
        }
    }
    class KonnyBuilder:WarriorBuilder
    {
        public static IWojownik StworzWoja(Dictionary<string, string> dane)
        {

            if (dane.ContainsKey("PredkoscPoruszania") && dane.ContainsKey("gieremek"))
            {
                Konny k = new Konny(dane["imie"], dane["wiek"], dane["gieremek"], dane["PredkoscPoruszania"]);
                return k;
            }

            else
            {
                Console.WriteLine(dane);
                throw new Exception("Nie mamy takiego wojownika w garnizonie");
            }
        }
    }

}
