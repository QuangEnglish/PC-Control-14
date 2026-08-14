namespace DesignPattern.DependencyInjection;

// CONCRETE - Thiet bi cu the: Laptop
public class Laptop : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Laptop sac pin");
    }
}
