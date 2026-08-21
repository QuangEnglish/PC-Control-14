namespace ConsoleApp1;

// =====================================================
// PHẦN 7 – GENERIC TRONG .NET THỰC TẾ
// Các collection phổ biến đều là Generic
// =====================================================

public static class Part7_Demo
{
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("PHAN 7 - GENERIC TRONG .NET THUC TE");
        Console.WriteLine("(List<T>, Dictionary<K,V>, IEnumerable<T>)");
        Console.WriteLine("========================================\n");

        // === 1. List<T> ===
        Console.WriteLine("[1] List<T> - Danh sach dong:");
        List<string> students = new List<string> { "An", "Binh", "Chi", "Dung" };
        students.Add("Em");
        students.Remove("Chi");

        Console.WriteLine("  Danh sach sinh vien:");
        foreach (string s in students)
        {
            Console.WriteLine($"    - {s}");
        }
        Console.WriteLine($"  So luong: {students.Count}");
        Console.WriteLine($"  Phan tu dau: {students[0]}");
        Console.WriteLine($"  Co 'Binh' khong? {students.Contains("Binh")}");
        Console.WriteLine();

        // List<T> với đối tượng
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Chuot Logitech", Price = 350_000 },
            new Product { Id = 2, Name = "Ban phim co", Price = 1_200_000 },
            new Product { Id = 3, Name = "Tai nghe Sony", Price = 2_500_000 },
            new Product { Id = 4, Name = "Webcam HD", Price = 800_000 },
        };
        Console.WriteLine("  Danh sach san pham:");
        foreach (var p in products)
        {
            Console.WriteLine($"    {p}");
        }
        Console.WriteLine();

        // === 2. Dictionary<TKey, TValue> ===
        Console.WriteLine("[2] Dictionary<TKey, TValue> - Tu dien (cap key-value):");

        // Danh bạ điện thoại
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        phoneBook["An"] = "0901234567";
        phoneBook["Binh"] = "0988888888";
        phoneBook["Chi"] = "0977777777";

        Console.WriteLine("  Danh ba dien thoai:");
        foreach (var entry in phoneBook)
        {
            Console.WriteLine($"    {entry.Key}: {entry.Value}");
        }
        Console.WriteLine($"  SDT cua An: {phoneBook["An"]}");
        Console.WriteLine($"  Co 'Dung' khong? {phoneBook.ContainsKey("Dung")}");
        Console.WriteLine();

        // Dictionary với đối tượng
        Dictionary<int, Product> productCatalog = new Dictionary<int, Product>();
        foreach (var p in products)
        {
            productCatalog[p.Id] = p;
        }
        Console.WriteLine("  Tim san pham theo Id:");
        if (productCatalog.TryGetValue(2, out Product? found))
        {
            Console.WriteLine($"    Id=2: {found}");
        }
        Console.WriteLine();

        // Đếm từ - ứng dụng thực tế
        Console.WriteLine("  Ung dung: Dem so lan xuat hien cua moi tu:");
        string sentence = "generic la tuyet voi generic giup code sach hon generic";
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (string word in sentence.Split(' '))
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }
        foreach (var wc in wordCount)
        {
            Console.WriteLine($"    '{wc.Key}': {wc.Value} lan");
        }
        Console.WriteLine();

        // === 3. IEnumerable<T> và LINQ ===
        Console.WriteLine("[3] IEnumerable<T> + LINQ - Truy van du lieu:");

        // Where - Lọc
        var expensiveProducts = products.Where(p => p.Price > 1_000_000);
        Console.WriteLine("  San pham > 1 trieu (Where):");
        foreach (var p in expensiveProducts)
        {
            Console.WriteLine($"    {p}");
        }

        // OrderBy - Sắp xếp
        var sortedByPrice = products.OrderBy(p => p.Price);
        Console.WriteLine("  Sap xep theo gia tang dan (OrderBy):");
        foreach (var p in sortedByPrice)
        {
            Console.WriteLine($"    {p}");
        }

        // Select - Chuyển đổi
        IEnumerable<string> productNames = products.Select(p => p.Name);
        Console.WriteLine($"  Chi lay ten (Select): [{string.Join(", ", productNames)}]");

        // Aggregate
        decimal totalPrice = products.Sum(p => p.Price);
        decimal avgPrice = products.Average(p => p.Price);
        decimal maxPrice = products.Max(p => p.Price);
        Console.WriteLine($"  Tong gia: {totalPrice:N0} VND");
        Console.WriteLine($"  Gia TB:   {avgPrice:N0} VND");
        Console.WriteLine($"  Gia Max:  {maxPrice:N0} VND");
        Console.WriteLine();

        // First, FirstOrDefault
        Product? firstExpensive = products.FirstOrDefault(p => p.Price > 2_000_000);
        Console.WriteLine($"  San pham > 2 trieu dau tien: {firstExpensive}");
        Console.WriteLine();

        // === 4. Queue<T> và Stack<T> ===
        Console.WriteLine("[4] Queue<T> va Stack<T>:");

        // Queue - FIFO (First In, First Out) - như xếp hàng
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("Khach 1");
        queue.Enqueue("Khach 2");
        queue.Enqueue("Khach 3");
        Console.WriteLine($"  Queue (hang doi): Phuc vu truoc: {queue.Dequeue()}");
        Console.WriteLine($"  Queue: Tiep theo: {queue.Peek()}");

        // Stack - LIFO (Last In, First Out) - như chồng đĩa
        Stack<string> stack = new Stack<string>();
        stack.Push("Dia 1 (duoi cung)");
        stack.Push("Dia 2");
        stack.Push("Dia 3 (tren cung)");
        Console.WriteLine($"  Stack (chong dia): Lay ra: {stack.Pop()}");
        Console.WriteLine($"  Stack: Tren cung: {stack.Peek()}");
        Console.WriteLine();

        // === 5. HashSet<T> ===
        Console.WriteLine("[5] HashSet<T> - Tap hop khong trung lap:");
        HashSet<string> uniqueNames = new HashSet<string>();
        uniqueNames.Add("An");
        uniqueNames.Add("Binh");
        uniqueNames.Add("An");     // Trùng → bị bỏ qua
        uniqueNames.Add("Chi");
        uniqueNames.Add("Binh");   // Trùng → bị bỏ qua
        Console.WriteLine($"  Them 5 ten (2 trung): So phan tu = {uniqueNames.Count}");
        Console.WriteLine($"  Cac ten: [{string.Join(", ", uniqueNames)}]\n");

        // === Tổng kết ===
        Console.WriteLine("=== TAT CA COLLECTION TREN DEU LA GENERIC! ===");
        Console.WriteLine("  List<T>                  - Danh sach dong");
        Console.WriteLine("  Dictionary<TKey, TValue> - Tu dien key-value");
        Console.WriteLine("  IEnumerable<T>           - Nen tang cua LINQ");
        Console.WriteLine("  Queue<T>                 - Hang doi FIFO");
        Console.WriteLine("  Stack<T>                 - Ngan xep LIFO");
        Console.WriteLine("  HashSet<T>               - Tap hop khong trung\n");
    }
}
