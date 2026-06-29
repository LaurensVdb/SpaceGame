using Drawing;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects;

public class Bullet : BaseGameEntity, IMovableEntity
{
    private readonly IMovement movementservice;
    private bool isEnemy;
    public bool IsEnemy { get { return isEnemy; } }
    public Bullet(IMovement movementservice, IDrawing drawing, float x, float y, Texture2D texture, float movementSpeed, int hitPoints, float bulletRotation, bool isEnemy = false)
        : base(drawing, x, y, movementSpeed, hitPoints, texture)
    {
        this.Rotation = bulletRotation;
        this.movementservice = movementservice;
        this.isEnemy = isEnemy;
    }

    public void Move()
    {
        this.movementservice.Move(this);
    }
}