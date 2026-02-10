using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class GameController
{
    private Deck deck;
    private Table table;
    private bool Win;
    private bool Lose;
    public GameController()
    {
        deck = new Deck();
        table = new Table();
        Win = false;
        Lose = false;
    }
    
    public void StartGame()
    {
        Console.WriteLine("************************************");
        Console.WriteLine("     WELCOME TO ELEVENS GAME!!!     ");
        Console.WriteLine("************************************");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Here are the Game Rules: ");
        Console.WriteLine("1. Find a pair (A-10) that sums up to 11.");
        Console.WriteLine("2. Or find a J, Q, K together.");
        Console.WriteLine("3. Wins when all cards are removed from the deck.");
        Console.WriteLine("4. Loses when no valid set found to remove.");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("LET THE BEGIN.....");
        
        //Shuffle the deck 
        deck.Shuffle(); 
        
        // Deal initial 9 cards on the table
        for (int i = 0; i < 9; i++)
        {
            Card card = deck.Deal();
            if (card != null)
            {
                table.addCard(card);
            }
        }
    }
    //Check selected submission is valid or not
    public void SubmitSelection(List<int> selectedIndices)
    {
        if (ValidateSelection(selectedIndices))
        {
            table.Replace(deck, selectedIndices);
            Console.WriteLine("\nValid selection!");
        }
        else
        {
            Console.WriteLine("\nInvalid selection. Try again.");
        }
    }
    
    public bool ValidateSelection(List<int> selectedIndices)
    {
        if (selectedIndices.Count == 0)
        {
            return false;
        }
        
        List<Card> selectedCards = new List<Card>();
        foreach (int index in selectedIndices)
        {
            selectedCards.Add(table.GetCard(index));
        }
        
        //Check for 2 cards that sums up to 11 
        if (selectedCards.Count == 2)
        {
            int sum = selectedCards[0].getValue() + selectedCards[1].getValue();
            if (sum == 11)
            {
                return true;
            }
            Console.WriteLine($"Error: {selectedCards[0].getValue()} + {selectedCards[1].getValue()} = {sum}, not 11.");
            return false;
        }
        
        // Check for J, Q, K together
        if (selectedCards.Count == 3)
        {
            List<int> values = selectedCards.Select(c => c.getValue()).OrderBy(v => v).ToList();
            if (values[0] == 11 && values[1] == 12 && values[2] == 13)
            {
                return true;
            }
            Console.WriteLine("Error: Must select J (11), Q (12), and K (13).");
            return false;
        }
        
        Console.WriteLine($"Error: Must select exactly 2 cards (for sum of 11) or 3 cards (J, Q, K).");
        return false;
    }
    
    public void CheckEndState()
    {
        // Check if player won 
        if (deck.isEmpty() && table.GetCardCount() == 0)
        {
            Win = true;
            return;
        }
        //Check if player lost
        if(!hasValidMoves())
        {
            Lose = true;
            return;
        }
    }

    private bool hasValidMoves()
    {
        List<Card> cards = table.GetCards();
        int count = cards.Count;

        for (int i = 0; i < count; i++)
        {
            for (int j = i+1; j<count; j++)
            {
                if(cards[i].getValue() + cards[j].getValue() == 11)
                {
                    return true;
                }
            }
        }

        //Check for J,Q,K combo
        bool hasJ = cards.Any( c => c.getValue() == 11);
        bool hasQ = cards.Any( c => c.getValue() == 12);
        bool hasK = cards.Any( c => c.getValue() == 13);
        if(hasJ && hasQ && hasK) {
            return true;
        }
        return false;
    }
    public bool isGameWon()
    {
        return Win;
    }
    
    public bool isGameLost()
    {
        return Lose;
    }
    
    public void DisplayGameState()
    {
        table.DisplayTable();
        Console.WriteLine($"\nCards remaining in deck: {deck.CardsRemaining()}");
    }
    
    public Table GetTable()
    {
        return table;
    }
}