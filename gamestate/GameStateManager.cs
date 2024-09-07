namespace GameStateBevahior;

public class GameStateManager
{
    private State state;
    public State State
    {
        get { return state; }
        set
        {
            state = value;

        }
    }

    public GameStateManager(State state)
    {
        this.state = state;

    }

    // The Context delegates part of its behavior to the current State
    // object.
    public void Update()
    {
        this.state.Update(this);
    }
    public void Draw(){
        this.state.Draw();
    }



}
