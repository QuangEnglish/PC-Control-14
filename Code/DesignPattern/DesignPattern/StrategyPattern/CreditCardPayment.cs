namespace DesignPattern.StrategyPattern;

// CONCRETE STRATEGY - Thanh toan bang Credit Card
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Paid {amount} using Credit Card");
    }
}
