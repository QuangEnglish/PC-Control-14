namespace DesignPattern.BuilderPattern;

public class BuilderPatternDemo
{
    public static void Run()
    {
        Console.WriteLine("====== BUILDER PATTERN DEMO ======\n");

        // Cach 1: Tao PC day du thuoc tinh
        Console.WriteLine("--- PC Gaming (day du thuoc tinh) ---");
        Computer gamingPC = new ComputerBuilder()
            .SetCPU("Intel i7-13700K")
            .SetRAM("32GB DDR5")
            .SetStorage("1TB SSD NVMe")
            .SetGPU("RTX 4070")
            .Build();

        gamingPC.ShowInfo();

        // Cach 2: Tao PC chi voi mot so thuoc tinh (linh hoat)
        Console.WriteLine("--- PC Van phong (chi can CPU va RAM) ---");
        Computer officePC = new ComputerBuilder()
            .SetCPU("Intel i3-12100")
            .SetRAM("8GB DDR4")
            .Build();

        officePC.ShowInfo();

        // Cach 3: Tao PC tung buoc (khong dung method chaining)
        Console.WriteLine("--- PC Server (tao tung buoc) ---");
        ComputerBuilder serverBuilder = new ComputerBuilder();
        serverBuilder.SetCPU("AMD EPYC 9654");
        serverBuilder.SetRAM("128GB ECC");
        serverBuilder.SetStorage("4TB SSD RAID");

        Computer serverPC = serverBuilder.Build();
        serverPC.ShowInfo();
    }
}
