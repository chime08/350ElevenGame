namespace Elevens.Core;

public enum GameState { NotStarted, Running, Won, Lost }

public sealed class GameController
{
    private readonly Deck _deck;
    private readonly Table _table;
    private readonly MoveValidator _validator;

    public GameState State { get; private set; } = GameState.NotStarted;
    public Deck Deck => _deck;
    public Table Table => _table;

    public GameController(Deck deck = null, Table table = null, MoveValidator validator = null)
    {
        _deck = deck ?? new Deck();
        _table = table ?? new Table();
        _validator = validator ?? new MoveValidator();
    }

    public void StartGame()
    {
        State = GameState.Running;
        _deck.Shuffle();
        RefillTableToNine();
    }

    public void RefillTableToNine()
    {
        while (_table.Count() < 9 && !_deck.IsEmpty())
        {
            _table.AddCard(_deck.DealCard());
        }
    }

    public bool SubmitSelection(IReadOnlyList<int> indices, out string message)
    {
        List<Card> selected = _table.GetCardsByIndices(indices);

        if (!_validator.isValidSelection(selected))
        {
            message = "Invalid selection. Try again.";
            return false;
        }

        _table.RemoveCards(selected);
        RefillTableToNine();
        CheckEndState();

        message = "Valid move!";
        return true;
    }

    public void CheckEndState()
    {
        if (CheckWin())
            State = GameState.Won;
        else if (CheckLose())
            State = GameState.Lost;
    }

    public bool CheckWin()
    {
        // Win = deck empty and table empty
        return _deck.IsEmpty() && _table.IsEmpty();
    }

    public bool CheckLose()
    {
        // Lose = deck empty, table has cards, but no legal moves left
        return _deck.IsEmpty() 
               && !_table.IsEmpty() 
               && !_validator.HasLegalMoves(_table.Cards);
    }
}