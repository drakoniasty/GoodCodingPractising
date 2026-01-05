using GoodCodePractise.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Bridge
{

    using System;

   

    // Implementor
    public interface IInsulina
    {
        void Zaaplikuj(double ilosc);
    }

    // ConcreteImplementor A
    public class PompaInsulinowa : IInsulina
    {
        public void Zaaplikuj(double ilosc)
        {
            Console.WriteLine(
                $"Podano {ilosc} jednostek insuliny za pomocą pompy insulinowej"
            );
        }
    }

    // ConcreteImplementor B
    public class Strzykawka : IInsulina
    {
        public void Zaaplikuj(double ilosc)
        {
            Console.WriteLine(
                $"Podano {ilosc} jednostek insuliny za pomocą strzykawki"
            );
        }
    }

    // Abstraction
    public abstract class TerapiaInsulinowa
    {
        protected IInsulina insulina;

        protected TerapiaInsulinowa(IInsulina insulina)
        {
            this.insulina = insulina;
        }

        public abstract void Podaj();
    }

    // RefinedAbstraction A
    public class Baza : TerapiaInsulinowa
    {
        public Baza(IInsulina insulina) : base(insulina) { }

        public override void Podaj()
        {
            insulina.Zaaplikuj(10.0);
        }
    }

    // RefinedAbstraction B
    public class Bolus : TerapiaInsulinowa
    {
        public Bolus(IInsulina insulina) : base(insulina) { }

        public override void Podaj()
        {
            insulina.Zaaplikuj(4.0);
        }
    }

  












    ///-----------------------TUTAJ PRÓBOWAŁEM ALE SIĘ NIE UDAŁO --------------------
    /// <summary>
    /// Implermentator określający interfejs pogody dla danego miasta
    /// </summary>
    public interface IPogodynka
    {
        void Pogoda(string miasto);
    }
    /// <summary>
    /// Abstrakcja dla prezentacji
    /// </summary>
    public abstract class Pogodynka
    {
        public IPogodynka pogoda;
        public abstract void DajPogode();
    }
    /// <summary>
    /// Przykładowa implementacja
    /// </summary>
    public class PogodaPrzyklad:Pogodynka
    {
        public override void DajPogode()
        {
            pogoda.Pogoda("Warszawa");
        }
    }
    public class PogodaMiasto : IPogodynka
    {
        public async void Pogoda(string miasto)
        {
            WeahterAdapter adapter = new WeahterAdapter(miasto);
            Dictionary<string, string> p = await adapter.RefreshDane();
            Console.WriteLine("Statystki dla miasta: " + miasto);
            foreach (KeyValuePair<string, string> para in p)
            {
                Console.WriteLine($"\"{para.Key}\" : \"{para.Value}\"");

            }

        }
    }

   public class PogodaMiastoCzas: IPogodynka
    {
        string __odczyt = "brak";
        WeahterAdapter adapter;
        public async void Pogoda(string miasto)
        {
            Console.WriteLine("Pogoda dla miasta: " + miasto);
            
            if (__odczyt == "brak")
            {
                adapter = new WeahterAdapter(miasto);
                Console.WriteLine("Ściągam dane");
                __odczyt = DateTime.Now.ToString();
                Dictionary<string, string> p = await adapter.RefreshDane();
                foreach (KeyValuePair<string, string> para in p)
                {
                    Console.WriteLine($"\"{para.Key}\" : \"{para.Value}\"");

                }
            }
            else
            {
                Console.WriteLine("Czas odczytu: " + __odczyt);
                Dictionary<string, string> p = adapter.GetDane();
                foreach (KeyValuePair<string, string> para in p)
                {
                    Console.WriteLine($"\"{para.Key}\" : \"{para.Value}\"");

                }
            }

        }
    }


}
