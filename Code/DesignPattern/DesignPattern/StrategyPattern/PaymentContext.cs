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

// PaymentContext : là 1 thg quản lý 
// private IPaymentStrategy _strategy;    hình thức thanh toán
// SetStrategy  truyền hình thức thanh toán = tiền mặt 
// thì sau đó  hình thức thanh toán = thanh toan tiền mặt
// tính đa hình
// IPaymentStrategy strategy = new PayPalPayment();