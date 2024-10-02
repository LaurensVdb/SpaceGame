using System.Diagnostics;

namespace bevahior;

public abstract class GameEvent : IGameEvent
{
    protected Stopwatch timer;
    public GameEvent()
    {
        timer = new Stopwatch();
    }

    public abstract void EndEvent();

    public abstract void PauseEvent();

    public abstract void StartEvent();
}