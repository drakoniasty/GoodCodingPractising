using GoodCodePractise.Faktoria;

internal partial class Program
{
    private static void Main(string[] args)
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

        List<IWojownik> obiekty = new List<IWojownik>();
        foreach (var item in obiekty_zewnetrzne)
        {
            obiekty.Add(Garnizon.CreateWojownik(item));
            
        }
        foreach (var item in obiekty)
        {
            item.KimJestes();
        }
    }
}


