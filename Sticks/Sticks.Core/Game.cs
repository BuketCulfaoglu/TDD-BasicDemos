namespace Sticks.Core;

public enum Player
{
    Machine,
    Human
}

public class Game
{
    public const int MinToTake = 1;

    public const int MaxToTake = 3;

    public int NumberOfSticks { get; }
    public Player Turn { get; }

    public Game(int numberOfSticks, Player turn)
    {
        NumberOfSticks = numberOfSticks;
        Turn = turn;

        if (numberOfSticks < 10)
            throw new ArgumentException($"Number of sticks has to be >= 10. You passed: {numberOfSticks}");
    }

    public void HumanMakesMove(int sticksTaken)
    {
        if (sticksTaken < MinToTake || sticksTaken > MaxToTake)
        {
            throw new ArgumentException($"You should take from one to three sticks. You took : {sticksTaken}");
        }
    }


}