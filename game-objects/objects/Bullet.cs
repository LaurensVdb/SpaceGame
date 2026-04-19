using Drawing;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects;

public class Bullet : BaseGameEntity
{

    private bool isEnemy;
    public bool IsEnemy { get { return isEnemy; } }
    public Bullet(IMovement movementservice, IDrawing drawing, float x, float y, Texture2D texture, float movementSpeed, int hitPoints, float bulletRotation, bool isEnemy = false)
        : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture)
    {
        this.Rotation = bulletRotation;
        this.isEnemy = isEnemy;
    }
}