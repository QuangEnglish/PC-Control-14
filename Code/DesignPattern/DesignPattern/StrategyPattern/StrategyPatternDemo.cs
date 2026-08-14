namespace DesignPattern.StrategyPattern;

public class StrategyPatternDemo
{
    public static void Run()
    {
        Console.WriteLine("====== STRATEGY PATTERN DEMO ======\n");

        PaymentContext payment = new PaymentContext();

        // Chon strategy: Credit Card
        Console.WriteLine("--- Thanh toan bang Credit Card ---");
        payment.SetStrategy(new CreditCardPayment());
        payment.ExecutePayment(100);

        // Doi strategy: PayPal (thay doi thuat toan luc runtime)
        Console.WriteLine("\n--- Doi sang PayPal ---");
        payment.SetStrategy(new PayPalPayment());
        payment.ExecutePayment(200);

        // Doi strategy: Cash
        Console.WriteLine("\n--- Doi sang Cash ---");
        payment.SetStrategy(new CashPayment());
        payment.ExecutePayment(50);
    }
}
