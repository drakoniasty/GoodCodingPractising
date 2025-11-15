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
        public IWojownik Wojownik { get; set; }
        public abstract void Krok1(Dictionary<string, string> dane);

        public abstract void Krok2();

        public abstract void Krok3();
    }
    public class PiechurBuilder:WarriorBuilder
    {
        public override void Krok1(Dictionary<string, string> dane)
        {
            Wojownik = new Piechur(dane["imie"], dane["wiek"], dane["tarcza"], dane["bron_krotka"], dane["bron_dluga"]);
            Console.WriteLine("Zaciągnąłeś się do armii!");
        }

        public override void Krok2()
        {
            Wojownik.Bron = "tarcza";
            Console.WriteLine("Pobieram broń tarczę!");
        }

        public override void Krok3()
        {
            Console.WriteLine("Zaczynam trening z tarczą");
        }
        //public PiechurBuilder()
        //{
        //    Krok1();
        //    Krok2();
        //    Krok3();
        //}
        //public  IWojownik StworzWoja(Dictionary<string, string>dane)
        //{
        //    if(dane.ContainsKey("tarcza") && dane.ContainsKey("bron_krotka") && dane.ContainsKey("bron_dluga"))
        //        {
        //        Piechur p = new Piechur(dane["imie"], dane["wiek"], dane["tarcza"], dane["bron_krotka"], dane["bron_dluga"]);
        //        return p;
        //    }


        //    else
        //    {
        //        Console.WriteLine(dane);
        //        throw new Exception("Nie mamy takiego wojownika w garnizonie");
        //    }
        //}
    }
    public class StrzelecBuilder:WarriorBuilder
    {
        public override void Krok1(Dictionary<string, string> dane)
        {
            Console.WriteLine("Zaciągnąłeś się do armii!");
            Wojownik = new Strzelec(dane["imie"], dane["wiek"], dane["dystans"], dane["czestotliwosc"]);
        }

        public override void Krok2()
        {
            Wojownik.Bron = "łuk";
            Console.WriteLine("Pobieram broń łuk!");
        }

        public override void Krok3()
        {
            Console.WriteLine("Zaczynam trening strzelecki");
        }
        //public static IWojownik StworzWoja(Dictionary<string, string> dane)
        //{

        //    if (dane.ContainsKey("dystans") && dane.ContainsKey("czestotliwosc"))
        //    {
        //        Strzelec o = new Strzelec(dane["imie"], dane["wiek"], dane["dystans"], dane["czestotliwosc"]);
        //        return o;

        //    }

        //    else
        //    {
        //        Console.WriteLine(dane);
        //        throw new Exception("Nie mamy takiego wojownika w garnizonie");
        //    }
        //}
    }
    class KonnyBuilder:WarriorBuilder
    {
        public override void Krok1(Dictionary<string, string> dane)
        {
            Console.WriteLine("Zaciągnąłeś się do armii!");
            Wojownik = new Konny(dane["imie"], dane["wiek"], dane["gieremek"], dane["PredkoscPoruszania"]);
        }

        public override void Krok2()
        {
            Wojownik.Bron = "koń";
            Console.WriteLine("Pobieram broń koń!");
        }

        public override void Krok3()
        {
            Console.WriteLine("Zaczynam trening jeździecki");
        }
        //public static IWojownik StworzWoja(Dictionary<string, string> dane)
        //{

        //    if (dane.ContainsKey("PredkoscPoruszania") && dane.ContainsKey("gieremek"))
        //    {
        //        Konny k = new Konny(dane["imie"], dane["wiek"], dane["gieremek"], dane["PredkoscPoruszania"]);
        //        return k;
        //    }

        //    else
        //    {
        //        Console.WriteLine(dane);
        //        throw new Exception("Nie mamy takiego wojownika w garnizonie");
        //    }
        //}
    }

}
