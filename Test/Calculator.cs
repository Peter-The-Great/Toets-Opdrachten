using System.Numerics;
namespace Test;
public interface ICalculator<T>
{
    public T Add(T a, T b);
    public T Substract(T a, T b);
}

struct MockCalculator<T>(uint counter = 0) : ICalculator<T>
{
    public uint Count() => counter += 1;

    public T Add(T a, T b)
    {
        dynamic? c = a;
        return c + b;
    }

    public T Substract(T a, T b)
    {
        dynamic? c = a;
        return c - b;
    }
}

public readonly struct Calculator<T>(ICalculator<T> iCalculator)
where T : INumber<T>
{
    private ICalculator<T> Icalculator { get; } = iCalculator;
    public T Add(T a, T b) => Icalculator.Add(a, b);
    public T Substract(T a, T b) => Icalculator.Substract(a, b);
}