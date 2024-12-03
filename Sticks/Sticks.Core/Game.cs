using System.ComponentModel;

namespace Sticks.Core;

public enum Player
{
    Machine,
    Human
}

public class Game
{
    private readonly ICanGenerateNumbers _generator;
    public const int MinToTake = 1;

    public const int MaxToTake = 3;

    public int NumberOfSticks { get; }
    public Player Turn { get; }

    public Game(Player turn, int numberOfSticks)
    {
        NumberOfSticks = numberOfSticks;
        Turn = turn;
    }

    public Game(Player turn, int numberOfSticks, ICanGenerateNumbers generator)
    {
        NumberOfSticks = numberOfSticks;
        Turn = turn;
        _generator = generator;
    }

    private Game(Player turn, int numberOfSticks, ICanGenerateNumbers generator, EventHandler<Move> onMachineMoved)
    {
        NumberOfSticks = numberOfSticks;
        Turn = turn;
        _generator = generator;
        MachineMoved = onMachineMoved;
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

    public Game MachineMakesMove()
    {
        int sticksTaken = _generator.Next(MinToTake, MaxToTake);
        int remains = NumberOfSticks - sticksTaken;

        MachineMoved?.Invoke(this, new Move(sticksTaken, remains));

        return new Game(Revert(Turn), remains, _generator, MachineMoved);
    }

    private Player Revert(Player p)
    {
        return p == Player.Human ? Player.Machine : Player.Human;
    }

    public event EventHandler<Move> MachineMoved;

    public struct Move
    {
        public int Taken { get; }
        public int Remains { get; }

        public Move(int taken, int remains)
        {
            Taken = taken;
            Remains = remains;
        }
    }


}