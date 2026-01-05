using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Observer
{
    abstract class Podatek
    {

        public string Nazwa { get; set; }
        private float __wysokosc;
        public float Wysokosc
        {
            get
            {
                return __wysokosc;
            }
            set
            {
                if (value > 0)
                {
                    __wysokosc = value;
                    Powiadom();
                }

            }
        }
        private List<IPodatek> __podatki = new List<IPodatek>();
        public Podatek(float wysokosc)
        {
            Wysokosc = wysokosc;
        }
        public void Dodaj(IPodatek restaurant)
        {
            __podatki.Add(restaurant);
        }

        public void Usun(IPodatek restaurant)
        {
            __podatki.Remove(restaurant);
        }

        public void Powiadom()
        {
            foreach (IPodatek podatek in __podatki)
            {
                podatek.Zmien(this);
                Console.WriteLine("Zmieniono wysokość podatku "+this.Nazwa+ " na "+this.Wysokosc.ToString());

            }

        }
    }
    class AktywnyPodatek : Podatek
    {
        public AktywnyPodatek(float wysokosc) : base(wysokosc)
        {

        }
    }
    interface IPodatek
    {
        public void Zmien(Podatek podatek);
    }
    class NowyPodatek : IPodatek 
    {
        public string Nazwa { get; set; }
        public float Wysokosc { get; set; }
        public NowyPodatek(string nazwa, float wysokosc)
        {
            Nazwa = nazwa;
            Wysokosc = wysokosc;
        }
        public  void Zmien(Podatek podatek)
        {
            Console.WriteLine("Zmieniono wysokość podatku "+podatek.Nazwa);
        }

    }
}

