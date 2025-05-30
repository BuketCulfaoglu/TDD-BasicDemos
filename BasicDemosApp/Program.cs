﻿using System.Text;
using BasicDemos;

namespace BasicDemosApp;

public class Program
{
    private static Game g = new Game();
    static void Main(string[] args)
    {
        PlayTicTacToe();
    }

    private static void PlayTicTacToe()
    {
        Console.WriteLine(GetPrintableState());

        while (g.GetWinner() == Winner.GameIsUnfinished)
        {
            int index = int.Parse(Console.ReadLine());
            g.MakeMove(index);

            Console.WriteLine();
            Console.WriteLine(GetPrintableState());
        }

        Console.WriteLine($"Result: {g.GetWinner()}");
        Console.ReadLine();
    }

    private static string GetPrintableState()
    {
        var sb = new StringBuilder();

        for (int i = 1; i <= 7; i += 3)
        {
            sb.AppendLine("     |     |     ")
                .AppendLine(
                    $"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  ")
                .AppendLine("_____|_____|_____|");
        }

        return sb.ToString();
    }

    private static string GetPrintableChar(int index)
    {
        State state = g.GetState(index);
        if (state == State.Unset)
            return index.ToString();
        return state == State.Cross ? "X" : "O";
    }
}