using System.Diagnostics;

namespace Bevahior;

public abstract class GameEvent : IGameEvent
{
    protected int MaxElapsedMilliseconds { get; set; }
    protected Stopwatch timer;
    public GameEvent(int maxElapsedMilliseconds)
    {
        MaxElapsedMilliseconds = maxElapsedMilliseconds;
        timer = new Stopwatch();
    }


    public abstract void StartEvent();
}