namespace ColorInator.Models;

public class SavedColor
{
    public string HexColor => $"#{R:X2}{G:X2}{B:X2}";
    public string ComplementaryHex => $"#{(byte)(255-R):X2}{(byte)(255-G):X2}{(byte)(255-B):X2}";
    public string RgbDisplay => $"rgb({R}, {G}, {B})";
    public string ComplementaryRgbDisplay => $"rgb({(byte)(255-R)}, {(byte)(255-G)}, {(byte)(255-B)})";
    public string Name { get; set; } = "";
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
}