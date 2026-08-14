namespace DesignPattern.DependencyInjection;

// CONCRETE - Thiet bi cu the: Quat
public class Fan : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Quat chay");
    }
}
