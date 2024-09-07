using System.Numerics;
using GameStateBevahior;
using Raylib_cs;

namespace GameMenuBevahior;

public interface IMenuItem{
    void DrawMenuItem();
    void SelectMenuItem();
    public int X { get; }
    public int Y { get; }
    public int Order { get; }
    public Color Color { get; }
    public GameStateEnum GameState {get;}
    public int FontSize { get; }
    public Vector2 Position { get; }

    bool IsSelected { get; set; }
}