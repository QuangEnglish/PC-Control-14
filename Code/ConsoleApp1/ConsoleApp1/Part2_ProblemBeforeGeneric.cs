namespace ConsoleApp1;

// =====================================================
// PHẦN 2 – VẤN ĐỀ TRƯỚC KHI CÓ GENERIC
// Ví dụ: Tạo riêng từng loại hộp → Duplicate Code
// =====================================================

// Hộp chứa bánh
public class CakeBox
{
    
    // Generic
    
    private string _cake = "";

    public void Put(string value)
    {
        _cake = value;
        Console.WriteLine($"  Da cho vao hop banh: {value}");
    }

    public string Take()
    {
        Console.WriteLine($"  Lay ra tu hop banh: {_cake}");
        return _cake;
    }
}

// Hộp chứa điện thoại
public class PhoneBox
{
    private string _phone = "";

    public void Put(string value)
    {
        _phone = value;
        Console.WriteLine($"  Da cho vao hop dien thoai: {value}");
    }

    public string Take()
    {
        Console.WriteLine($"  Lay ra tu hop dien thoai: {_phone}");
        return _phone;
    }
}

// Hộp chứa sách - lại copy thêm 1 class nữa!
public class BookBox
{
    private string _book = "";

    public void Put(string value)
    {
        _book = value;
        Console.WriteLine($"  Da cho vao hop sach: {value}");
    }

    public string Take()
    {
        Console.WriteLine($"  Lay ra tu hop sach: {_book}");
        return _book;
    }
}

public static class Part2_Demo
{
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("PHAN 2 - VAN DE TRUOC KHI CO GENERIC");
        Console.WriteLine("(Duplicate Code - Copy paste class)");
        Console.WriteLine("========================================\n");

        // Vấn đề: Mỗi loại hộp cần 1 class riêng → code lặp lại!
        // CakeBox, PhoneBox, BookBox... cấu trúc giống nhau 90%

        Console.WriteLine("[1] Su dung CakeBox:");
        CakeBox cakeBox = new CakeBox();
        cakeBox.Put("Banh Chocolate");
        cakeBox.Take();

        Console.WriteLine("\n[2] Su dung PhoneBox:");
        PhoneBox phoneBox = new PhoneBox();
        phoneBox.Put("iPhone 16 Pro Max");
        phoneBox.Take();

        Console.WriteLine("\n[3] Su dung BookBox:");
        BookBox bookBox = new BookBox();
        bookBox.Put("Clean Code - Robert C. Martin");
        bookBox.Take();

        Console.WriteLine("\n--> VAN DE: 3 class gan nhu giong het nhau!");
        Console.WriteLine("--> Neu them ToyBox, LaptopBox... thi phai copy-paste them!");
        Console.WriteLine("--> Day la DUPLICATE CODE - dieu xau nhat trong lap trinh!\n");
    }
}
