using System.Text.Json;
using ContentManagement;

public class ConfigLoader
{

    public GameConfig Load(string filePath)
    {
        return ReadFromFile(filePath);

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