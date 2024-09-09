using System.Numerics;
using Raylib_cs;

namespace GameObjects.objects;

public class Star : BaseGameEntity
{
    

    public Star(float x, float y, float movementSpeed,int hitPoints,Texture2D texture) : base(x,y,movementSpeed,hitPoints,texture)
    {
        
    }

    public override void Move()
    {
        Y+=MovementSpeed;
    }
    public override void Draw()
    {
        Raylib.DrawTextureEx(Texture,new Vector2(X,Y),0f,0.2f,Color.White);
    }

    public override void Move(int targetX, int targetY)
    {
        Move();
    }
}