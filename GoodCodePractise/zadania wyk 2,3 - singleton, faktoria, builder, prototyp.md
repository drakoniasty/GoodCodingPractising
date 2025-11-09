## W Folderze Samples są dostępne przykłady dla wszystkich klasycznychwzorcó projektowych Gangu Czworga.

## W folderze Tasks są dostępne przykładowe rozwiązania poniższych zadań z wzorców.

## Singleton

### Zadanie 1
1. Stwórz nową aplikację konsolową `SingletonVault`
1. Stwórz klasę o nazwie `Vault`. Zadaniem tej klasy jest zwrócenie cyfrowego klucza dostępowego do skarbca.
1. Dlatego upewnij się, że jesteś w stanie zwrócić klucz tylko raz.

## Factory

### Zadanie 1
1. Stwórzy klasę Wojownik. Utwórz klasy dziedziczące Piechur, Strzelec, Konny.
1. Stwórz klasę garnizon, która na podstawie nazwy profesji wyszkoli i zwróci nam obiekt odpowiedniego wojownika.
1. Stwórz tablicę zawierającą 3 piechurów, 3 konnych i 4 strzelców.

## Builder

### Zadanie 1
1. Utwórz klasę abstrakcyjną WarriorBuilder.
1. Utwórz klasy PiechurBuilder, StrzelecBuilder, KonnyBuilder.
1. Stwórz klasę Garnizon, której zadaniem będzie szkolenie wojowników o odpowiedniej profesji.
1. Szkolenie powinno przebiegać w 3 krokach. Zapisanie się do armii (utworzenie obiektu odpowiedniego typu), pobranie broni, trening walki.
1. Wykorzystaj klasy wojowników z poprzedniego zadania. 
1. Stwórz nowy garnizon i dodaj tam 2 piechurów, 2 konnych i 2 strzelców. 
1. Możesz wykorzystać interface `IWarrior` i listę generyczną `List<IWarrior>`;

## Prototype

### Zadanie 1
1. Stwórz klasę Ork.
1. Stwórz nowego orka.
1. Za pomocą serializacji i deserializacji w pętli stwórz kilka klonów utworzonego nowego obiektu klasy ork i dodaj do kolekcji.
1. Zmieniaj im losowo np. parametr siła. 
1. Wykorzystaj https://www.newtonsoft.com/json/help/html/SerializingJSON.htm

## Facade

### Zadanie 1
1. Wykorzystaj serwis pogodowy https://openweathermap.org/, który umożliwia pobieranie informacji o pogodzie.
1. Zaprojektuj fasadę dla tej usługi. Fasada powinna udostępniać uproszczony interfejs do korzystania z usługi, np. metodę, która zwraca aktualną temperaturę w danym mieście.
1. Stwórz interfejs użytkownika w konsoli, który pozwoli użytkownikowi na wybór miasta i wyświetli aktualną temperaturę w tym mieście.
1. Zaimplementuj fasadę, aby korzystać z zewnętrznego API, aby pobrać informacje o pogodzie i zwrócić uproszczony interfejs do wykorzystania w interfejsie użytkownika.
1. Przetestuj aplikację, upewniając się, że fasada działa poprawnie i udostępnia uproszczony interfejs użytkownika do korzystania z zewnętrznego API.
1. Wykorzystaj do komunikacji klasę: HttpClient  
https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient

Przykład użycia: 
https://gist.github.com/AliA1997/b4b3e1066dd9f31a78554438ab5d61bd

## Proxy

### Zadanie 1
1. Stwórz dwie klasy. Jedna ma reprezentować obiekt dostępny bez ograniczeń, druga obiekt zastrzeżony (dostęp ograniczony hasłem).
1. Zaprojektuj proxy, który będzie kontrolować dostęp do plików po przez sprawdzenie czy hasło zwrócone zostało poprawnie.
1. Stwórz interfejs użytkownika w konsoli, który pozwoli użytkownikowi na wybór obiektu do pobrania i wprowadzenie hasła.
1. Przetestuj aplikację, upewniając się, że proxy działa poprawnie i kontroluje dostęp do obiektów.

## Adapter

### Zadanie 1
1. Naszym zadaniem jest przechytrzyć bramkarza w klubie nocnym.
1. Nasz 17 letni Krzyś chce dostać się do klubu i potańczyć, ale nie przechodzi walidacji (np. metoda IsAdult).
1. Napisz adapter klasę `FakeAdult`, która dziedziczy po klasie `Adult`.
1. Zadaniem adaptera jest oszukać walidację i pozwolić naszemu bohaterowi wejść i pobawić się w klubie.


## Bridge

### Zadanie 1
1. Wyobraźmy sobie pulpit w naszym systemie operacyjnym. Dla systemu Windows jest to zazwyczaj oczywiste, że będziemy korzystać z interface'u graficznego. Natomiast użytkownik Linux może sobie interface wybrać.
2. Dlatego nie chcemy na stałe wiązać interface z systemem operacyjnym.
3. Proszę wdrożyć odpowiednie klasy (np. System, LinuxSystem, Interface, GraphicInterface).
4. Proszę wdrożyć relacje między tymi elementami za pomocą wzorca bridge.
5. Przetestuj poprawność rozwiązanie. Niech naciśniecie przycisku menu w naszym interface zwróci nam z systemu listę zainstalowanych programów. (na potrzeby zadania będzie to wywołanie w konsoli funkcji `displayMenu`).

## Decorator

### Zadanie 1
1. Przygotuj klasę sklepu np. `Shop`.
2. Dodaj możliwość płacenia 3 różnymi sposobami płatności (nie implementuj prawdziwego połączenia z systemem płatności).
3. Jeżeli użytkownik zapłaci kartą powinien uruchamiać się dekorator. 
4. Dodaj 3 dekoratory, które będą wykonywały się przy płatności. Np. powiadomienie sms o płatności, dodanie punktów lojalnościowych, przekierowanie na stronę główną sklepu.

## Composite 

## Zadanie 1

1. Napisz program, który symuluje menu restauracji. 
1. Każda pozycja w menu może być daniem (liść) lub podkategorią (kompozyt) zawierającą inne dania lub podkategorie. 
1. Stwórz strukturę, która będzie w stanie wyświetlić pełne menu z możliwością zagłębiania się w podkategorie.

## Flyweight 

## Zadanie 1

1. Napisz program, który symuluje system zarządzania teksturami w grze. 
1. Każda tekstura powinna być wczytywana z pliku tylko raz i współdzielona pomiędzy różnymi obiektami, 
które jej używają (np. postaciami, elementami otoczenia).

## Command

### Zadanie 1

1. Stwórz klasę `SantaClausFactory`. 
1. Jej zadaniem będzie odbieranie odpowiednich poleceń (commands) i produkowanie zabawek lub rózg.
2. Stwórz klasę pomocnika Świętego Mikołaja, który będzie przekazywał polecenia do fabryki.  
3. Wykonaj 3 zabawki i jedną rózgę.

## Observer

### Zadanie 1

1. Załóżmy, że jest grupa studentów, która oczekuje na wyniki egzaminu i jest obiekt wykładowca.
2. Napisz implementacje wzorca obserwatora w ten sposób, że w momencie, gdy wykładowca ogłosi wyniki, każdy student dostanie informacje o swoim wyniku.

## Strategy

## Zadanie 1

1. W naszej redakcji internetowej chcielibyśmy móc w łatwy sposób przeszukać różne bazy zdjęć.
2. Zaimplementuj rozwiązanie, które w zależności od preferencji pozwoli przeszukać bazę zdjęć [Pexels](https://www.pexels.com/api/) 
lub bazę zdjęć [Pixabay](https://pixabay.com/api/docs/), po wybranej nazwie kategorii.
3. Wykonaj wszystkie wymagane kroki, żeby móc korzystać z API dla obu rozwiązań.

## Visitor

## Zadanie 1

1. Napisz program, który symuluje system sklepu internetowego. 
1. Sklep ma różne typy produktów: Book (książka) i Electronics (elektronika). Każdy produkt powinien zaakceptować odwiedzającego, który może obliczyć:
Cenę po zastosowaniu zniżki (np. 10% dla książek i 5% dla elektroniki).
Koszt dostawy (np. 5 zł dla książek i 15 zł dla elektroniki).
Każdy produkt powinien posiadać cenę bazową, na podstawie której zostaną wykonane obliczenia.

## Memento

## Zadanie 1

1. Napisz program symulujący prosty notatnik, w którym użytkownik może dodawać linie tekstu. 
1. Notatnik powinien umożliwiać cofanie ostatnio dodanej linii, przywracając stan notatki do poprzedniego stanu.

Wymagania

Operacje:
Dodawanie tekstu: Dodaje nową linię tekstu do notatki.

Cofanie: 
Usuwa ostatnio dodaną linię tekstu, przywracając poprzedni stan.

Przechowywanie stanu:
Program powinien zapisywać stan notatki po każdej operacji i umożliwiać cofanie.

## Template Method

## Zadanie 1

1. Stwórz program, który symuluje proces przetwarzania dokumentu. 
1. Dokument może być w formacie PDF lub Word. W obu przypadkach proces przetwarzania dokumentu składa się z następujących kroków:
Otwieranie dokumentu.
Parsowanie treści dokumentu (różne dla PDF i Word).
Wyświetlanie treści dokumentu.
Zamknięcie dokumentu.
Zdefiniuj szablon metody w klasie bazowej ``DocumentProcessor`` i utwórz klasy pochodne `PDFProcessor` i `WordProcessor`, które implementują szczegóły specyficzne dla danego formatu.

## Mediator 

## Zadanie 1

1. Stwórz program symulujący kontrolę lotów na lotnisku. 
1. Samoloty (Airplane) komunikują się ze sobą i z wieżą kontroli lotów (ControlTower) za pośrednictwem mediatora. 
1. Mediator (ControlTower) zarządza komunikacją i decyduje, które samoloty mogą lądować, startować, lub kołować.

## Chain of Responsibility

## Zadanie 1


1. Stwórz program symulujący system przetwarzania dokumentów w firmie. 
1. Dokumenty mogą mieć różne poziomy priorytetu: Niski, Średni, Wysoki. Każdy dokument jest przetwarzany przez odpowiedniego pracownika:
1. Pracownik pierwszego poziomu przetwarza dokumenty o niskim priorytecie.
1. Pracownik drugiego poziomu przetwarza dokumenty o średnim priorytecie.
1. Pracownik trzeciego poziomu przetwarza dokumenty o wysokim priorytecie.
1. Jeśli dokument nie zostanie obsłużony na odpowiednim poziomie, powinien zostać przekazany do wyższego poziomu.

## Warsztat 1: System Zarządzania Zamówieniami
Opis Problemu
Masz do czynienia z systemem zarządzania zamówieniami, który jest źle zaprojektowany. Kody odpowiedzialne za różne operacje są pomieszane i mocno ze sobą powiązane, co utrudnia modyfikację i rozwój systemu. Celem warsztatu jest refaktoryzacja kodu, aby był bardziej czytelny, łatwiejszy w utrzymaniu i zgodny z zasadami programowania obiektowego, a jednocześnie zastosowanie w nim różnych wzorców projektowych.

Sytuacja wyjściowa
Zarządzanie zamówieniami:

System obsługuje różne typy zamówień: StandardOrder, ExpressOrder.
Obliczanie kosztów dostawy jest zagnieżdżone w klasie zamówienia.
Powiadomienia są wysyłane za pomocą różnych kanałów komunikacji (e-mail, SMS) bezpośrednio z klasy zamówienia.
Zamówienia muszą być przetwarzane przez różne etapy: Przyjęte, W trakcie realizacji, Wysłane.
Cel refaktoryzacji:

Oddzielić różne odpowiedzialności i wprowadzić wzorce projektowe takie jak: Strategy, Observer, Factory Method, State, Command.
Kod przed refaktoryzacją

```csharp	
using System;
using System.Collections.Generic;

public class Order
{
    public string OrderType { get; set; }
    public string Status { get; set; }
    public double Amount { get; set; }

    public void ProcessOrder()
    {
        Console.WriteLine($"Przetwarzanie zamówienia typu {OrderType}...");
        
        double shippingCost = 0;
        if (OrderType == "Standard")
        {
            shippingCost = 10;
        }
        else if (OrderType == "Express")
        {
            shippingCost = 20;
        }
        
        Console.WriteLine($"Koszt dostawy: {shippingCost} zł");
        Amount += shippingCost;

        Console.WriteLine("Wysyłanie powiadomienia e-mail...");
        Console.WriteLine("Wysyłanie powiadomienia SMS...");

        if (Status == "Przyjęte")
        {
            Status = "W trakcie realizacji";
        }
        else if (Status == "W trakcie realizacji")
        {
            Status = "Wysłane";
        }

        Console.WriteLine($"Nowy status zamówienia: {Status}");
    }
}

class Program
{
    static void Main()
    {
        Order order1 = new Order { OrderType = "Standard", Status = "Przyjęte", Amount = 100 };
        order1.ProcessOrder();

        Order order2 = new Order { OrderType = "Express", Status = "Przyjęte", Amount = 200 };
        order2.ProcessOrder();
    }
}
```

Cele Refaktoryzacji
Strategy Pattern: Wykorzystaj wzorzec Strategii do obliczania kosztów dostawy.
Observer Pattern: Wykorzystaj wzorzec Obserwatora do obsługi powiadomień.
Factory Method Pattern: Wykorzystaj wzorzec Metody Fabrycznej do tworzenia różnych typów zamówień.
State Pattern: Wykorzystaj wzorzec Stanu do zarządzania statusem zamówienia.
Command Pattern: Wykorzystaj wzorzec Komendy do obsługi działań związanych z zamówieniem.