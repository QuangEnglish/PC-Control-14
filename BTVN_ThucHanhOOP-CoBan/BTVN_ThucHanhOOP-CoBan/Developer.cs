namespace BTVN_ThucHanhOOP_CoBan;

public class Developer : Employee
{
    public override void Work()
    {
        Console.WriteLine("Deverloper dang lap trinh he thong");
    }

    public override void ShowInfo()
    {
        Console.WriteLine("====THONG TIN Deverloper====");
        Console.WriteLine($"ID              : {Id}");
        Console.WriteLine($"Name            : {Name}");
        Console.WriteLine($"Tuoi            : {Age}");
        Console.WriteLine($"Salary:         : {Salary}");
        Console.WriteLine($"Department      : {Department}");
        Console.WriteLine();
    }
    
}