namespace GameObjects.Objects;


public interface IDamageableEntity
{
    public void TakeDamage(int damagePoints);
    public int ProtectectionLevel { get; set; }
    public int HitPoints { get; set; }
    public int HitPointsAtStart { get; set; }
}