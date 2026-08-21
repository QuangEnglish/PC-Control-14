namespace ConsoleApp1;

// =====================================================
// PHẦN 5 – GENERIC METHOD
// Generic không chỉ cho class, mà còn cho method
// Viết 1 method, dùng cho MỌI kiểu dữ liệu
// =====================================================

public static class GenericMethods
{
    // --- Ví dụ 1: Swap - Đổi chỗ 2 giá trị ---
    // ref: truyền tham chiếu để thay đổi giá trị gốc
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    // --- Ví dụ 2: FindFirst - Tìm phần tử đầu tiên thỏa điều kiện ---
    // Func<T, bool>: delegate nhận T trả về bool (điều kiện lọc)
    public static T? FindFirst<T>(T[] array, Func<T, bool> condition)
    {
        foreach (T item in array)
        {
            if (condition(item)) return item;
        }
        return default(T);  // Trả về giá trị mặc định nếu không tìm thấy
    }

    // --- Ví dụ 3: PrintArray - In tất cả phần tử ---
    public static void PrintArray<T>(T[] array, string label = "Mang")
    {
        Console.Write($"  {label}: [");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i < array.Length - 1) Console.Write(", ");
        }
        Console.WriteLine("]");
    }

    // --- Ví dụ 4: CountIf - Đếm phần tử thỏa điều kiện ---
    public static int CountIf<T>(T[] array, Func<T, bool> condition)
    {
        int count = 0;
        foreach (T item in array)
        {
            if (condition(item)) count++;
        }
        return count;
    }

    // --- Ví dụ 5: ConvertAll - Chuyển đổi kiểu cho mỗi phần tử ---
    // TInput → TOutput: 2 type parameter
    public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Func<TInput, TOutput> converter)
    {
        TOutput[] result = new TOutput[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = converter(array[i]);
        }
        return result;
    }
}

public static class Part5_Demo
{
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("PHAN 5 - GENERIC METHOD");
        Console.WriteLine("(Viet 1 method, dung cho moi kieu)");
        Console.WriteLine("========================================\n");

        // === VÍ DỤ 1: Swap<T> - Đổi chỗ ===
        Console.WriteLine("[1] Swap<T> - Doi cho 2 gia tri:");

        // Swap số nguyên
        int x = 5, y = 10;
        Console.WriteLine($"  Truoc khi swap: x = {x}, y = {y}");
        GenericMethods.Swap(ref x, ref y);  // Compiler tự suy ra T = int
        Console.WriteLine($"  Sau khi swap:   x = {x}, y = {y}");
        Console.WriteLine();

        // Swap chuỗi
        string name1 = "An", name2 = "Binh";
        Console.WriteLine($"  Truoc khi swap: name1 = {name1}, name2 = {name2}");
        GenericMethods.Swap(ref name1, ref name2);  // T = string
        Console.WriteLine($"  Sau khi swap:   name1 = {name1}, name2 = {name2}");
        Console.WriteLine();

        // Swap số thực
        double d1 = 3.14, d2 = 2.71;
        Console.WriteLine($"  Truoc khi swap: d1 = {d1}, d2 = {d2}");
        GenericMethods.Swap<double>(ref d1, ref d2);  // Chỉ định T = double rõ ràng
        Console.WriteLine($"  Sau khi swap:   d1 = {d1}, d2 = {d2}");
        Console.WriteLine("  --> 1 method Swap, dung cho int, string, double,...!\n");

        // === VÍ DỤ 2: FindFirst<T> ===
        Console.WriteLine("[2] FindFirst<T> - Tim phan tu dau tien thoa dieu kien:");

        // Tìm trong mảng số
        int[] ages = { 18, 22, 30, 15, 25 };
        GenericMethods.PrintArray(ages, "Cac do tuoi");
        int firstOver20 = GenericMethods.FindFirst(ages, x => x > 20);
        Console.WriteLine($"  Tim nguoi > 20 tuoi dau tien: {firstOver20}");
        Console.WriteLine();

        // Tìm trong mảng chuỗi
        string[] names = { "An", "Binh", "Chi", "Dung", "Em" };
        GenericMethods.PrintArray(names, "Cac ten  ");
        string? bName = GenericMethods.FindFirst(names, n => n.StartsWith("B"));
        Console.WriteLine($"  Tim ten bat dau bang 'B': {bName}");

        string? longName = GenericMethods.FindFirst(names, n => n.Length > 3);
        Console.WriteLine($"  Tim ten dai hon 3 ky tu: {longName}");
        Console.WriteLine();

        // Tìm trong mảng đối tượng
        Product[] products =
        {
            new Product { Id = 1, Name = "Chuot", Price = 200_000 },
            new Product { Id = 2, Name = "Ban phim", Price = 500_000 },
            new Product { Id = 3, Name = "Man hinh", Price = 5_000_000 },
        };
        Product? expensive = GenericMethods.FindFirst(products, p => p.Price > 1_000_000);
        Console.WriteLine($"  San pham > 1 trieu dau tien: {expensive}\n");

        // === VÍ DỤ 3: CountIf<T> ===
        Console.WriteLine("[3] CountIf<T> - Dem phan tu thoa dieu kien:");

        int countAdult = GenericMethods.CountIf(ages, a => a >= 18);
        Console.WriteLine($"  So nguoi >= 18 tuoi: {countAdult}");

        int countShortName = GenericMethods.CountIf(names, n => n.Length <= 2);
        Console.WriteLine($"  So ten <= 2 ky tu: {countShortName}");

        int countCheap = GenericMethods.CountIf(products, p => p.Price < 1_000_000);
        Console.WriteLine($"  So san pham < 1 trieu: {countCheap}\n");

        // === VÍ DỤ 4: ConvertAll<TInput, TOutput> ===
        Console.WriteLine("[4] ConvertAll<TInput, TOutput> - Chuyen doi kieu:");

        // int[] → string[]
        int[] numbers = { 1, 2, 3, 4, 5 };
        GenericMethods.PrintArray(numbers, "So nguyen ");
        string[] strings = GenericMethods.ConvertAll(numbers, n => $"So_{n}");
        GenericMethods.PrintArray(strings, "Chuoi     ");
        Console.WriteLine();

        // string[] → int[] (độ dài chuỗi)
        string[] words = { "Hello", "Hi", "Generic", "C#" };
        GenericMethods.PrintArray(words, "Cac tu      ");
        int[] lengths = GenericMethods.ConvertAll(words, w => w.Length);
        GenericMethods.PrintArray(lengths, "Do dai chuoi");
        Console.WriteLine();

        // Product[] → string[] (chỉ lấy tên)
        string[] productNames = GenericMethods.ConvertAll(products, p => p.Name);
        GenericMethods.PrintArray(productNames, "Ten san pham");

        Console.WriteLine("\n  --> Tat ca vi du tren chi viet 1 METHOD nhung dung cho NHIEU KIEU du lieu!\n");
    }
}
