namespace ConsoleApp1;

// =====================================================
// PHẦN 8 – BÀI TẬP THỰC HÀNH
// 3 bài tập áp dụng kiến thức Generic
// =====================================================

// =====================================================
// BÀI TẬP 1: GiftBox<T>
// Tạo hộp quà Generic với PutGift() và TakeGift()
// =====================================================
public class GiftBox<T>
{
    private T? gift;
    private bool hasGift;

    // Cho quà vào hộp
    public void PutGift(T gift)
    {
        this.gift = gift;
        hasGift = true;
        Console.WriteLine($"  Da goi qua: {gift}");
    }

    // Lấy quà ra khỏi hộp (chỉ lấy được 1 lần)
    public T? TakeGift()
    {
        if (!hasGift)
        {
            Console.WriteLine("  Hop qua rong!");
            return default(T);
        }

        T? result = gift;
        gift = default(T);
        hasGift = false;
        Console.WriteLine($"  Mo qua: {result}");
        return result;
    }

    public bool HasGift => hasGift;

    public override string ToString() =>
        hasGift ? $"GiftBox[{gift}]" : "GiftBox[rong]";
}

// =====================================================
// BÀI TẬP 2: FindMax<T>
// Tìm giá trị lớn nhất trong mảng
// Constraint: where T : IComparable<T>
// IComparable<T> đảm bảo T có thể so sánh được
// =====================================================
public static class MathHelper
{
    // Tìm giá trị lớn nhất
    public static T FindMax<T>(T[] arr) where T : IComparable<T>
    {
        if (arr.Length == 0)
            throw new ArgumentException("Mang khong duoc rong!");

        T max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            // CompareTo trả về:
            //   > 0 nếu arr[i] > max
            //   = 0 nếu arr[i] == max
            //   < 0 nếu arr[i] < max
            if (arr[i].CompareTo(max) > 0)
            {
                max = arr[i];
            }
        }
        return max;
    }

    // Bonus: Tìm giá trị nhỏ nhất
    public static T FindMin<T>(T[] arr) where T : IComparable<T>
    {
        if (arr.Length == 0)
            throw new ArgumentException("Mang khong duoc rong!");

        T min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(min) < 0)
            {
                min = arr[i];
            }
        }
        return min;
    }

    // Bonus: Sắp xếp mảng (Bubble Sort)
    public static void Sort<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    T temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

// =====================================================
// BÀI TẬP 3: Repository<T>
// Quản lý danh sách đối tượng (CRUD)
// Constraint: where T : class, IEntity, new()
// =====================================================
public class Repository<T> where T : class, IEntity, new()
{
    private readonly List<T> items = new List<T>();
    private int nextId = 1;

    // Thêm item (tự gán Id nếu chưa có)
    public void Add(T item)
    {
        if (item.Id == 0)
        {
            item.Id = nextId++;
        }
        else if (nextId <= item.Id)
        {
            nextId = item.Id + 1;
        }
        items.Add(item);
        Console.WriteLine($"  [Add] {item}");
    }

    // Lấy theo Id
    public T? GetById(int id)
    {
        return items.FirstOrDefault(x => x.Id == id);
    }

    // Lấy tất cả
    public List<T> GetAll()
    {
        return new List<T>(items);
    }

    // Xóa theo Id
    public bool Remove(int id)
    {
        T? item = GetById(id);
        if (item != null)
        {
            items.Remove(item);
            Console.WriteLine($"  [Remove] Da xoa Id={id}");
            return true;
        }
        Console.WriteLine($"  [Remove] Khong tim thay Id={id}");
        return false;
    }

    // Đếm số lượng
    public int Count => items.Count;

    // In tất cả
    public void PrintAll(string title = "Danh sach")
    {
        Console.WriteLine($"  === {title} ({items.Count} muc) ===");
        if (items.Count == 0)
        {
            Console.WriteLine("    (rong)");
            return;
        }
        foreach (T item in items)
        {
            Console.WriteLine($"    {item}");
        }
    }
}

// =====================================================
// DEMO TẤT CẢ BÀI TẬP
// =====================================================
public static class Part8_Demo
{
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("PHAN 8 - BAI TAP THUC HANH");
        Console.WriteLine("========================================\n");

        // === BÀI TẬP 1: GiftBox<T> ===
        Console.WriteLine("[BAI TAP 1] GiftBox<T> - Hop qua Generic:\n");

        // Hộp quà chứa string
        Console.WriteLine("  --- GiftBox<string> ---");
        GiftBox<string> stringGift = new GiftBox<string>();
        stringGift.PutGift("Tui xach Gucci");
        Console.WriteLine($"  Co qua khong? {stringGift.HasGift}");
        stringGift.TakeGift();
        Console.WriteLine($"  Co qua khong? {stringGift.HasGift}");
        stringGift.TakeGift();  // Thử lấy lần 2 → rỗng
        Console.WriteLine();

        // Hộp quà chứa int (tiền mừng)
        Console.WriteLine("  --- GiftBox<int> ---");
        GiftBox<int> moneyGift = new GiftBox<int>();
        moneyGift.PutGift(500_000);
        int money = moneyGift.TakeGift();
        Console.WriteLine($"  So tien nhan duoc: {money:N0} VND");
        Console.WriteLine();

        // Hộp quà chứa Product
        Console.WriteLine("  --- GiftBox<Product> ---");
        GiftBox<Product> productGift = new GiftBox<Product>();
        productGift.PutGift(new Product { Id = 1, Name = "AirPods Pro", Price = 5_000_000 });
        Product? myGift = productGift.TakeGift();
        Console.WriteLine($"  Qua nhan duoc: {myGift}");
        Console.WriteLine();

        // === BÀI TẬP 2: FindMax<T> ===
        Console.WriteLine("[BAI TAP 2] FindMax<T> - Tim gia tri lon nhat:\n");

        // FindMax với int
        int[] numbers = { 42, 17, 85, 3, 66, 91, 28 };
        Console.Write("  Mang int: [");
        Console.Write(string.Join(", ", numbers));
        Console.WriteLine("]");
        Console.WriteLine($"  Max: {MathHelper.FindMax(numbers)}");
        Console.WriteLine($"  Min: {MathHelper.FindMin(numbers)}");
        Console.WriteLine();

        // FindMax với double
        double[] decimals = { 3.14, 2.71, 1.41, 9.81, 6.28 };
        Console.Write("  Mang double: [");
        Console.Write(string.Join(", ", decimals));
        Console.WriteLine("]");
        Console.WriteLine($"  Max: {MathHelper.FindMax(decimals)}");
        Console.WriteLine($"  Min: {MathHelper.FindMin(decimals)}");
        Console.WriteLine();

        // FindMax với string (so sánh theo alphabet)
        string[] names = { "Chi", "An", "Em", "Binh", "Dung" };
        Console.Write("  Mang string: [");
        Console.Write(string.Join(", ", names));
        Console.WriteLine("]");
        Console.WriteLine($"  Max (alphabet): {MathHelper.FindMax(names)}");
        Console.WriteLine($"  Min (alphabet): {MathHelper.FindMin(names)}");
        Console.WriteLine();

        // FindMax với DateTime
        DateTime[] dates =
        {
            new DateTime(2024, 1, 15),
            new DateTime(2025, 6, 20),
            new DateTime(2023, 12, 1),
        };
        Console.Write("  Mang DateTime: [");
        Console.Write(string.Join(", ", dates.Select(d => d.ToString("dd/MM/yyyy"))));
        Console.WriteLine("]");
        Console.WriteLine($"  Ngay moi nhat: {MathHelper.FindMax(dates):dd/MM/yyyy}");
        Console.WriteLine($"  Ngay cu nhat:  {MathHelper.FindMin(dates):dd/MM/yyyy}");
        Console.WriteLine();

        // Bonus: Sort
        Console.WriteLine("  Bonus - Sort<T>:");
        int[] unsorted = { 64, 34, 25, 12, 22, 11, 90 };
        Console.Write("    Truoc: [");
        Console.Write(string.Join(", ", unsorted));
        Console.WriteLine("]");
        MathHelper.Sort(unsorted);
        Console.Write("    Sau:   [");
        Console.Write(string.Join(", ", unsorted));
        Console.WriteLine("]");
        Console.WriteLine();

        // === BÀI TẬP 3: Repository<T> ===
        Console.WriteLine("[BAI TAP 3] Repository<T> - Quan ly danh sach (CRUD):\n");

        // Repository cho Product
        Console.WriteLine("  --- Repository<ProductEntity> ---");
        Repository<ProductEntity> productRepo = new Repository<ProductEntity>();
        productRepo.Add(new ProductEntity { Name = "Laptop Dell", Price = 20_000_000 });
        productRepo.Add(new ProductEntity { Name = "Chuot Logitech", Price = 350_000 });
        productRepo.Add(new ProductEntity { Name = "Ban phim co", Price = 1_200_000 });
        Console.WriteLine();

        productRepo.PrintAll("San pham");
        Console.WriteLine();

        ProductEntity? p = productRepo.GetById(2);
        Console.WriteLine($"  Tim Id=2: {p}");
        Console.WriteLine();

        productRepo.Remove(2);
        productRepo.PrintAll("San pham sau khi xoa Id=2");
        Console.WriteLine();

        // Repository cho Student
        Console.WriteLine("  --- Repository<StudentEntity> ---");
        Repository<StudentEntity> studentRepo = new Repository<StudentEntity>();
        studentRepo.Add(new StudentEntity { Name = "Nguyen Van An", Age = 20 });
        studentRepo.Add(new StudentEntity { Name = "Tran Thi Binh", Age = 22 });
        studentRepo.Add(new StudentEntity { Name = "Le Van Chi", Age = 19 });
        Console.WriteLine();

        studentRepo.PrintAll("Sinh vien");
        Console.WriteLine();

        Console.WriteLine($"  Tong so sinh vien: {studentRepo.Count}");
        StudentEntity? sv = studentRepo.GetById(1);
        Console.WriteLine($"  Tim Id=1: {sv}");
        Console.WriteLine();

        // === TỔNG KẾT ===
        Console.WriteLine("=== TONG KET BUOI HOC ===");
        Console.WriteLine("  1. Duplicate code  → Generic giai quyet bang cach viet 1 lan");
        Console.WriteLine("  2. Object (boxing) → Generic khong can cast, khong boxing");
        Console.WriteLine("  3. Generic class   → Box<T>, GiftBox<T>, Repository<T>");
        Console.WriteLine("  4. Generic method  → Swap<T>, FindMax<T>, FindFirst<T>");
        Console.WriteLine("  5. Constraint      → where T : class/struct/new()/interface/base");
        Console.WriteLine("  6. .NET collection → List<T>, Dictionary<K,V>, IEnumerable<T>...");
        Console.WriteLine();
        Console.WriteLine("  *** Generic giong cai KHUON BANH ***");
        Console.WriteLine("  *** Chi 1 khuon nhung lam duoc moi loai banh! ***\n");
    }
}
