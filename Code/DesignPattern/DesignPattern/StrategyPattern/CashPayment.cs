namespace DesignPattern.StrategyPattern;

// CONCRETE STRATEGY - Thanh toan bang tien mat
public class CashPayment : IPaymentStrategy
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Paid {amount} using Cash");
    }
}
