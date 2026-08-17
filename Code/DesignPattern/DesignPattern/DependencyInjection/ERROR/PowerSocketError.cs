namespace DesignPattern.DependencyInjection;

public class PowerSocketError
{
    private Fan _fan = new Fan();
    private Laptop _lapTop = new Laptop();
    
    // Tight Coupling : bị phụ thuộc
    
    public PowerSocketError(Fan device)
    {
        _fan = device;
    }

    public void SupplyPower()
    {
        Console.WriteLine("O dien cap nguon...");
        _fan.TurnOn();
    }
}
