namespace Bevahior; 

public interface IGameEvent{
    void StartEvent();
    void EndEvent();
    void PauseEvent();

    void Draw();
}