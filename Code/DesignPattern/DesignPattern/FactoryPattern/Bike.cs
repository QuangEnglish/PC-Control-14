namespace DesignPattern.FactoryPattern;

// CONCRETE PRODUCT
public class Bike : IVehicle
{
    public void Run()
    {
        Console.WriteLine("Bike is running");
    }
}
