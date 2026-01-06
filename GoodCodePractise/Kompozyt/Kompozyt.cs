using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Kompozyt
{
    public abstract class Pojazd
    {
        public string Name { get; set; }
        private int iloscKol = 0;
        public int IloscKol {
            get
            {
                return iloscKol;
            }
            set
            {
                if (value > 0)
                {
                    iloscKol = value;
                }
            }
        }
        public double Waga { get; set; }
        public int Vmax { get; set; }
        public Pojazd(string name, int kola, double waga, int max)
        {
            Name=name;
            IloscKol = kola;
            Waga = waga;    
            Vmax = max; 
            
        }
        public void Opisz()
        {
            Console.WriteLine("Jest to pojazd " + Name);
            Console.WriteLine("Posiada "+IloscKol.ToString() + " kół");
            Console.WriteLine("Waży "+Waga.ToString()+ " gram");
            Console.WriteLine("Rozpędza się maksymalnie do: "+Vmax.ToString()+" KM/H");
        }

    }
    public class Auto : Pojazd
    {
        public Auto(string name, double waga, int max) : base(name, 4, waga, max) { }
    }
    public class Rower : Pojazd
    {
        public Rower(string name, double waga, int max) : base(name, 2, waga, max) { }
    }
    public class Skuter : Pojazd
    {
        public Skuter(string name, double waga, int max) : base(name, 2, waga, max) { }
    }

}
