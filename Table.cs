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
        
    }

}