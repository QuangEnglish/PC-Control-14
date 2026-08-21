namespace ConsoleApp1;

// =====================================================
// CÁC MODEL DÙNG CHUNG CHO CÁC VÍ DỤ
// =====================================================

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }

    public override string ToString() => $"[{Id}] {Name} - {Price:N0} VND";
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }

    public override string ToString() => $"[{Id}] {Name} (Age: {Age})";
}

// Interface dùng cho bài tập Repository<T>
public interface IEntity
{
    int Id { get; set; }
}

public class ProductEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }

    public override string ToString() => $"[{Id}] {Name} - {Price:N0} VND";
}

public class StudentEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }

    public override string ToString() => $"[{Id}] {Name} (Age: {Age})";
}
