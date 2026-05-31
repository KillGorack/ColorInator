using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ColorInator.Services;

public class ColorNameService
{
    private readonly HttpClient _http = new();

    public async Task<string> GetColorNameAsync(byte r, byte g, byte b)
    {
        var url = $"https://www.thecolorapi.com/id?rgb={r},{g},{b}";
        var json = await _http.GetStringAsync(url);
        var doc = JsonDocument.Parse(json);
        return doc.RootElement
                  .GetProperty("name")
                  .GetProperty("value")
                  .GetString() ?? "Unknown";
    }
}