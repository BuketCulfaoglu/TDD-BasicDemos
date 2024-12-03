namespace Sticks.Core;

public class NumbersGenerator : ICanGenerateNumbers
{
    private readonly Random _generator = new Random();
    public int Next(int min, int max)
    {
        return _generator.Next(min, max);
    }
}