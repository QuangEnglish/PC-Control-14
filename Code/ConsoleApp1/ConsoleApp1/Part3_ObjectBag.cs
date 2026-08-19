namespace ConsoleApp1;

// =====================================================
// PHẦN 3 – GIẢI PHÁP CŨ: DÙNG OBJECT
// Túi đựng đồ đa năng nhưng KHÔNG AN TOÀN
// =====================================================

// Dùng object để chứa mọi thứ
public class Bag
{
    private object? _item;

    public void Put(object value)
    {
        _item = value;
        Console.WriteLine($"  Da bo vao tui: {value}");
    }

    public object? Take()
    {
        Console.WriteLine($"  Lay ra tu tui: {_item}");
        return _item;
    }
}

public static class Part3_Demo
{
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("PHAN 3 - GIAI PHAP CU: DUNG OBJECT");
        Console.WriteLine("(Tui da nang nhung KHONG AN TOAN)");
        Console.WriteLine("========================================\n");

        Bag bag = new Bag();

        // --- Ví dụ 1: Dùng bình thường - OK ---
        Console.WriteLine("[1] Bo so nguyen vao tui (Boxing xay ra!):");
        bag.Put(100);                          // Boxing: int → object
        int number = (int)bag.Take()!;         // Unboxing: object → int
        Console.WriteLine($"  Gia tri sau khi cast: {number}\n");

        // --- Ví dụ 2: Dùng với string - OK ---
        Console.WriteLine("[2] Bo chuoi vao tui:");
        bag.Put("Laptop Gaming");
        string laptop = (string)bag.Take()!;   // Cast về string
        Console.WriteLine($"  Gia tri sau khi cast: {laptop}\n");

        // --- Ví dụ 3: SAI KIỂU - RUNTIME ERROR! ---
        Console.WriteLine("[3] NGUY HIEM! Bo chuoi vao nhung cast ra int:");
        Console.WriteLine("  bag.Put(\"Laptop\");");
        Console.WriteLine("  int x = (int)bag.Take();  // <-- LOI O DAY!");
        Console.WriteLine();

        bag.Put("Laptop");
        try
        {
            // Compile OK, nhưng Runtime sẽ CRASH!
            int x = (int)bag.Take()!;  // InvalidCastException
            Console.WriteLine($"  Gia tri: {x}");
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine($"  RUNTIME ERROR: {ex.GetType().Name}");
            Console.WriteLine($"  Message: {ex.Message}");
            Console.WriteLine("  --> Compiler KHONG bat duoc loi nay!");
            Console.WriteLine("  --> Chi crash khi chay chuong trinh!\n");
        }

        // --- Ví dụ 4: Boxing / Unboxing - Hiệu năng kém ---
        Console.WriteLine("[4] BOXING / UNBOXING - Hieu nang kem:");
        Console.WriteLine("  Boxing  = nhiet to tien (int) vao phong bi (object)");
        Console.WriteLine("  Unboxing = mo phong bi lay to tien ra");
        Console.WriteLine();

        // Minh họa Boxing/Unboxing
        int originalValue = 42;
        Console.WriteLine($"  Gia tri goc (int): {originalValue}");

        object boxed = originalValue;  // BOXING: int → object (tốn bộ nhớ heap)
        Console.WriteLine($"  Sau Boxing (object): {boxed}");

        int unboxed = (int)boxed;      // UNBOXING: object → int (tốn CPU)
        Console.WriteLine($"  Sau Unboxing (int): {unboxed}");

        int numberV2 = 100;
        object obj = numberV2;  // boxing
        int numberV3 = (int)obj;  // unboxing
        
        

        Console.WriteLine();
        Console.WriteLine("  --> Neu lam hang trieu lan → chuong trinh CHAM di rat nhieu!");

        // Demo hiệu năng
        Console.WriteLine("\n[5] So sanh hieu nang Boxing vs Non-Boxing:");
        var sw = System.Diagnostics.Stopwatch.StartNew();
        long sum1 = 0;
        for (int i = 0; i < 5_000_000; i++)
        {
            object boxedVal = i;           // Boxing
            sum1 += (int)boxedVal;         // Unboxing
        }
        sw.Stop();
        Console.WriteLine($"  Voi Boxing/Unboxing (5 trieu lan): {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        long sum2 = 0;
        for (int i = 0; i < 5_000_000; i++)
        {
            sum2 += i;                     // Không boxing
        }
        sw.Stop();
        Console.WriteLine($"  Khong Boxing (5 trieu lan):         {sw.ElapsedMilliseconds} ms");
        Console.WriteLine("  --> Boxing cham hon rat nhieu!\n");

        // --- Tổng kết 3 vấn đề ---
        Console.WriteLine("=== TONG KET 3 VAN DE KHI DUNG OBJECT ===");
        Console.WriteLine("  1. Phai CAST thu cong        → de quen, de sai");
        Console.WriteLine("  2. KHONG TYPE-SAFE           → loi chi phat hien luc chay");
        Console.WriteLine("  3. BOXING / UNBOXING         → hieu nang kem\n");
    }
}
