namespace Elevens.Core;
public enum Suit {Clubs, Diamonds, Hearts, Spades} //enum = read-only constants
public sealed class Card
{
    //Card's rank and suit are readonly properties because once its created, 
    // a card's rank and suit can never change 
    public int Rank{get;} 
    public Suit Suit{get;} 
    public Card(int rank, Suit suit) //Constructor 
    {
        if(rank < 1 || rank > 13) //validate card inputs 
        {
            throw new ArgumentOutOfRangeException(nameof(rank));
        }
        Rank = rank;
        Suit = suit;
    }
    public int ValueForEleven //if rank is not between 1-10 then returns 0
    {
        get
        {
            if (Rank >= 1 && Rank < 10) 
                return Rank;
            else 
                return 0;
        }
    }
    public bool IsJack => Rank == 11;
    public bool IsQueen => Rank == 12;
    public bool IsKing => Rank == 13;

    public override string ToString() //Format card 
    {
        string r = Rank switch
        {
            1 => "A", 
            11 => "J",
            12 => "Q", 
            13 => "K", 
            _ => Rank.ToString()
        };

        String suit = Suit switch
        {
            Suit.Spades => "♠",
            Suit.Clubs => "♣",
            Suit.Hearts => "❤",
            Suit.Diamonds => "◆", 
            _ => "?"
        };
        return $"{r} {suit}";
    }
}