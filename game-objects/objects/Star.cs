using Drawing;
using Behavior.Movement;
using Raylib_cs;
using Camera;

namespace GameObjects.Objects;

public class Star : BaseGameEntity, IMovableEntity, IDrawableEntity
{
    private readonly IMovement movementservice;
    private readonly IDrawing drawing;
    public bool IsMoving { get; set; }
    public float MovementSpeed { get; set; }
    public Star(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, Texture2D texture) :
     base(x, y, texture)
    {
        this.movementservice = movementservice;
        this.drawing = drawing;
    }

    public void Draw(ICameraController cameraController)
    {
        this.drawing.Drawing(this, cameraController);
    }

    public void Move()
    {
        this.movementservice.Move(this);
    }
}