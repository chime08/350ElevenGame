using System.Security.Cryptography;

namespace Elevens.Core;

public sealed class Deck
{
    private readonly List<Card> _cards = new();
    public int Count => _cards.Count;

    public bool IsEmpty()
    {
        return Count == 0;
    }
    //Constructor 
    public Deck() //create 52 cards in deck 
    {
        foreach (Suit suit in Enum.GetValues<Suit>())
            for (int rank = 1; rank <= 13; rank++)
                _cards.Add(new Card(rank, suit));
    }

    public void Shuffle()
    {
        //Fisher-Yates shuffle algorithm
        Random random = new Random();
        int n = _cards.Count;
    
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = _cards[i];
            _cards[i] = _cards[j];
            _cards[j] = temp;
        }
    }
    
    public Card DealCard() //remove and return the top card from the deck one at a time 
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Cannot deal from empty deck");
        }
        int lastIndex = Count -1;
        Card top = _cards[lastIndex];
        _cards.RemoveAt(lastIndex);
        return top;
    }
}

