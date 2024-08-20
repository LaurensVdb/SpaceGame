using Raylib_cs;

namespace GameObjects;

public class Star : BaseGameEntity
{
    

    public Star(float x, float y, int widht, int height,float movementSpeed,int hitPoints) : base(x,y,widht,height,movementSpeed,hitPoints)
    {
        
    }

    public override void Move()
    {
        Y+=MovementSpeed;
    }
    public override void Draw()
    {
       Raylib.DrawRectangle((int)X,(int)Y,Widht,Height,Color.White);
    }

    public override void Move(int targetX, int targetY)
    {
        Move();
    }
}