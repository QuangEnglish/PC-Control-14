namespace ConsoleApp1;

// =====================================================
// PHẦN 6 – GENERIC CONSTRAINTS
// Giới hạn kiểu T chỉ nhận một số kiểu nhất định
// Dùng từ khóa "where" để đặt ràng buộc
// =====================================================

// --- Constraint 1: where T : class (chỉ reference type) ---
public class Storage<T> where T : class
{
    private T? item;

    public void Put(T value)
    {
        item = value;
        Console.WriteLine($"  Storage: Da luu '{value}'");
    }

    public bool IsEmpty() => item == null;

    public T? Take()
    {
        var result = item;
        item = null;
        return result;
    }
}

// --- Constraint 2: where T : struct (chỉ value type) ---
public class ValueHolder<T> where T : struct
{
    private T value;

    public void Set(T val)
    {
        value = val;
        Console.WriteLine($"  ValueHolder: Da set = {val}");
    }

    public T Get() => value;

    // Nullable<T> chỉ dùng được với struct
    public T? GetNullable() => value;
}

// --- Constraint 3: where T : new() (phải có constructor rỗng) ---
public class Factory<T> where T : new()
{
    public T Create()
    {
        T instance = new T();  // Gọi constructor rỗng
        Console.WriteLine($"  Factory: Da tao instance cua {typeof(T).Name}");
        return instance;
    }

    public List<T> CreateMany(int count)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < count; i++)
        {
            list.Add(new T());
        }
        Console.WriteLine($"  Factory: Da tao {count} instance cua {typeof(T).Name}");
        return list;
    }
}

// --- Constraint 4: where T : ISomeInterface ---
public interface IPrintable
{
    void Print();
}

public class Invoice : IPrintable
{
    public int Id { get; set; }
    public decimal Amount { get; set; }

    public void Print()
    {
        Console.WriteLine($"    Hoa don #{Id}: {Amount:N0} VND");
    }
}

public class Receipt : IPrintable
{
    public string CustomerName { get; set; } = "";
    public DateTime Date { get; set; }

    public void Print()
    {
        Console.WriteLine($"    Bien lai: {CustomerName} - {Date:dd/MM/yyyy}");
    }
}

// T phải implement IPrintable → đảm bảo có method Print()
public class Printer<T> where T : IPrintable
{
    public void PrintAll(List<T> items)
    {
        Console.WriteLine($"  In {items.Count} muc:");
        foreach (T item in items)
        {
            item.Print();  // An toàn vì T chắc chắn có Print()
        }
    }
}

// --- Constraint 5: where T : BaseClass ---
public class Animal
{
    public string Name { get; set; } = "";
    public virtual string Speak() => "...";
}

public class Dog : Animal
{
    public override string Speak() => "Gau gau!";
}

public class Cat : Animal
{
    public override string Speak() => "Meo meo!";
}

// T phải kế thừa từ Animal
public class AnimalShelter<T> where T : Animal
{
    private List<T> animals = new List<T>();

    public void Add(T animal)
    {
        animals.Add(animal);
        Console.WriteLine($"  Shelter: Nhan {animal.Name} - {animal.Speak()}");
    }

    public List<T> GetAll() => animals;
}

// --- Constraint 6: KẾT HỢP nhiều constraint ---
public class AdvancedRepository<T> where T : class, IEntity, new()
{
    // T phải là: reference type + implement IEntity + có constructor rỗng
    private List<T> items = new List<T>();

    public void Add(T item) => items.Add(item);

    public T? GetById(int id) => items.FirstOrDefault(x => x.Id == id);

    public T CreateWithId(int id)
    {
        T item = new T();  // Dùng được vì có constraint new()
        item.Id = id;       // Dùng được vì có constraint IEntity
        return item;
    }
}

public static class Part6_Demo
{
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("PHAN 6 - GENERIC CONSTRAINTS");
        Console.WriteLine("(Gioi han kieu T bang 'where')");
        Console.WriteLine("========================================\n");

        // === Constraint 1: where T : class ===
        Console.WriteLine("[1] where T : class - Chi nhan reference type:");
        Storage<string> strStorage = new Storage<string>();   // OK - string là reference type
        strStorage.Put("Hello Generic Constraint");
        Console.WriteLine($"  IsEmpty: {strStorage.IsEmpty()}");
        strStorage.Take();
        Console.WriteLine($"  IsEmpty sau khi Take: {strStorage.IsEmpty()}");

        Storage<Product> prodStorage = new Storage<Product>(); // OK - Product là reference type
        prodStorage.Put(new Product { Name = "MacBook" });

        // Storage<int> intStorage = new Storage<int>();  // LOI COMPILE! int là value type
        Console.WriteLine("  // Storage<int> → LOI! int khong phai reference type\n");

        // === Constraint 2: where T : struct ===
        Console.WriteLine("[2] where T : struct - Chi nhan value type:");
        ValueHolder<int> intHolder = new ValueHolder<int>();     // OK
        intHolder.Set(42);
        Console.WriteLine($"  Gia tri: {intHolder.Get()}");

        ValueHolder<double> dblHolder = new ValueHolder<double>(); // OK
        dblHolder.Set(3.14);
        Console.WriteLine($"  Gia tri: {dblHolder.Get()}");

        ValueHolder<DateTime> dateHolder = new ValueHolder<DateTime>(); // OK - DateTime là struct
        dateHolder.Set(DateTime.Now);
        Console.WriteLine($"  Gia tri: {dateHolder.Get():dd/MM/yyyy}");

        // ValueHolder<string> strHolder = new ValueHolder<string>();  // LOI! string không phải struct
        Console.WriteLine("  // ValueHolder<string> → LOI! string khong phai value type\n");

        // === Constraint 3: where T : new() ===
        Console.WriteLine("[3] where T : new() - Phai co constructor rong:");
        Factory<Product> productFactory = new Factory<Product>();
        Product p = productFactory.Create();
        Console.WriteLine($"  Product duoc tao: {p.Name} (ten rong vi moi tao)");

        Factory<Student> studentFactory = new Factory<Student>();
        List<Student> students = studentFactory.CreateMany(3);
        Console.WriteLine($"  So sinh vien da tao: {students.Count}\n");

        // === Constraint 4: where T : Interface ===
        Console.WriteLine("[4] where T : IPrintable - Phai implement interface:");
        Printer<Invoice> invoicePrinter = new Printer<Invoice>();
        invoicePrinter.PrintAll(new List<Invoice>
        {
            new Invoice { Id = 1, Amount = 500_000 },
            new Invoice { Id = 2, Amount = 1_200_000 },
        });
        Console.WriteLine();

        Printer<Receipt> receiptPrinter = new Printer<Receipt>();
        receiptPrinter.PrintAll(new List<Receipt>
        {
            new Receipt { CustomerName = "Nguyen Van An", Date = DateTime.Now },
            new Receipt { CustomerName = "Tran Thi Binh", Date = DateTime.Now.AddDays(-1) },
        });

        // Printer<int> intPrinter = new Printer<int>();  // LOI! int không implement IPrintable
        Console.WriteLine("  // Printer<int> → LOI! int khong implement IPrintable\n");

        // === Constraint 5: where T : BaseClass ===
        Console.WriteLine("[5] where T : Animal - Phai ke thua tu class:");
        AnimalShelter<Dog> dogShelter = new AnimalShelter<Dog>();
        dogShelter.Add(new Dog { Name = "Lu" });
        dogShelter.Add(new Dog { Name = "Milu" });
        Console.WriteLine();

        AnimalShelter<Cat> catShelter = new AnimalShelter<Cat>();
        catShelter.Add(new Cat { Name = "Meo Muop" });
        catShelter.Add(new Cat { Name = "Meo Tam The" });

        // AnimalShelter<string> strShelter = new AnimalShelter<string>(); // LOI! string không kế thừa Animal
        Console.WriteLine("  // AnimalShelter<string> → LOI!\n");

        // === Constraint 6: Kết hợp nhiều constraint ===
        Console.WriteLine("[6] Ket hop nhieu constraint: where T : class, IEntity, new()");
        AdvancedRepository<ProductEntity> repo = new AdvancedRepository<ProductEntity>();

        ProductEntity pe = repo.CreateWithId(1);
        pe.Name = "Laptop Dell";
        pe.Price = 20_000_000;
        repo.Add(pe);

        ProductEntity? found = repo.GetById(1);
        Console.WriteLine($"  Tim san pham Id=1: {found}");
        Console.WriteLine();

        // === Bảng tổng kết constraint ===
        Console.WriteLine("=== BANG TONG KET CAC CONSTRAINT ===");
        Console.WriteLine("  ┌──────────────────────────────┬──────────────────────────────┐");
        Console.WriteLine("  │ Constraint                   │ Y nghia                      │");
        Console.WriteLine("  ├──────────────────────────────┼──────────────────────────────┤");
        Console.WriteLine("  │ where T : class              │ T phai la reference type      │");
        Console.WriteLine("  │ where T : struct             │ T phai la value type          │");
        Console.WriteLine("  │ where T : new()              │ T phai co constructor rong    │");
        Console.WriteLine("  │ where T : IInterface         │ T phai implement interface    │");
        Console.WriteLine("  │ where T : BaseClass          │ T phai ke thua tu class do    │");
        Console.WriteLine("  │ where T : class, new(), I..  │ Ket hop nhieu constraint      │");
        Console.WriteLine("  └──────────────────────────────┴──────────────────────────────┘\n");
    }
}
