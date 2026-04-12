using System.Text.Json;

public class EnemyConfigLoader
{
    public class EnemyConfig
    {
        public string Name { get; set; }
        public int TextureId { get; set; }
        public float Speed { get; set; }
        public int HitPoints { get; set; }
        public bool CanShoot { get; set; }
        public int? ShootInterval { get; set; }
    }
    public static List<EnemyConfig> Load(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<EnemyConfig>>(json)
            ?? new List<EnemyConfig>();
    }
}