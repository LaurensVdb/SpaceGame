using Drawing;
using Behavior.Movement;
using Raylib_cs;
using Camera;

namespace GameObjects.Objects;

public class Bullet : BaseGameEntity, IMovableEntity, IDrawableEntity
{
    private readonly IMovement movementservice;
    private readonly IDrawing drawing;
    private bool isEnemy;
    public bool IsEnemy { get { return isEnemy; } }
    public Bullet(IMovement movementservice, IDrawing drawing, float x, float y, Texture2D texture, float movementSpeed, int hitPoints, float bulletRotation, bool isEnemy = false)
        : base(x, y, movementSpeed, hitPoints, texture)
    {
        this.Rotation = bulletRotation;
        this.movementservice = movementservice;
        this.drawing = drawing;
        this.isEnemy = isEnemy;
    }

    public void Move()
    {
        this.movementservice.Move(this);
    }

    public void Draw(ICameraController cameraController)
    {
        this.drawing.Drawing(this, cameraController);
    }
}