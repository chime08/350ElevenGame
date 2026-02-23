namespace Elevens.Core;

public enum GameState { NotStarted, Runing, Won, Lost }

public sealed class GameController
{
    private readonly Deck _deck;
    private readonly Table _table;
    private readonly MoveValidator _validator;

    public 
}