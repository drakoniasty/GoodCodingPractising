using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Proxy
{
    public interface IServer
    {
        Dictionary<string, string> GetDaneOsoby();
        void DaneOsoby();
        void RefreshDane();

    }
    public class Server:IServer
    {
        string __imie = "";
        string __nazwisko = "";
        int __wiek = 0;
        string __plec = "";
        public Dictionary<string, string> GetDaneOsoby()
        {
            Dictionary<string, string> dane = new Dictionary<string, string>();
            dane.Add("Imie", __imie);
            dane.Add("Nazwisko", __nazwisko);
            dane.Add("Plec", __plec);
            dane.Add("Wiek", __wiek.ToString());
            return dane;
        }
        public void DaneOsoby()
        {
            
            Console.WriteLine("Oto dane osoby:");
            Console.WriteLine("Imie: "+__imie);
            Console.WriteLine("Imie: "+__nazwisko);
            Console.WriteLine("Imie: "+__plec);
            Console.WriteLine("Imie: "+__wiek);
        }
        public void RefreshDane()
        {
            Random rand = new Random();
            int dlugosc = rand.Next(4, 10);
            string znaki = "";
            for (int i = 0; i < dlugosc; i++)
            {
                int randValue = rand.Next(65, 91);
                char litera = Convert.ToChar(randValue);
                znaki = znaki + litera;
            }
            __imie = znaki;
            dlugosc = rand.Next(4, 10);
            znaki = "";
            for (int i = 0; i < dlugosc; i++)
            {
                int randValue = rand.Next(65, 91);
                char litera = Convert.ToChar(randValue);
                znaki = znaki + litera;
            }
            __nazwisko = znaki;
            dlugosc = rand.Next(0, 1);
            if(dlugosc == 0)
            {
                __plec = "M";
            }
            else
            {
                __plec = "K";
            }
            dlugosc = rand.Next(0,85);
            
            __wiek = dlugosc;

        }
    }
    public class ServerProxy:IServer
    {
        private Server _server = new Server();
        public Dictionary<string, string> GetDaneOsoby()
        {
            Console.WriteLine("Przekazuję wszystkie dane o osobie.....");
            return _server.GetDaneOsoby();
        }
        public void DaneOsoby()
        {
            Console.WriteLine("Wypisuję wszystkie dane o osobie...");
            _server.DaneOsoby();
            Console.WriteLine("Koniec");
        }
        public void RefreshDane()
        {
            Console.WriteLine("Czy napewno chcesz odświeżyć dane? t/n");
            string answer = Console.ReadLine();
            if (answer == "t")
            {
                _server.RefreshDane();
            }
            else
            {
                Console.WriteLine("Nie to nie!");
            }

        }
    }
}
