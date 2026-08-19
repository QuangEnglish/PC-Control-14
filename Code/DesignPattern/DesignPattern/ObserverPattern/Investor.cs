namespace DesignPattern.ObserverPattern;

// CONCRETE OBSERVER - Nha dau tu nhan thong bao gia co phieu
public class Investor : IObserver
{
    private string _name;

    public Investor(string name)
    {
        _name = name;
    }

    public void Update(float price)
    {
        Console.WriteLine($"{_name} received stock price update: {price}");
    }
}
