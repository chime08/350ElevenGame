using System.Net.Sockets;

namespace Elevens.Core;
public sealed class MoveValidator
{
    public bool isValidSelection(IReadOnlyList<Card> selected)
    {
        if(selected == null) 
            return false;
        if(selected.Count == 2) 
            return IsValidPair(selected[0], selected[1]);
        if(selected.Count == 3) 
            return IsValidTriple(selected);
        return false;
    }

    public bool HasLegalMoves(IReadOnlyList<Card> tableCards)
    {
        if (tableCards == null || tableCards.Count == 0) return false;
        
        //check pair that sums to 11
        for(int i = 0; i < tableCards.Count; i++)
        {
            for (int j = i+1; j < tableCards.Count; j++)
            {
                if(IsValidPair(tableCards[i], tableCards[j]))
                {
                    return true;
                }
            }
        }

        //check J,Q,K triple
        bool hasJ = tableCards.Any(c => c.IsJack);
        bool hasQ = tableCards.Any(c => c.IsQueen);        
        bool hasK = tableCards.Any(c => c.IsKing);

        if (hasJ && hasQ && hasK)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
    private bool IsValidPair(Card a, Card b)
    {
        if (a == null || b == null) return false;
        return a.ValueForEleven + b.ValueForEleven == 11;
    }

    private bool IsValidTriple(IReadOnlyList<Card> three)
    {
        bool hasJ = false, hasQ = false, hasK = false;
        foreach (var card in three)
        {
            if (card.IsJack) hasJ = true;
            if (card.IsQueen) hasQ = true;
            if (card.IsKing) hasK = true;
        }
        return hasJ && hasQ && hasK;
    }
}