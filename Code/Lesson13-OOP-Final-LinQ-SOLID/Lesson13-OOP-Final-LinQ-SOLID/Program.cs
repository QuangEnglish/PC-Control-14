namespace Lesson13_OOP_Final_LinQ_SOLID;

class Program
{
    static void Main(string[] args)
    {
        // Biểu thức LINQ
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        List<Student> students = new()
        {
            new Student { Id = 1, Name = "An", Age = 18, Score = 8.5 },
            new Student { Id = 2, Name = "Bình", Age = 20, Score = 6.5 },
            new Student { Id = 3, Name = "Cường", Age = 22, Score = 9.2 },
            new Student { Id = 4, Name = "Dung", Age = 19, Score = 7.0 },
            new Student { Id = 5, Name = "Em", Age = 21, Score = 8.8 }
        };
        
        // Lấy các sinh viên điểm phải trên 8
        // Cách comment nhanh khối code: bôi đen khối code cần comment xong Ctrl + Shift + /
        // Tìm kiếm tên file nhanh: Shift + Shift
        // Tìm từ hoặc 1 cụm từ gì đấy trong project thì : Ctrl + Shift + F
        
        
        List<Student> listResult = new List<Student>();
        
        /*foreach (var student in students)
        {
            if (student.Score > 8)
            {
                listResult.Add(student);
            }
        }*/
        
        // Có 2 cách viết LINQ
        // Cách 1: dùng Method Syntax 
        listResult = students.Where(x => x.Score > 8).ToList();
        // Cách 2: Query Syntax
        var result = from s in students where s.Score > 8 select s;
        listResult = (from s in students where s.Score > 8 select s).ToList();
        
        // 
        var studentPC14 = students.Where(s => s.Score > 8)
            .OrderByDescending(s => s.Score)
            .Select(s => new
            {
                s.Id,
                s.Name,
                s.Score
            })
            .ToList();
        

        Console.WriteLine("Danh sách sinh viên có điểm > 8 theo đề bài 2 là: ");
        foreach (var student in studentPC14)
        {
            Console.WriteLine("Học viên: "+student);
        }
        
        // === DEMO TOSTRING ===
        Console.WriteLine("\n=== Demo ToString ===");
        var svToString = students[0];
        Console.WriteLine($"Console.WriteLine(student) => {svToString}");

        // === DEMO EQUALS ===
        Console.WriteLine("\n=== Demo Equals ===");
        var sv1 = new Student { Id = 1, Name = "An", Age = 18, Score = 8.5 };
        var sv2 = new Student { Id = 1, Name = "Khác Tên", Age = 99, Score = 0 };
        var sv3 = sv1;
        sv3.Score = 10000;

        Console.WriteLine($"sv1: {sv1}");
        Console.WriteLine($"sv2: {sv2}");
        Console.WriteLine($"sv3 = sv1 (cùng tham chiếu)");
        Console.WriteLine();
        Console.WriteLine($"sv1.Equals(sv2) = {sv1.Equals(sv2)}"); // True - vì cùng Id = 1
        Console.WriteLine($"sv1.Equals(sv3) = {sv1.Equals(sv3)}"); // True
        Console.WriteLine($"sv1 == sv2 = {sv1 == sv2}");           // False - == vẫn so sánh tham chiếu
        Console.WriteLine($"sv1 == sv3 = {sv1 == sv3}");           // True - cùng tham chiếu

        // Demo thực tế: Contains gọi Equals bên trong
        Console.WriteLine();
        var searchStudent = new Student { Id = 3, Name = "Test", Age = 0, Score = 0 };
        bool found = students.Contains(searchStudent);
        Console.WriteLine($"Tìm student có Id=3 trong danh sách: {found}"); // True - vì Equals chỉ so sánh Id

        // Kiến thức đẳng cấp : Nguyên tắc thiết kế SOLID
        // S: 
        // ý nghĩa: 1 class chỉ đảm nhận 1 trách nhiệm
        

    }
}