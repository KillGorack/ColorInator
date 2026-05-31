using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ColorInator.Models;

namespace ColorInator.Services;

public class ColorStorageService
{
    private readonly string _path = Path.Combine(
        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
        "ColorInator", "colors.json");

    public async Task SaveAsync(IEnumerable<SavedColor> colors)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
        var json = JsonSerializer.Serialize(colors);
        await File.WriteAllTextAsync(_path, json);
    }

    public async Task<List<SavedColor>> LoadAsync()
    {
        if (!File.Exists(_path)) return new();
        var json = await File.ReadAllTextAsync(_path);
        return JsonSerializer.Deserialize<List<SavedColor>>(json) ?? new();
    }
}