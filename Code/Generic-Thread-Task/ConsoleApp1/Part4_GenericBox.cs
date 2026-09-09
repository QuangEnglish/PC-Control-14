namespace ConsoleApp1;

// =====================================================
// PHẦN 4 – GENERIC LÀ GÌ? – HỘP THẦN KỲ
// Generic = Khuôn bánh: 1 khuôn, làm mọi loại bánh
// T = Type Parameter (placeholder cho kiểu dữ liệu)
// =====================================================

// Generic class: Box<T>
// T là placeholder - khi sử dụng sẽ thay bằng kiểu cụ thể
public class Box<T>
{
    private T? _item;

    public void Put(T value)
    {
        _item = value;
        Console.WriteLine($"  Da cho vao hop: {value}");
    }

    public T? Take()
    {
        Console.WriteLine($"  Lay ra tu hop: {_item}");
        return _item;
    }
}

// Generic class với nhiều Type Parameter
public class Pair<TFirst, TSecond>
{
    public TFirst? First { get; set; }
    public TSecond? Second { get; set; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }

    public override string ToString() => $"({First}, {Second})";
}

public static class Part4_Demo
{
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("PHAN 4 - GENERIC LA GI? - HOP THAN KY");
        Console.WriteLine("(Box<T> - Viet 1 lan, dung mai mai)");
        Console.WriteLine("========================================\n");

        // --- Ví dụ 1: Box<int> - Hộp chứa số nguyên ---
        Console.WriteLine("[1] Box<int> - Hop chua so nguyen:");
        Box<int> numberBox = new Box<int>();
        numberBox.Put(10);
        int value = numberBox.Take()!;     // Không cần cast!
        Console.WriteLine($"  Gia tri: {value}");
        Console.WriteLine("  --> KHONG can cast! Compiler tu biet kieu la int\n");

        // --- Ví dụ 2: Box<string> - Hộp chứa chuỗi ---
        Console.WriteLine("[2] Box<string> - Hop chua chuoi:");
        Box<string> textBox = new Box<string>();
        textBox.Put("Xin chao Generic!");
        string text = textBox.Take()!;
        Console.WriteLine($"  Gia tri: {text}\n");

        // --- Ví dụ 3: Box<Product> - Hộp chứa đối tượng ---
        Console.WriteLine("[3] Box<Product> - Hop chua doi tuong:");
        Box<Product> productBox = new Box<Product>();
        productBox.Put(new Product { Id = 1, Name = "iPhone 16", Price = 25_000_000 });
        Product? phone = productBox.Take();
        Console.WriteLine($"  San pham: {phone}\n");

        // --- Ví dụ 4: TYPE-SAFE - Compiler bắt lỗi ngay ---
        Console.WriteLine("[4] TYPE-SAFE - Compiler bat loi ngay:");
        Console.WriteLine("  Box<int> safeBox = new Box<int>();");
        Console.WriteLine("  safeBox.Put(\"Hello\");  // <-- LOI COMPILE! Khong cho bo string vao Box<int>");
        Console.WriteLine("  --> Generic giup phat hien loi NGAY LUC VIET CODE, khong doi den luc chay!\n");

        // Nếu uncomment dòng dưới → Compile Error (đây là điều tốt!)
        // Box<int> safeBox = new Box<int>();
        // safeBox.Put("Hello");  // Error CS1503: cannot convert from 'string' to 'int'

        // --- Ví dụ 5: So sánh Object vs Generic ---
        Console.WriteLine("[5] SO SANH: Object (Bag) vs Generic (Box<T>):");
        Console.WriteLine("  ┌─────────────────────┬───────────────────┬───────────────────┐");
        Console.WriteLine("  │     Tieu chi        │   Bag (object)    │   Box<T> (Generic)│");
        Console.WriteLine("  ├─────────────────────┼───────────────────┼───────────────────┤");
        Console.WriteLine("  │ Can cast?           │   Co (thu cong)   │   KHONG           │");
        Console.WriteLine("  │ Type-safe?          │   KHONG           │   CO              │");
        Console.WriteLine("  │ Boxing/Unboxing?    │   CO (cham)       │   KHONG (nhanh)   │");
        Console.WriteLine("  │ Loi phat hien khi?  │   Runtime (crash) │   Compile (an toan│");
        Console.WriteLine("  │ Tai su dung?        │   CO              │   CO              │");
        Console.WriteLine("  └─────────────────────┴───────────────────┴───────────────────┘\n");

        // --- Ví dụ 6: Pair<TFirst, TSecond> - Nhiều Type Parameter ---
        Console.WriteLine("[6] Pair<TFirst, TSecond> - Nhieu Type Parameter:");

        Pair<string, int> studentAge = new Pair<string, int>("Nguyen Van An", 20);
        Console.WriteLine($"  Sinh vien: {studentAge}");

        Pair<string, string> phoneBook = new Pair<string, string>("An", "0901234567");
        Console.WriteLine($"  Danh ba: {phoneBook}");

        Pair<int, Product> indexedProduct = new Pair<int, Product>(
            1, new Product { Id = 1, Name = "MacBook Pro", Price = 50_000_000 });
        Console.WriteLine($"  San pham co index: {indexedProduct}\n");

        // --- Tổng kết lợi ích ---
        Console.WriteLine("=== LOI ICH CUA GENERIC ===");
        Console.WriteLine("  1. TYPE-SAFE     - Compiler kiem tra ngay tu luc viet code");
        Console.WriteLine("  2. KHONG CAST    - Khong can ep kieu thu cong");
        Console.WriteLine("  3. KHONG BOXING  - Hieu nang tot hon");
        Console.WriteLine("  4. TAI SU DUNG   - Viet 1 lan, dung mai mai voi moi kieu\n");
    }
}
