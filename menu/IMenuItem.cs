using System.Numerics;
using GameState;
using Raylib_cs;

namespace Menu;

public interface IMenuItem
{
    void DrawMenuItem();
    public int X { get; }
    public int Y { get; }
    public int Order { get; }
    public Color Color { get; }
    public IGameState GameState { get; }
    public int FontSize { get; }
    public Vector2 Position { get; }

    bool IsSelected { get; set; }
}