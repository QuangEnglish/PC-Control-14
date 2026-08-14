using DesignPattern.SingletonPattern;
using DesignPattern.FactoryPattern;
using DesignPattern.BuilderPattern;
using DesignPattern.ObserverPattern;
using DesignPattern.StrategyPattern;
using DesignPattern.DependencyInjection;

namespace DesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n");

        // Demo Builder Pattern
        /*BuilderPatternDemo.Run();*/
        
        // Demo Singleton Pattern
        SingletonPatternDemo.Run();

        Console.WriteLine("\n");

        // Demo Factory Pattern
        /*FactoryPatternDemo.Run();

        Console.WriteLine("\n");

        // Demo Observer Pattern
        ObserverPatternDemo.Run();

        Console.WriteLine("\n");

        // Demo Strategy Pattern
        StrategyPatternDemo.Run();

        Console.WriteLine("\n");

        // Demo Dependency Injection
        DIPatternDemo.Run();*/
    }
}
