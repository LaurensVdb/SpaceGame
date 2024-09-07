namespace GameStateBevahior; 

public interface IGameState{
    GameStateEnum CurrentGameState { get; set; }
}