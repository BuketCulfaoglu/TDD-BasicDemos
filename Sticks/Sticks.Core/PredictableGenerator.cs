namespace Sticks.Core;

public class PredictableGenerator : ICanGenerateNumbers
{
    private int _number;

    public int Next(int min, int max)
    {
        return _number;
    }

    public void SetNumber(int number)
    {
        _number = number;
    }
}