
//represents and manage 52 cards
using System;
using System.Collections.Concurrent;
using System.Globalization;

public class Deck
{
    private List<Card> cards = new List<Card>();
    public Deck ()
    {
        for (int i=0; i<Card.Suits.Length; i++)
        {
            for (int j=0; j<Card.Values.Length; j++)
            {
                cards.Add(new Card(Card.Suits[i], Card.Values[j]));
            }
        }
    }
    public void Shuffle() //Fisher-Yates shuffle algorithm 
    {
        Random random = new Random();
        int n = cards.Count;
    
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card Deal() //removes and returns the top card from the deck 
    {
        if (cards.Count == 0) 
            return null;

        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
    public int CardsRemaining()
    {
        return cards.Count;
    }

    public bool isEmpty()
    {
        return  cards.Count == 0;
    }
}