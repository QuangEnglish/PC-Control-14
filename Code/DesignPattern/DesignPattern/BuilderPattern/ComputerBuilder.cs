namespace DesignPattern.BuilderPattern;

// BUILDER - Xay dung object tung buoc mot
public class ComputerBuilder
{
    private Computer _computer = new Computer();  // field 

    public ComputerBuilder SetCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this; // return this de ho tro method chaining
    }

    public ComputerBuilder SetRAM(string ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public ComputerBuilder SetStorage(string storage)
    {
        _computer.Storage = storage;
        return this;
    }

    public ComputerBuilder SetGPU(string gpu)
    {
        _computer.GPU = gpu;
        return this;
    }

    // Build() tra ve object hoan chinh
    public Computer Build()
    {
        return _computer;
    }
}
