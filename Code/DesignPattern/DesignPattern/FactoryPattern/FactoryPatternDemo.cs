namespace DesignPattern.FactoryPattern;

public class FactoryPatternDemo
{
    public static void Run()
    {
        Console.WriteLine("====== FACTORY PATTERN DEMO ======\n");

        // Factory se quyet dinh tao object nao dua tren type truyen vao
        IVehicle vehicle1 = VehicleFactory.CreateVehicle("car");
        vehicle1.Run();

        IVehicle vehicle2 = VehicleFactory.CreateVehicle("bike");
        vehicle2.Run();

        IVehicle vehicle3 = VehicleFactory.CreateVehicle("truck");
        vehicle3.Run();

        // Demo: Khong can biet class cu the, chi lam viec voi IVehicle
        Console.WriteLine("\n--- Tao vehicle tu input ---");
        string[] types = { "car", "bike", "truck" };
        foreach (string type in types)
        {
            IVehicle v = VehicleFactory.CreateVehicle(type);
            Console.Write($"Type '{type}' => ");
            v.Run();
        }
    }
}
