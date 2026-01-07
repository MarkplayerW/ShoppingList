using System.Text.Json;
using ShoppingList.Models;

namespace ShoppingList.Services;

public class FileService
{
    private readonly string path =
        Path.Combine(FileSystem.AppDataDirectory, "shoppinglist.json");

    public List<Category> Load()
    {
        if (!File.Exists(path))
            return new();

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Category>>(json) ?? new();
    }

    public void Save(List<Category> categories)
    {
        var json = JsonSerializer.Serialize(categories, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(path, json);
    }
}
