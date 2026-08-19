namespace Lesson13_OOP_Final_LinQ_SOLID;

public class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public double Score { get; set; }

    public override string ToString()
    {
        return $"Mã ID: {Id}, Tên: {Name}, Tuổi: {Age}, Điểm số: {Score}";
    }

    public override bool Equals(object? obj)
    {
        // Nếu obj null hoặc khác kiểu thì false
        if (obj is not Student other) return false;

        // So sánh theo giá trị các property
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}