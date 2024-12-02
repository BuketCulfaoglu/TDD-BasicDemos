using System.ComponentModel;

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

    public Game(Player turn, int numberOfSticks)
    {
        NumberOfSticks = numberOfSticks;
        Turn = turn;

        //if (numberOfSticks < 10)
        //    throw new ArgumentException($"Number of sticks has to be >= 10. You passed: {numberOfSticks}");
    }

    public Game HumanMakesMove(int sticksTaken)
    {
        if (Turn == Player.Machine)
        {
            throw new InvalidOperationException($"It's turn of machine to make a move!");
        }
        if (sticksTaken < MinToTake || sticksTaken > MaxToTake)
        {
            throw new ArgumentException($"You should take from one to three sticks. You took : {sticksTaken}");
        }

        return new Game(Revert(Turn), NumberOfSticks - sticksTaken);
    }

    private Player Revert(Player p)
    {
        return p == Player.Human ? Player.Machine : Player.Human;
    }
}