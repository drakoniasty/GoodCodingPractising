using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Fasada
{
   public class ApiWeather
    {
        private string lat = "52.256776";
        private string lon = "21.004980";
        //52.256776, 21.004980
        private string part = "current";
        private string klucz = "668b67f533481767bf6b8481bc07673b";
        public string URL
        {
            get
            {
                return "https://api.openweathermap.org/data/2.5/weather?lat="+lat+"&lon="+lon+"&appid="+klucz;
            }
            set
            {
                if (value == "1")
                {
                    lat = "52.256776";
                    lon = "21.004980";
                }
                else if (value == "2")
                {
                    lat = "50.049683";
                    lon = "19.944544";
                }
            }
        }


        public async Task<JObject> callAsync()
        {

            try
            {
                
                using (HttpClient clients = new HttpClient())
                {
                    
                    using (HttpResponseMessage res = await clients.GetAsync(URL))
                    {
                        
                        using (HttpContent zawartosc = res.Content)
                        {
                            
                            string data = await zawartosc.ReadAsStringAsync();
                            
                            if (data != null)
                            {
                                
                                var dataObj = JObject.Parse(data);
                                
                                //Console.WriteLine("Twoja odpowiedź z api");
                                //Console.WriteLine(dataObj);
                                return dataObj; 
                            }
                            else
                            {
                                //If data is null log it into console.
                                //Console.WriteLine("Data is null!");
                                return null;
                            }
                        }
                    }
                }
                //Catch any exceptions and log it into the console.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }


            //// --------------------------------------------------------------------------------
            //HttpClient client = new HttpClient();

            //var values = new Dictionary<string, string>
            //{
            //    { "lat", lat },
            //    { "lon", lon },
            //    { "exclude", part },
            //    { "appid", klucz }
            //};

            //var content = new FormUrlEncodedContent(values);

            //var response = await client.PostAsync(url, content);

            //var responseString = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("Odpowiedź z API: ");
            //Console.WriteLine(responseString);
            //Console.WriteLine("Koniec odpowiedzi z API");


            //using StringContent jsonContent = new(
            //JsonSerializer.Serialize(new
            //{
            //    userId = 77,
            //    id = 1,
            //    title = "write code sample",
            //    completed = false
            //}),
            //Encoding.UTF8,
            //"application/json");

            //using HttpResponseMessage response = await HttpClient.PostAsync(
            //    "todos",    
            //    jsonContent);

            ////response.EnsureSuccessStatusCode().WriteRequestToConsole();

            //var jsonResponse = await response.Content.ReadAsStringAsync();
            //Console.WriteLine($"{jsonResponse}\n");
        }
        public ApiWeather(string miasto) 
        {
            this.URL = miasto;
        }
    }
    public  class Fasada
    {
        //public static async Task<Fasada> Create()
        //{
        //    var myClass = new Fasada();
        //    await myClass.Initialize();
        //    return myClass;
        //}
        public string Odpowiedz { get; set; }
        public ApiWeather API { get; set; }
        
        private Dictionary<string, string> miasta = new Dictionary<string, string>()
        {
            {"1" , "Warszawa" },
            {"2" , "Kraków" },
        };
        public  Fasada()
        {
            Console.WriteLine("Dla jakiego miasta chcesz zobaczyć pogodę?");
            foreach (var kvp in miasta)
            {
                Console.WriteLine("#{0} - {1}", kvp.Key, kvp.Value); 
            }
            this.Odpowiedz= Console.ReadLine();
            API = new ApiWeather(Odpowiedz);
        }
        public async Task Pogoda()
        {
            var odp = await API.callAsync();
            //Console.WriteLine("Twoja odpowiedź w fasadzie");
            //Console.WriteLine(odp);
            if (odp != null) 
            {
                Console.WriteLine("Pogoda w mieście " + miasta[Odpowiedz]);
                Console.Write("Temperatura: ");
                Console.WriteLine(odp["main"]["temp"]);
                Console.WriteLine("Farenheita");
                Console.Write("Pogoda: ");
                Console.WriteLine(odp["weather"][0]["main"]);
                Console.Write("Szczegóły: ");
                Console.WriteLine(odp["weather"][0]["description"]);
            }
            else
            {
                Console.WriteLine("BRAK INTERNETU!!!");
            }
        }
    }
}
