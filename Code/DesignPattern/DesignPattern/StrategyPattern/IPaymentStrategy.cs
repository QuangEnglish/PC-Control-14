namespace DesignPattern.StrategyPattern;

// STRATEGY INTERFACE - Dinh nghia hanh vi chung cua cac thuat toan thanh toan
public interface IPaymentStrategy
{
    void Pay(int amount);
}
