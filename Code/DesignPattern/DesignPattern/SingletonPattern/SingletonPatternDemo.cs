namespace DesignPattern.SingletonPattern;

public class SingletonPatternDemo
{
    public static void Run()
    {
        Console.WriteLine("====== SINGLETON PATTERN DEMO ======\n");

        // Lan 1: instance == null => tao object moi
        Singleton s1 = Singleton.GetInstance();

        // Lan 2: instance da ton tai => tra lai object cu
        Singleton s2 = Singleton.GetInstance();

        s1.ShowMessage();

        // Kiem tra s1 va s2 co phai cung 1 object khong
        bool isSame = Object.ReferenceEquals(s1, s2);
        Console.WriteLine($"\ns1 va s2 cung 1 object? {isSame}");
        Console.WriteLine($"s1 HashCode: {s1.GetHashCode()}");
        Console.WriteLine($"s2 HashCode: {s2.GetHashCode()}");
    }
    
}
