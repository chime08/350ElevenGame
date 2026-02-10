using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Table
{
    private List<Card> cardsOnTable = new List<Card>();
    public void addCard(Card card)
    {
        if (card != null)
        {
            cardsOnTable.Add(card);
        }
    }

    public void Remove(List<int> indices)
    {
        indices.Sort((a, b) => b.CompareTo(a));

        foreach (int index in indices)
        {
            if (index >= 0 && index < cardsOnTable.Count)
            {
                cardsOnTable.RemoveAt(index);
            }
        }
    }

    public void Replace(Deck deck, List<int> indices)
    {
        Remove(indices);
        while (cardsOnTable.Count < 9 && !deck.isEmpty())
        {
            Card newCard = deck.Deal();
            if (newCard != null)
            {
                cardsOnTable.Add(newCard);
            }
        }
    }

    public List<Card> GetCards()
    {
        return cardsOnTable;
    }
    public Card GetCard(int index)
    {
        if (index >= 0 && index < cardsOnTable.Count)
        {
            return cardsOnTable[index];
        }
        return null;
    }

    public int GetCardCount()
    {
        return cardsOnTable.Count;
    }

    public void DisplayTable()
    {
        Console.WriteLine("\nCurrent cards on Table: ");
        for (int i = 0; i < cardsOnTable.Count; i++)
        {
            Console.WriteLine($"[{i}] {cardsOnTable[i]}");
        }
    }

}