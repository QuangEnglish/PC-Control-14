namespace DesignPattern.FactoryPattern;

public class FactoryPatternDemo
{
    public static void Run()
    {
        Car car = new Car();
        Bike bike = new Bike();
        Truck truck = new Truck();
        Bus bus = new Bus();
        /*Plane plane = new Plane();*/
        
        
        // plane , boat, bus
        
        
        Console.WriteLine("====== FACTORY PATTERN DEMO ======\n");

        // Factory se quyet dinh tao object nao dua tren type truyen vao
        IVehicle vehicleCar = VehicleFactory.CreateVehicle("car");
        vehicleCar.Run();
        
        IVehicle vehicleCarV2 = VehicleFactory.CreateVehicle("car");
        vehicleCarV2.Run();

        IVehicle vehicle2 = VehicleFactory.CreateVehicle("bike");
        vehicle2.Run();

        IVehicle vehicle3 = VehicleFactory.CreateVehicle("truck");
        vehicle3.Run();
        
        IVehicle vehicle4 = VehicleFactory.CreateVehicle("bus");
        vehicle4.Run();
        
        IVehicle vehicle5 = VehicleFactory.CreateVehicle("plane");
        vehicle5.Run();

        // Demo: Khong can biet class cu the, chi lam viec voi IVehicle
        Console.WriteLine("\n--- Tao vehicle tu input ---");
        string[] types = { "car", "bike", "truck", "plane" };
        foreach (string type in types)
        {
            IVehicle v = VehicleFactory.CreateVehicle(type);
            Console.Write($"Type '{type}' => ");
            v.Run();
        }
        
        // Factory Method Pattern / Abstract Factory Pattern 
        
        // So sánh với Singleton Pattern
        // Singleton : đảm bảo chỉ có 1 object được tạo
        // Factory: Quản lý việc tạo object (tạo nhiều object)
        
    }
}
