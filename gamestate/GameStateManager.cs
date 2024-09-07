using Raylib_cs;
namespace GameStateBevahior;

public class GameStateManager
{

    public bool IsExit=false;
    private IGameState state;
    public IGameState State
    {
        get { return state; }
        set
        {
            state = value;

        }
    }

    public GameStateManager(IGameState state)
    {
        Raylib.SetExitKey(KeyboardKey.Space);
        this.state = state;

    }

    // The Context delegates part of its behavior to the current State
    // object.
    public void Update()
    {
        while (!Raylib.WindowShouldClose() && !IsExit)
        {
            this.state.Update(this);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
                this.state.Draw();
            Raylib.EndDrawing();


        }
        Raylib.CloseWindow();
      
    }





}
