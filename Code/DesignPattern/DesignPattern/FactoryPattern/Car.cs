namespace DesignPattern.FactoryPattern;

// CONCRETE PRODUCT
public class Car : IVehicle
{
    public void Run()
    {
        Console.WriteLine("Car is running");
    }
}
