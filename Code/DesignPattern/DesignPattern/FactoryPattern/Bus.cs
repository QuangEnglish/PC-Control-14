namespace DesignPattern.FactoryPattern;

// CONCRETE PRODUCT
public class Bus : IVehicle
{
    public void Run()
    {
        Console.WriteLine("Bus is running");
    }
}
