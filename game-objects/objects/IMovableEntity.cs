
namespace GameObjects.Objects;

public interface IMovableEntity
{
    public bool IsMoving { get; set; }
    public float MovementSpeed { get; set; }
    public void Move();
}