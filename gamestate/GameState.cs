using Raylib_cs;
namespace GameStateBevahior; 

public enum GameStateEnum:int{
    Playing = 1,
    Quit=2,
    Menu=3, 
    GameOver=4

}
public class GameState() : IGameState{

    public GameStateEnum CurrentGameState { get; set; }
    private static readonly GameState instance = new GameState();
    static GameState()
    {
    }
    
    public static IGameState Instance
    {
        get
        {
            return instance;
        }
    }
}