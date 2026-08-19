namespace DesignPattern.DependencyInjection;

public class DIPatternDemo
{
    public static void Run()
    {
        Console.WriteLine("====== DEPENDENCY INJECTION DEMO ======\n");

        // === PHAN 1: KHONG DI (Tight Coupling) ===
        Console.WriteLine("--- KHONG DI: O dien gan chet voi Quat ---");
        PowerSocketNoDI socketNoDI = new PowerSocketNoDI();
        socketNoDI.SupplyPower();
        // Van de: muon cam Laptop => phai sua code PowerSocketNoDI

        // === PHAN 2: CO DI (Loose Coupling) ===
        Console.WriteLine("\n--- CO DI: O dien nhan thiet bi tu ben ngoai ---");

        // Cam Quat vao o dien
        Console.WriteLine("\n[Cam Quat]");
        IDevice fan = new Fan();
        PowerSocket socket1 = new PowerSocket(fan);
        socket1.SupplyPower();

        // Cam Laptop vao o dien - KHONG can sua code PowerSocket
        Console.WriteLine("\n[Cam Laptop]");
        IDevice laptop = new Laptop();
        PowerSocket socket2 = new PowerSocket(laptop);
        socket2.SupplyPower();

        // === PHAN 3: DE MO RONG ===
        // Them thiet bi moi chi can tao class moi implement IDevice
        // Khong can sua PowerSocket
        Console.WriteLine("\n--- Ket luan ---");
        Console.WriteLine("Class khong tu tao dependency");
        Console.WriteLine("Dependency duoc inject tu ben ngoai");
    }
}
