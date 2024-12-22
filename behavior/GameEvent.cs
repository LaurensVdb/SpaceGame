using System.Diagnostics;

namespace Bevahior;

public abstract class GameEvent : IGameEvent
{
    protected Stopwatch timer;
    public GameEvent()
    {
        timer = new Stopwatch();
    }


    public abstract void StartEvent();

    public virtual void Draw() { }
}