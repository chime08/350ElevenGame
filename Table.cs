namespace Elevens.Core;

public sealed class Table
{
    private readonly List<Card> _visibleCards = new();
    private readonly int _maxCards;

    public int MaxCards => _maxCards;
    public IReadOnlyList<Card> Cards => _visibleCards.AsReadOnly();

    public Table(int maxCards = 9)
    {
        _maxCards = maxCards;
    }

    public int Count()
    {
        return _visibleCards.Count;
    }

    public bool IsEmpty()
    {
        return _visibleCards.Count == 0;
    }

    public void AddCard(Card card)
    {
        if (_visibleCards.Count >= _maxCards)
            throw new InvalidOperationException("Table is full");
        _visibleCards.Add(card);
    }

    public Card GetCardAt(int index)
    {
        if (index < 0 || index >= _visibleCards.Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        return _visibleCards[index];
    }

    public List<Card> GetCardsByIndices(IEnumerable<int> indices)
    {
        return indices.Select(i => GetCardAt(i)).ToList();
    }

    public void RemoveCards(IEnumerable<Card> cards)
    {
        foreach (Card card in cards)
        {
            _visibleCards.Remove(card);
        }
    }
}