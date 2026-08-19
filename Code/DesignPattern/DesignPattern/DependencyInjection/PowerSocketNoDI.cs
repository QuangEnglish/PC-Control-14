namespace DesignPattern.DependencyInjection;

// KHONG DI - O dien gan chet voi Quat (Tight Coupling)
// Muon cam thiet bi khac => phai sua code class nay
public class PowerSocketNoDI
{
    private Fan _fan = new Fan();

    public void SupplyPower()
    {
        Console.WriteLine("O dien (KHONG DI) cap nguon...");
        _fan.TurnOn();
    }
}
