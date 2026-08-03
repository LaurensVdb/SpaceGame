
namespace ContentManagement;

public class PlayerConfig
{
    public int HitPoints { get; set; }
    public PositionConfig Position { get; set; } = new();
    public float MovementSpeed { get; set; }
    public int ProtectionLevel { get; set; }
    public int TextureId { get; set; }
}

public class PositionConfig
{
    public float X { get; set; }
    public float Y { get; set; }
}