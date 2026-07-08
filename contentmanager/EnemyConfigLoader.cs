using System.Text.Json;
using GameObjects.Objects;

namespace ContentManagement;

public class EnemyConfig
{
    public string Name { get; set; }
    public int TextureId { get; set; }
    public float Speed { get; set; }
    public int HitPoints { get; set; }
    public bool CanShoot { get; set; }
    public int? ShootInterval { get; set; }
    public Player TargetPlayer { get; set; }
}
public class EnemyConfigLoader
{

    public List<EnemyConfig> Load(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<EnemyConfig>>(json, options)
            ?? new List<EnemyConfig>();
    }
}