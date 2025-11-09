#### Długa lista parametrów (Long Parameter List)      

Masz metodę `RegisterProduct, która przyjmuje wiele parametrów związanych z produktem. Twoim zadaniem jest zastąpienie długiej listy parametrów jednym obiektem ProductInfo.

```csharp
public void RegisterProduct(string productName, string category, decimal price, int stock, string supplierName, string supplierContact)
{
    // Rejestracja produktu
    Console.WriteLine($"Product: {productName}, Category: {category}, Price: {price:C}, Stock: {stock}, Supplier: {supplierName}, Contact: {supplierContact}");
}
```

Kroki do wykonania:

1. Utwórz nową klasę ProductInfo, która będzie grupować wszystkie parametry związane z produktem.
1. Zastąp listę parametrów w metodzie RegisterProduct jednym obiektem ProductInfo.
1. Zaktualizuj logikę metody tak, aby korzystała z nowego obiektu.

Skorzystaj z narzędzia ReSharper (Ctrl+R, O) lub użyj wbudowanych narzędzi w Visual Studio, aby wyodrębnić obiekt parametru.

Przykładowy docelowy kod wynikowy w pliku `LongParameterList.cs`.


#### Duplikacja kodu (Duplicated Code)

Masz metody LogError i LogWarning, które zawierają zduplikowaną logikę formatowania komunikatów logów. Twoim zadaniem jest usunięcie zduplikowanego kodu poprzez wyodrębnienie wspólnej logiki do nowej metody FormatLogMessage.

```csharp
public void LogError(string message, DateTime timestamp)
{
    string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
    string formattedMessage = $"ERROR: [{formattedTimestamp}] {message}";
    Console.WriteLine(formattedMessage);
}

public void LogWarning(string message, DateTime timestamp)
{
    string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
    string formattedMessage = $"WARNING: [{formattedTimestamp}] {message}";
    Console.WriteLine(formattedMessage);
}
```

Kroki do wykonania:

1. Wyodrębnij zduplikowaną logikę formatowania komunikatów do oddzielnej metody FormatLogMessage.
1. Zamień zduplikowany kod w metodach LogError i LogWarning na wywołanie nowej metody FormatLogMessage.
1. Zaktualizuj metody, aby były bardziej czytelne i łatwiejsze w utrzymaniu.

Przykładowy docelowy kod wynikowy w pliku `DuplicatedCode.cs`.


#### Message Chains (Łańcuchy wiadomości)

Masz kod, który wywołuje łańcuch metod z Library.GetBook().GetAuthor().GetName(). Twoim zadaniem jest wprowadzenie nowej metody GetAuthorName w klasie Library, aby zredukować łańcuch wiadomości.

Kod do refaktoryzacji:

```csharp
public class Car
{
    public Engine GetEngine()
    {
        return new Engine();
    }
}

public class Engine
{
    public Cylinder GetCylinder()
    {
        return new Cylinder();
    }
}

public class Cylinder
{
    public string GetSize()
    {
        return "2.0L";
    }
}

// Przykład wywołania
Car car = new Car();
string cylinderSize = car.GetEngine().GetCylinder().GetSize();

```

Kroki do wykonania:

1. Wprowadź metodę GetCylinderSize w klasie Car.
1. Przenieś wywołanie zagnieżdżone do nowej metody w klasie Car.
1. Zaktualizuj wywołania metod, aby używały nowej metody.

Przykładowy docelowy kod wynikowy w pliku `MessageChains.cs`.

#### Refused Bequest (Odrzucony spadek)+

Masz klasę Manager dziedziczącą po Employee, ale Manager nie używa wszystkich metod odziedziczonych po Employee. Twoim zadaniem jest usunięcie niepotrzebnego dziedziczenia i wprowadzenie bardziej odpowiedniego rozwiązania.

Kod do refaktoryzacji:

```csharp
public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public void Work() { /* Implementacja */ }
    public void AttendMeeting() { /* Implementacja */ }
}

public class Manager : Employee
{
    public void ManageTeam() { /* Implementacja */ }
}
```

Kroki do wykonania:

1. Usuń dziedziczenie w klasie Manager.
1. Utwórz interfejs IEmployee zawierający metody Work, AttendMeeting.
1. Wprowadź interfejs IEmployee do klasy Manager i przenieś do niej tylko te metody, które są używane.

Przykładowy docelowy kod wynikowy w pliku `RefusedBequest.cs`.


#### Temporary Field (Tymczasowe pole)+

Masz klasę InvoiceGenerator, która używa tymczasowych pól (_invoiceNumber, _pdfWriter) tylko w jednej metodzie GenerateInvoice. Twoim zadaniem jest usunięcie tych pól i przekształcenie ich w lokalne zmienne.

Kod do refaktoryzacji:

```csharp
public class InvoiceGenerator
{
    private int _invoiceNumber; // Tymczasowe pole używane tylko w jednej metodzie
    private PdfWriter _pdfWriter; // Tymczasowe pole używane tylko w jednej metodzie

    public void GenerateInvoice()
    {
        _invoiceNumber = 12345;
        _pdfWriter = new PdfWriter($"Invoice_{_invoiceNumber}.pdf");
        
        // Generowanie faktury
        _pdfWriter.Write("Invoice Content");
        _pdfWriter.Close();
    }

    public void OtherMethod()
    {
        // Metoda, która nie korzysta z tymczasowych pól
    }
}
```

Kroki do wykonania:

1. Usuń tymczasowe pola (_invoiceNumber, _pdfWriter) z klasy InvoiceGenerator.
1. Przekształć tymczasowe pola na lokalne zmienne wewnątrz metody GenerateInvoice.
1. Upewnij się, że kod jest bardziej spójny i czytelny po refaktoryzacji.

Przykładowy docelowy kod wynikowy w pliku `11.TemporaryFields.cs`.


#### Data Clumps (Grupy danych)

Masz metodę RegisterEvent, która przyjmuje kilka powiązanych ze sobą parametrów (eventName, eventDate, location). Twoim zadaniem jest utworzenie nowej klasy EventDetails i zastąpienie parametrów odpowiednim obiektem.

Kod do refaktoryzacji:

```csharp
public void RegisterEvent(string eventName, DateTime eventDate, string location)
{
    Console.WriteLine($"Event: {eventName}, Date: {eventDate}, Location: {location}");
}
```

Kroki do wykonania:

1. Utwórz nową klasę EventDetails, która będzie zawierała pola eventName, eventDate, location.
1. Zastąp listę parametrów w metodzie RegisterEvent jednym obiektem EventDetails.
1. Zaktualizuj logikę metody, aby korzystała z nowego obiektu.

Przykładowy docelowy kod wynikowy w pliku `12.DataClumps.cs`.


#### Inappropriate Intimacy (Niewłaściwa zażyłość)

Masz klasy Student i Course, gdzie Student zna zbyt wiele szczegółów implementacyjnych klasy Course, np. bezpośrednio modyfikuje jej prywatne pola. Twoim zadaniem jest usunięcie tej "zażyłości" i poprawienie struktury kodu.

Kod do refaktoryzacji:

```csharp
public class Course
{
    private int _credits;
    private bool _isCompleted;

    public int Credits
    {
        get { return _credits; }
        set { _credits = value; }
    }

    public bool IsCompleted
    {
        get { return _isCompleted; }
        set { _isCompleted = value; }
    }
}

public class Student
{
    public void CompleteCourse(Course course)
    {
        course.Credits = 3; // Bezpośrednie ustawianie prywatnych pól
        course.IsCompleted = true; // Bezpośrednie ustawianie prywatnych pól
    }
}
```

Kroki do wykonania:

1. Usuń bezpośredni dostęp do prywatnych pól klasy Course w metodach klasy Student.
1. Wprowadź metody publiczne w klasie Course do modyfikowania jej stanu (Complete).
1. Zastąp bezpośrednie ustawienia metodami publicznymi.

Przykładowy docelowy kod wynikowy w pliku `13.InappropriateIntimacy.cs`.


#### Long Message Chain (Długi łańcuch wywołań wiadomości)

Masz kod, który wywołuje długi łańcuch metod School.GetClassroom().GetTeacher().GetName(). Twoim zadaniem jest wprowadzenie nowej metody GetTeacherName w klasie School, aby zredukować długość łańcucha wiadomości.

Kod do refaktoryzacji:

```csharp
public class School
{
    public Classroom GetClassroom()
    {
        return new Classroom();
    }
}

public class Classroom
{
    public Teacher GetTeacher()
    {
        return new Teacher();
    }
}

public class Teacher
{
    public string GetName()
    {
        return "John Smith";
    }
}

// Przykład wywołania
School school = new School();
string teacherName = school.GetClassroom().GetTeacher().GetName();
```

Kroki do wykonania:

1. Dodaj metodę delegującą GetTeacherName w klasie School.
1. Przenieś zagnieżdżone wywołania do nowej metody w klasie School.
1. Zaktualizuj oryginalne wywołanie kodu, aby korzystać z nowej metody.

Przykładowy docelowy kod wynikowy w pliku `14.LongMessageChain.cs`.


#### Divergent Change (Rozbieżne zmiany)

Masz klasę UserAccount, która zawiera metody dotyczące zarządzania kontem użytkownika, logowania, i raportowania. Twoim zadaniem jest rozdzielenie odpowiedzialności na osobne klasy.

Kod do refaktoryzacji:

```csharp
public class UserAccount
{
    public string Username { get; set; }
    public string Password { get; set; }

    public void Login(string username, string password)
    {
        // Logika logowania
        Console.WriteLine("User logged in.");
    }

    public void Logout()
    {
        // Logika wylogowania
        Console.WriteLine("User logged out.");
    }

    public void GenerateReport()
    {
        // Logika generowania raportu
        Console.WriteLine("Generating user report.");
    }
}
```

Kroki do wykonania:

1. Utwórz osobne klasy AuthenticationService i UserReportGenerator dla odpowiednich odpowiedzialności.
1. Przenieś odpowiednie metody do tych nowych klas.
1. Usuń zbędne metody z klasy UserAccount i zachowaj tylko właściwości oraz metody bezpośrednio związane z kontem użytkownika.

Przykładowy docelowy kod wynikowy w pliku `15.DivergentChange.cs`.


#### Parallel Inheritance Hierarchies (Równoległe hierarchie dziedziczenia)

Masz klasy BaseNotificationSender i BaseReportGenerator oraz ich klasy pochodne (EmailNotificationSender, SmsNotificationSender oraz PdfReportGenerator, CsvReportGenerator). Twoim zadaniem jest usunięcie równoległych hierarchii dziedziczenia i wprowadzenie bardziej elastycznej architektury.

Kod do refaktoryzacji:

```csharp
public class BaseLogger
{
    public virtual void LogMessage() { /* Implementacja */ }
}

public class FileLogger : BaseLogger
{
    public override void LogMessage() { /* Implementacja dla pliku */ }
}

public class DatabaseLogger : BaseLogger
{
    public override void LogMessage() { /* Implementacja dla bazy danych */ }
}

public class BaseExporter
{
    public virtual void ExportData() { /* Implementacja */ }
}

public class XmlExporter : BaseExporter
{
    public override void ExportData() { /* Implementacja dla XML */ }
}

public class JsonExporter : BaseExporter
{
    public override void ExportData() { /* Implementacja dla JSON */ }
}
```

Kroki do wykonania:

1. Usuń klasy bazowe (BaseLogger i BaseExporter).
1. Wprowadź interfejsy ILogger i IExporter.
1. Przenieś metody do interfejsów i zastąp hierarchię klas bazowych implementacjami interfejsów.
1. Dostosuj klasy pochodne, aby implementowały odpowiednie interfejsy.

Przykładowy docelowy kod wynikowy w pliku `16.ParallelInheritanceHierarchies.cs`.


#### Feature Envy (Zazdrość o funkcje)

Masz metodę CalculateShippingCost w klasie Order odwołującą się do danych klasy ShippingDetails częściej niż do własnych danych. Twoim zadaniem jest przeniesienie metody CalculateShippingCost do klasy ShippingDetails.

Kod do refaktoryzacji:

```csharp
public class ShippingDetails
{
    public string ShippingMethod { get; set; }
    public string Destination { get; set; }
}

public class Order
{
    public ShippingDetails ShippingDetails { get; set; }
    public decimal Amount { get; set; }

    public decimal CalculateShippingCost()
    {
        if (ShippingDetails.ShippingMethod == "Air")
        {
            return Amount * 0.2m;
        }
        else if (ShippingDetails.ShippingMethod == "Sea")
        {
            return Amount * 0.1m;
        }
        return Amount * 0.15m;
    }
}
```

Kroki do wykonania:

1. Przenieś metodę CalculateShippingCost do klasy ShippingDetails.
1. Zaktualizuj logikę metody tak, aby przyjmowała jako parametr kwotę zamówienia (Amount).
1. Usuń metodę CalculateShippingCost z klasy Order.

Przykładowy docelowy kod wynikowy w pliku `17.FeatureEnvy.cs`.


#### God Class (Klasa Boga)

Masz klasę AdminPanel, która zarządza użytkownikami, konfiguracjami systemu, rejestruje logi i generuje raporty systemowe. Twoim zadaniem jest podzielenie tej klasy na mniejsze klasy o bardziej określonych odpowiedzialnościach.

Kod do refaktoryzacji:

```csharp
public class AdminPanel
{
    public void ManageUsers()
    {
        Console.WriteLine("Managing users.");
    }

    public void ConfigureSystem()
    {
        Console.WriteLine("Configuring system.");
    }

    public void RegisterLog(string log)
    {
        Console.WriteLine($"Log: {log}");
    }

    public void GenerateSystemReport()
    {
        Console.WriteLine("System report generated.");
    }
}
```

Kroki do wykonania:

1. Utwórz osobne klasy UserManager, SystemConfigurator, LogRegistrar, i SystemReportGenerator.
1. Przenieś odpowiednie metody do tych nowych klas.
1. Usuń zbędne metody z klasy AdminPanel i zachowaj tylko te, które są faktycznie związane z zarządzaniem panelem administratora na wysokim poziomie.

Przykładowy docelowy kod wynikowy w pliku `18.GodClass.cs`.


#### Switch Statements (Instrukcje warunkowe)

Masz metodę DeterminePaymentFee w klasie Payment z wieloma instrukcjami switch/case, która obsługuje różne metody płatności. Twoim zadaniem jest zastosowanie wzorca strategii, aby uniknąć nadmiarowych instrukcji warunkowych.

Kod do refaktoryzacji:

```csharp
public class Payment
{
    public string PaymentMethod { get; set; }

    public decimal DeterminePaymentFee(decimal amount)
    {
        switch (PaymentMethod)
        {
            case "CreditCard":
                return amount * 0.02m;
            case "PayPal":
                return amount * 0.03m;
            case "BankTransfer":
                return amount * 0.01m;
            default:
                return 0;
        }
    }
}
```

Kroki do wykonania:

1. Utwórz interfejs IPaymentFeeStrategy z metodą DeterminePaymentFee.
1. Utwórz osobne klasy implementujące IPaymentFeeStrategy dla każdej metody płatności (CreditCardFeeStrategy, PayPalFeeStrategy, BankTransferFeeStrategy).
1. Zamień instrukcje switch na wybór odpowiedniej strategii, wstrzykując strategię do klasy Payment.


Przykładowy docelowy kod wynikowy w pliku `19.SwitchStatements.cs`.


#### Large Class (Duża klasa)

Masz klasę WarehouseManager, która zarządza zamówieniami, inwentaryzacją, dostawami, i zwrotami. Twoim zadaniem jest podzielenie tej klasy na mniejsze klasy o bardziej określonych odpowiedzialnościach.

Kod do refaktoryzacji:

```csharp
public class WarehouseManager
{
    public void ProcessOrders()
    {
        Console.WriteLine("Processing orders.");
    }

    public void ManageInventory()
    {
        Console.WriteLine("Managing inventory.");
    }

    public void CoordinateDeliveries()
    {
        Console.WriteLine("Coordinating deliveries.");
    }

    public void HandleReturns()
    {
        Console.WriteLine("Handling returns.");
    }
}
```

Kroki do wykonania:

1. Utwórz osobne klasy OrderProcessor, InventoryManager, DeliveryCoordinator, i ReturnHandler.
1. Przenieś odpowiednie metody do tych nowych klas.
1. Usuń zbędne metody z klasy WarehouseManager i zachowaj tylko te, które są faktycznie związane z zarządzaniem magazynem na wysokim poziomie.

Przykładowy docelowy kod wynikowy w pliku `20.LargeClass.cs`.


#### Primitive Obsession (Opętanie typami prostymi)

Masz metodę RegisterProduct w klasie ProductManager, która przyjmuje wiele parametrów związanych z produktem (name, category, price, quantity). Twoim zadaniem jest utworzenie nowej klasy ProductDetails i zastąpienie parametrów odpowiednim obiektem.

Kod do refaktoryzacji:

```csharp
public class ProductManager
{
    public void RegisterProduct(string name, string category, decimal price, int quantity)
    {
        Console.WriteLine($"Product: {name}, Category: {category}, Price: {price}, Quantity: {quantity}");
    }
}
```

Kroki do wykonania:

1. Utwórz nową klasę ProductDetails, która będzie zawierała pola Name, Category, Price, Quantity.
1. Zastąp listę parametrów w metodzie RegisterProduct jednym obiektem ProductDetails.
1. Zaktualizuj logikę metody, aby korzystała z nowego obiektu.

Przykładowy docelowy kod wynikowy w pliku `21.PrimitiveObsession.cs`.


#### Data Class (Klasa danych)

Masz klasę Product z właściwościami, które są tylko publicznymi polami przechowującymi dane. Twoim zadaniem jest dodanie metod zawierających logikę biznesową dotyczącą danych przechowywanych w tej klasie.

Kod do refaktoryzacji:

```csharp
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
```

Kroki do wykonania:

1. Dodaj logikę biznesową bezpośrednio do klasy Product.
1. Dodaj metodę GetFormattedPrice, która zwraca cenę sformatowaną jako tekst.
1. Dodaj metodę IsInStock, która zwraca true, jeśli StockQuantity jest większe niż 0.

Przykładowy docelowy kod wynikowy w pliku `22.DataClass.cs`.


#### Comments (Komentarze)

Masz metodę PerformTransaction z kilkoma komentarzami opisującymi kroki transakcji. Twoim zadaniem jest przekształcenie komentarzy w bardziej opisowe nazwy metod.

Kod do refaktoryzacji:

```csharp
    public class Transaction
    {
        public bool VerifyDetails()
        {

            return true;
        }
    }

public class PaymentProcessor
{
    public void PerformTransaction(Transaction transaction)
    {
        // Weryfikuje szczegóły transakcji
        if (transaction.VerifyDetails())
        {
            // Przeprowadza płatność
            ProcessPayment(transaction);

            // Aktualizuje stan konta
            UpdateAccount(transaction);

            // Generuje potwierdzenie
            CreateReceipt(transaction);
        }
    }
}
```

Kroki do wykonania:

1. Zastąp komentarze bardziej opisowymi nazwami metod.
1. Wyodrębnij bloki kodu do osobnych metod.

Przykładowy docelowy kod wynikowy w pliku `Comments.cs`.


#### Middle Man (Pośrednik)

Masz klasę InvoiceService, która jedynie deleguje wywołania metod do klasy InvoiceRepository. Twoim zadaniem jest usunięcie klasy pośrednika i bezpośrednie użycie klasy InvoiceRepository.

Kod do refaktoryzacji:

```csharp
public class InvoiceService
{
    private readonly InvoiceRepository _repository = new InvoiceRepository();

    public Invoice GetInvoiceById(int id)
    {
        return _repository.GetInvoiceById(id);
    }

    public void SaveInvoice(Invoice invoice)
    {
        _repository.SaveInvoice(invoice);
    }
}
```

Kroki do wykonania:

1. Usuń klasę InvoiceService.
1. Zastąp wszystkie odwołania do InvoiceService bezpośrednimi odwołaniami do InvoiceRepository.
1. Upewnij się, że kod nadal działa poprawnie po usunięciu klasy pośrednika.

Przykładowy docelowy kod wynikowy w pliku `24.MiddleMan.cs`.


#### Long Method (Długa metoda)

Masz klasy Teacher i GradeBook, gdzie Teacher bezpośrednio modyfikuje prywatne pola klasy GradeBook. Twoim zadaniem jest usunięcie tej "zażyłości" i poprawienie struktury kodu.

Kod do refaktoryzacji:

```csharp
public class GradeBook
{
    private int _grade;
    private bool _isFinalized;

    public int Grade
    {
        get { return _grade; }
        set { _grade = value; }
    }

    public bool IsFinalized
    {
        get { return _isFinalized; }
        set { _isFinalized = value; }
    }
}

public class Teacher
{
    public void FinalizeGrades(GradeBook gradeBook)
    {
        gradeBook.Grade = 90; // Bezpośrednie ustawianie prywatnych pól
        gradeBook.IsFinalized = true; // Bezpośrednie ustawianie prywatnych pól
    }
}
```

Kroki do wykonania:

1. Usuń bezpośredni dostęp do prywatnych pól klasy GradeBook w metodach klasy Teacher.
1. Wprowadź metody publiczne w klasie GradeBook do modyfikowania jej stanu (SetGrade, Finalize).
1. Zastąp bezpośrednie ustawienia metodami publicznymi.

Przykładowy docelowy kod wynikowy w pliku `25.LongMethod.cs`.


#### Speculative Generality (Spekulacyjna ogólność)

Masz klasę AdvancedHandler, która zawiera wiele metod zaprojektowanych z myślą o potencjalnych przyszłych wymaganiach, ale żadna z tych metod nie jest używana. Twoim zadaniem jest uproszczenie tej klasy, usuwając zbędną ogólność.

Kod do refaktoryzacji:

```csharp
public class AdvancedHandler
{
    public void HandleRequest(object request)
    {
        // Ogólna logika przetwarzania, która nigdy nie jest używana
    }

    public void HandleHttpRequest(HttpRequest request)
    {
        Console.WriteLine($"Handling HTTP request: {request.Url}");
    }

    public void HandleFileRequest(FileRequest request)
    {
        Console.WriteLine($"Handling file request: {request.FileName}");
    }
}
```

Kroki do wykonania:

1. Usuń nieużywane metody (HandleRequest) oraz niepotrzebne abstrakcje.
1. Zachowaj tylko metody, które są faktycznie wykorzystywane (HandleHttpRequest, HandleFileRequest).

Przykładowy docelowy kod wynikowy w pliku `26.SpeculativeGenerality.cs`.


#### Lazy Class (Leniva klasa)

Masz klasę NotificationSender, która ma bardzo mało odpowiedzialności. Twoim zadaniem jest przeniesienie jej funkcji do bardziej odpowiedniej klasy.

Kod do refaktoryzacji:

```csharp
public class NotificationSender
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Notification sent: {message}");
    }
}
```

Kroki do wykonania:

1. Przenieś metodę SendNotification do innej klasy, która zarządza komunikacją (np. MessagingService).
1. Usuń klasę NotificationSender.

Przykładowy docelowy kod wynikowy w pliku `27.LazyClass.cs`.


#### Shotgun Surgery (Operacja "strzał na oślep")

Masz klasy Customer i Order, gdzie zarówno Customer jak i Order mają metody dotyczące logiki zamówienia. Twoim zadaniem jest skoncentrowanie odpowiedzialności dotyczących zamówienia w jednej klasie.

Kod do refaktoryzacji:

```csharp
public class Customer
{
    public string Name { get; set; }

    public void CreateOrder()
    {
        Console.WriteLine($"Order created for customer {Name}.");
    }
}

public class Order
{
    public string OrderId { get; set; }

    public void SaveOrder()
    {
        Console.WriteLine($"Order {OrderId} saved.");
    }
}
```

Kroki do wykonania:

1. Utwórz centralną klasę OrderService, która zajmie się zarządzaniem zamówieniami.
1. Przenieś odpowiedzialności dotyczące zamówień do tej klasy.

Przykładowy docelowy kod wynikowy w pliku `28.ShotgunSurgery.cs`.
