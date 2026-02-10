using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public class Program
{
    public static void Main(string[] args)
    {
        GameController game = new GameController();    
        game.StartGame();

        while (!game.isGameWon() && !game.isGameLost())
        {
            game.DisplayGameState();
            List<int>? selectedIndices = getPlayerSelection();
            if(selectedIndices == null)
            {
                Console.WriteLine("\nThanks for playing!");
                return;
            }

            game.SubmitSelection(selectedIndices);
            game.CheckEndState();
        }

        game.DisplayGameState();

        if(game.isGameWon())
        {
            Console.WriteLine("\n CONGRATS!! YOU WON!!");
        }
        else if (game.isGameLost())
        {
            Console.WriteLine("\n GAME OVER. YOU LOST.");
        }
    }
    private static List<int>? getPlayerSelection()
    {
        Console.WriteLine("\n Enter indices: ");
        string input = Console.ReadLine() ?? "";

        List<int> indices = new List<int>();
        string[] parts = input.Split(' ');

        foreach (string part in parts)
        {
            indices.Add(int.Parse(part));
        }
        return indices;
    }
}