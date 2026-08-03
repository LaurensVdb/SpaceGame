using ContentManagement;

public class GameConfig
{
    public List<EnemyConfig> Enemies { get; set; } = new();
    public PlayerConfig Player { get; set; } = new();
}