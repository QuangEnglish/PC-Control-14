namespace DesignPattern.FactoryPattern;

// FACTORY - Class chiu trach nhiem tao object
public class VehicleFactory
{
    public static IVehicle CreateVehicle(string type)
    {
        if (type == "car")
            return new Car();

        if (type == "bike")
            return new Bike();

        if (type == "truck")
            return new Truck();
        
        if (type == "bus")
            return new Bus();

        throw new Exception($"Vehicle type '{type}' not found");
    }
}
