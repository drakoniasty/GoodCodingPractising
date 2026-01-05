using System;



// Strategy
public interface ISposobGotowania
{
    void Przygotuj(string skladnik);
}

// ConcreteStrategy A
public class Smazenie : ISposobGotowania
{
    public void Przygotuj(string skladnik)
    {
        Console.WriteLine(
            $"Smażę {skladnik} na patelni"
        );
    }
}

// ConcreteStrategy B
public class Gotowanie : ISposobGotowania
{
    public void Przygotuj(string skladnik)
    {
        Console.WriteLine(
            $"Gotuję {skladnik} w garnku"
        );
    }
}


// Context
public class Kucharz
{
    private ISposobGotowania sposobGotowania;

    public Kucharz(ISposobGotowania sposobGotowania)
    {
        this.sposobGotowania = sposobGotowania;
    }

    public void ZmienSposobGotowania(ISposobGotowania nowySposob)
    {
        sposobGotowania = nowySposob;
    }

    public void PrzygotujDanie(string skladnik)
    {
        sposobGotowania.Przygotuj(skladnik);
    }
}