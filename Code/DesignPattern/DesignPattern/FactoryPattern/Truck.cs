namespace DesignPattern.FactoryPattern;

// CONCRETE PRODUCT
public class Truck : IVehicle
{
    public void Run()
    {
        Console.WriteLine("Truck is running");
    }
}
