namespace ConsoleApp1;
public interface IEngine
{
    void Start();
}

public class GasolineEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Starting gasoline engine");
    }
}

public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Starting electric engine");
    }
}

public class Car
{
    private IEngine engine;

    public Car(IEngine engine)
    {
        this.engine = engine;
    }

    public void Start()
    {
        engine.Start();
    }
}