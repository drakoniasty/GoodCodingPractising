using GoodCodePractise.Kompozyt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Pyłek
{
    class FabrykaPojazdow
    {
        private Pojazd stancja { get; set; }
        private Dictionary<string, Pojazd> pojazdy = new Dictionary<string, Pojazd>();
        public Pojazd DodajPojazdy(char wybor)
        {
            //for (int i = 0; i < wybor.Length; i++)
            //{

                switch (wybor)
                {

                    case '1':
                        stancja = new MercedesGKlasa();
                        pojazdy.Add("1", stancja);
                        break;

                    case '2':
                        stancja = new Bianco();
                        pojazdy.Add("2", stancja);
                        break;

                    case '3':
                        stancja = new BMX();
                        pojazdy.Add("3", stancja);
                        break;

                //}
            }
            return stancja;
        }
    }
    class MercedesGKlasa:Auto
    {
        public MercedesGKlasa():base("Mercedes", 3.5, 320) { }
       
    }
    class Bianco:Skuter
    {
        public Bianco():base("Bianco", 0.75, 15){}

    }
    class BMX:Rower
    {
        public BMX():base("BMW", 0.06, 15)
        {
            
        }
    }
}
