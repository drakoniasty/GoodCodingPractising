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
    class ApiWeather
    {
        //private string url = "https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude={part}&appid={API key}";
        private string lat = "52.256776";
        private string lon = "21.004980";
        //52.256776, 21.004980
        private string part = "current";
        private string klucz = "668b67f533481767bf6b8481bc07673b";
        private string url = "https://api.openweathermap.org/data/2.5/onecall?lat=52.256776&lon=21.004980&appid=f21b2daf118b393bc714b36d46256a6a";

        public async Task callAsync()
        {

            try
            {
                
                using (HttpClient clients = new HttpClient())
                {
                    
                    using (HttpResponseMessage res = await clients.GetAsync(url))
                    {
                        
                        using (HttpContent zawartosc = res.Content)
                        {
                            
                            string data = await zawartosc.ReadAsStringAsync();
                            
                            if (data != null)
                            {
                                
                                var dataObj = JObject.Parse(data);
                                
                                Console.WriteLine("Twoja odpowiedź z api");
                                Console.WriteLine(dataObj);
                            }
                            else
                            {
                                //If data is null log it into console.
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
                //Catch any exceptions and log it into the console.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
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
        public ApiWeather() { }
    }
    public class Fasada
    {
        
       public  Fasada()
        {
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("#1 ");
            Console.WriteLine("#2 ");
            Console.WriteLine("#3 ");
            Console.WriteLine("#4 ");
            Console.WriteLine("#5 ");
            
        }
    }
}
