using GoodCodePractise.Adapter;
using GoodCodePractise.Bridge;
using GoodCodePractise.Faktoria;
using GoodCodePractise.Fasada;
using GoodCodePractise.Observer;
using GoodCodePractise.Prototyp;
using GoodCodePractise.Proxy;
using GoodCodePractise.Singleton;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Rozpoczynam program");

        List<Dictionary<string, string>> obiekty_zewnetrzne = [
                    new Dictionary<string, string>{
                        { "imie", "Jan MęczyBuła" },
                        { "wiek", "34" },
                        { "dystans", "5" },
                        { "czestotliwosc", "2" },

                    },
                    new Dictionary<string, string>{
                        { "imie", "Sara" },
                        { "wiek", "21" },
                        { "tarcza", "true" },
                        { "bron_dluga", "false" },
                        { "bron_krotka", "true" },
                    },
                    new Dictionary<string, string>{
                        { "imie", "Krzysztof" },
                        { "wiek", "25" },
                        { "gieremek", "true" },
                        { "PredkoscPoruszania", "25" },
                    },

            ];
        Console.WriteLine("Zadanie #1 Singleton");
        Console.WriteLine("wywołanie nr 1");
        Console.WriteLine(Vault.Instance);
        Console.WriteLine("wywołanie nr 2");
        Console.WriteLine(Vault.Instance);
        Console.WriteLine("Zadanie #2 Fabryka");
        List<IWojownik> obiekty = new List<IWojownik>();
        foreach (var item in obiekty_zewnetrzne)
        {
            obiekty.Add(Garnizon.CreateWojownik(item));

        }
        foreach (var item in obiekty)
        {
            item.KimJestes();
        }
        Console.WriteLine("Zadanie #4 Prototyp");
        Ork ork = new Ork("Orkan", "Orkanowski", "3", "Miecz");
        string serializacja = JsonConvert.SerializeObject(ork);
        Dictionary<string, string> prototyp = new Dictionary<string, string>();
        prototyp = JsonConvert.DeserializeObject<Dictionary<string, string>>(serializacja);
        //Dictionary<string, string> prototyp = new Dictionary<string, string>();

        //Console.WriteLine("Twój zaserializowany obiekt");
        //Console.WriteLine(serializacja);
        //serializacja = serializacja.Remove(0,1);
        //serializacja = serializacja.Remove(serializacja.Length-1);
        //Console.WriteLine("Usunięte znaki");
        //Console.WriteLine(serializacja);
        //string[] stringi = serializacja.Split(',');
        //foreach (var item in stringi)
        //{
        //    Console.WriteLine("Teraz szykuję się do słownika");
        //    Console.WriteLine(item);
        //    string klucz = item.Split(":")[0];
        //    string wartosc = item.Split(":")[1];
        //    klucz = klucz.Replace('"', '\0');
        //    klucz = klucz.Replace(',', '\0');
        //    //wartosc = wartosc.Replace('"', '\0');
        //    Console.WriteLine(klucz);
        //    Console.WriteLine(wartosc);
        //    prototyp.Add(klucz, wartosc);
        //}
        //Console.WriteLine("Twoj prototyp w formie słownika");
        //Console.WriteLine(prototyp);
        //foreach (var kvp in prototyp)
        //    { Console.WriteLine("Klucz: |{0}|  Wartość: |{1}|", kvp.Key, kvp.Value); }
        List<Ork> orkowie = new List<Ork>();
        Console.WriteLine("Zmieniam parametr siła na losowe wartości");
        Console.WriteLine("Tworzę 5 kolejnych orków za pomocą serializacji i prototypu");
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {

            //Console.WriteLine("Krok nr " + i.ToString());
            //Console.WriteLine(prototyp["name"]);

            foreach (var item in prototyp.Keys) { Console.WriteLine(item); }
            prototyp["Strenght"] = random.Next(0, 100).ToString();

            orkowie.Add(new Ork(prototyp["Name"], prototyp["FamilyName"], prototyp["Strenght"], prototyp["Weapon"]));
        }
        Console.WriteLine("Oto lista Twoich orków: ");
        foreach (var item in orkowie) { Console.WriteLine(item.Strenght); }
        Console.WriteLine("Zadanie #3 Builder");
        List<IWojownik> armia = new List<IWojownik>();
        foreach (var item in obiekty_zewnetrzne)
        {
            armia.AddRange(NowyGarnizon.CreateWojownik(item));
        }
        foreach (var item in armia)
        {
            item.KimJestes();
        }
        Console.WriteLine("Zadanie #5 Fasada");
        Fasada fasada = new Fasada();
        await fasada.Pogoda();
        //ApiWeather api = new ApiWeather(fasada.Odpowiedz);
        //await api.callAsync();
        Console.WriteLine("Zadanie #6 Proxy ");
        ServerProxy objekcik = new ServerProxy();
        objekcik.RefreshDane();
        objekcik.DaneOsoby();
        Dictionary<string, string> osoba = objekcik.GetDaneOsoby();
        Console.WriteLine("Zadanie #7 Adapter");
        WeahterAdapter adapter = new WeahterAdapter("Kraków");

        Dictionary<string, string> pogodawwa = await adapter.RefreshDane();
        Console.WriteLine("Ze zmiennej w funkcji głównej");
        Console.WriteLine(pogodawwa);
        foreach (KeyValuePair<string, string> para in pogodawwa)
        {
            Console.WriteLine($"\"{para.Key}\" : \"{para.Value}\"");

        }
        Console.WriteLine("Zadanie #8 - Bridge ");
        //Pogodynka pogodynka = new PogodaPrzyklad();
        //pogodynka.pogoda = new PogodaMiasto();
        //pogodynka.DajPogode();
        //pogodynka.pogoda = new PogodaMiastoCzas();
        //pogodynka.DajPogode();
        //pogodynka.DajPogode();
        // Pompa + baza
        Console.WriteLine("Zadanie #9 Bridge");
        TerapiaInsulinowa terapia1 =
            new Baza(new PompaInsulinowa());
        terapia1.Podaj();

        // Strzykawka + bolus
        TerapiaInsulinowa terapia2 =
            new Bolus(new Strzykawka());
        terapia2.Podaj();
        Console.WriteLine("Zadanie #13 Strategy");
        // wybór strategii
        Kucharz kucharz = new Kucharz(new Smazenie());
        kucharz.PrzygotujDanie("kurczaka");

        kucharz.ZmienSposobGotowania(new Gotowanie());
        kucharz.PrzygotujDanie("makaron");

        AktywnyPodatek podatki = new AktywnyPodatek(0.82f);
        podatki.Dodaj(new NowyPodatek("VAT", 0.24f));
        podatki.Dodaj(new NowyPodatek("ZUS", 0.18f));
        podatki.Dodaj(new NowyPodatek("B2B", 0.5f));

        // Fluctuating carrot prices will notify subscribing restaurants.
        podatki.Wysokosc = 0.25f;
        podatki.Wysokosc = 0.12f;
        podatki.Wysokosc = 0.35f;
        podatki.Wysokosc = 0.98f;

        Console.ReadKey();
    }
}


