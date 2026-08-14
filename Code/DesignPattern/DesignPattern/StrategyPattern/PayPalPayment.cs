namespace DesignPattern.StrategyPattern;

// CONCRETE STRATEGY - Thanh toan bang PayPal
public class PayPalPayment : IPaymentStrategy
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Paid {amount} using PayPal");
    }
}
