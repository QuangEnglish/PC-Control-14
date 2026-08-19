namespace DesignPattern.SingletonPattern;

public class Singleton
{
    // Bien static luu instance duy nhat
    private static Singleton _instance;

    // Constructor private de khong cho tao tu ben ngoai
    private Singleton()
    {
        Console.WriteLine("Singleton instance created");
    }

    // Phuong thuc lay instance
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }

        return _instance;
    }

    public void ShowMessage()
    {
        Console.WriteLine("Hello from Singleton");
    }
}
