using System.Text.Json;
using ContentManagement;
using GameObjects.Repositories;

public class ConfigLoader
{
    public void Load(string filePath, IGameObjectRepository repository)
    {
        var config = ReadFromFile(filePath);
        repository.EnemyConfgurationData = config.Enemies;
        repository.PlayerConfigurationData = config.Player;
    }

    private GameConfig ReadFromFile(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<GameConfig>(json, options)
            ?? new GameConfig();
    }
}