using Raylib_cs;

namespace GameObjects.Objects;
/* 
Elk game object moet gebruik maken van de base game entity class
*/
public abstract class BaseGameEntity
{
    public BaseGameEntity(float x, float y, Texture2D texture2D)
    {
        X = x;
        Y = y;
        Texture = texture2D;
        Widht = texture2D.Width;
        Height = texture2D.Height;
        IsAlive = true;

    }
    public Texture2D Texture { get; set; }

    public virtual Rectangle CollisionRectangle => new Rectangle(X, Y, Widht, Height);
    public int Widht { get; set; }
    public int Height { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public bool IsAlive { get; set; }
    public float Rotation { get; set; }

}