using GoodCodePractise.Fasada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Adapter
{
   class WeahterAdapter
    {
        private string __kelvinToCelsConv(dynamic kelvin)
        {
            double celsius = 0;
            celsius = kelvin - 273.15;
            return celsius.ToString();
        }
        private int __miasto = 1;
        public string Miasto
        {
            get
            {
                if (__miasto == 0) 
                {
                    return "Warszawa";
                }
                else
                {
                    return "Kraków";
                }
            }
            set
            {
                if(value.ToLower() == "warszawa")
                {
                    __miasto = 1;
                }
                else if (value.ToLower() ==  "krakow" ||  value =="kraków")
                {
                    __miasto = 2;
                }
                else
                {
                    __miasto = 0;
                }
            }
        }
        ApiWeather pogoda;
        private Dictionary<string, string> __pogodynka;
        public dynamic Pogodynka
        {
            get
            {
                return __pogodynka;
            }
            set
            {
                //__pogodynka.Clear();
                __pogodynka = new Dictionary<string, string>();
                Console.WriteLine("Twoje dane");
                Console.WriteLine(value);
                //Console.WriteLine(value["weather"][0]["main"]);
                __pogodynka.Add("miasto", Miasto);

                __pogodynka.Add("pogoda", value["weather"][0]["main"].ToString());
                __pogodynka.Add("pogoda_opis", value["weather"][0]["description"].ToString());
                __pogodynka.Add("temperatura_k", value["main"]["temp"].ToString());
                __pogodynka.Add("temperatura_c", __kelvinToCelsConv(value["main"]["temp"]));
                __pogodynka.Add("temperatura_odczuwalna", __kelvinToCelsConv(value["main"]["feels_like"]));
                __pogodynka.Add("cisnienie", value["main"]["pressure"].ToString());
                __pogodynka.Add("widocznosc", value["visibility"].ToString());
                __pogodynka.Add("wiatr_predkosc", value["wind"]["speed"].ToString());
            }
        }
        public Dictionary<string, string> GetDane()
        {
            return __pogodynka;
        }

        public async Task<Dictionary<string,string>> RefreshDane()
        {

            var api = new ApiWeather(Miasto);
            Pogodynka = await api.callAsync();
            //Console.WriteLine("Twoja odpowiedź z pogodynkowego API");
            //Console.WriteLine(Pogodynka);
            return __pogodynka;
        }

    }
}
