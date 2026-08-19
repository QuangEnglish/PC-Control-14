namespace DesignPattern.BuilderPattern;

// PRODUCT - Object can tao
public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine("=== Thong tin Computer ===");
        Console.WriteLine($"CPU: {CPU}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"Storage: {Storage}");
        Console.WriteLine($"GPU: {GPU}");
        Console.WriteLine();
    }
}


public record ComputerV2
{
    public string CPU { get; init; }
    public string RAM { get; init; }
}