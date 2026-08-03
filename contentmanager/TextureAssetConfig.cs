namespace ContentManagement;

public class TextureAssetsConfig
{
    public TextureAssets TextureAssets { get; set; } = new();
}

public class TextureAssets
{
    public Dictionary<string, string> Player { get; set; } = new();
    public Dictionary<string, string> Enemy { get; set; } = new();
    public Dictionary<string, string> Bullet { get; set; } = new();
    public Dictionary<string, string> Star { get; set; } = new();
    public Dictionary<string, string> HealthItem { get; set; } = new();
    public Dictionary<string, string> ShieldItem { get; set; } = new();
    public Dictionary<string, string> BulletSpeedItem { get; set; } = new();
}