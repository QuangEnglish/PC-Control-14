namespace DesignPattern.StrategyPattern;

// CONTEXT - Su dung Strategy de thuc hien thanh toan
public class PaymentContext
{
    private IPaymentStrategy _strategy;

    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecutePayment(int amount)
    {
        _strategy.Pay(amount);
    }
}
