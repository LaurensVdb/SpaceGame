using System.Text.Json;

public class ConfigLoader
{

    public GameConfig Load(string filePath)
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