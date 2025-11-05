using MovmementService;
using Raylib_cs;

namespace GameObjects.objects;

public class Bullet : BaseGameEntity
{

    private bool isEnemy;
    public bool IsEnemy { get { return isEnemy; } }
    public Bullet(IMovement movementservice, float x, float y, Texture2D texture, float movementSpeed, int hitPoints, float bulletRotation, bool isEnemy = false)
        : base(movementservice, x, y, movementSpeed, hitPoints, texture)
    {
        this.Rotation = bulletRotation;
        this.isEnemy = isEnemy;
    }
    public override void Draw()
    {
        //Raylib.DrawCircleV(new Vector2(X,Y), 5, Color.White);
        if (IsAlive)
        {
            Raylib.DrawTexture(Texture, (int)X, (int)Y, Color.White);
        }

    }
}