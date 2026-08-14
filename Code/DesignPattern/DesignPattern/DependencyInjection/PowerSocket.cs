namespace DesignPattern.DependencyInjection;

// CO DI - O dien nhan thiet bi tu ben ngoai qua Constructor Injection
// Khong can biet thiet bi cu the la gi, chi can la IDevice
public class PowerSocket
{
    private readonly IDevice _device;

    // Constructor Injection: thiet bi duoc inject tu ben ngoai
    public PowerSocket(IDevice device)
    {
        _device = device;
    }

    public void SupplyPower()
    {
        Console.WriteLine("O dien cap nguon...");
        _device.TurnOn();
    }
}
