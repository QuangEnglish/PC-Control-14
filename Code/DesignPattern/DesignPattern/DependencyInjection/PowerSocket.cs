namespace DesignPattern.DependencyInjection;

// CO DI - O dien nhan thiet bi tu ben ngoai qua Constructor Injection
// Khong can biet thiet bi cu the la gi, chi can la IDevice
public class PowerSocket
{
    private readonly IDevice _device;
    
    // Cách 1: inject thông qua Properties / Setter Injection
    /*public IDevice Device { get; set; }*/

    // Cách 2:  Constructor Injection: thiet bi duoc inject tu ben ngoai
    public PowerSocket(IDevice device)
    {
        _device = device;
    }

    public void SupplyPower()
    {
        Console.WriteLine("O dien cap nguon...");
        _device.TurnOn();
    }
    
    // Cách 3: method injection
    public void ProcessPower(IDevice device)
    {
        Console.WriteLine("O dien cap nguon...");
        device.TurnOn();
    }
}
