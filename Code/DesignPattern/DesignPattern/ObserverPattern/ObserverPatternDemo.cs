namespace DesignPattern.ObserverPattern;

public class ObserverPatternDemo
{
    public static void Run()
    {
        Console.WriteLine("====== OBSERVER PATTERN DEMO ======\n");

        Stock stock = new Stock();

        // Tao 3 nha dau tu (Observer)
        Investor inv1 = new Investor("Alice");
        Investor inv2 = new Investor("Bob");
        Investor inv3 = new Investor("Charlie");

        // Dang ky theo doi gia co phieu (Attach)
        stock.Attach(inv1);
        stock.Attach(inv2);
        stock.Attach(inv3);

        // Gia thay doi => tat ca observers nhan thong bao
        Console.WriteLine("--- Gia co phieu thay doi: 100 ---");
        stock.SetPrice(100);

        Console.WriteLine("\n--- Gia co phieu thay doi: 120 ---");
        stock.SetPrice(120);

        // Bob huy dang ky (Detach)
        Console.WriteLine("\n--- Bob huy theo doi ---");
        stock.Detach(inv2);

        Console.WriteLine("\n--- Gia co phieu thay doi: 150 ---");
        stock.SetPrice(150);
    }
}
