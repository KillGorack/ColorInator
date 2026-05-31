using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Media;
using System.Threading.Tasks;
using ColorInator.Models;
using ColorInator.Services;
using Avalonia.Input.Platform;
using System.Linq;
using System.Collections.Generic;

namespace ColorInator.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private Color _selectedColor = Color.FromRgb(128, 128, 128);
    [ObservableProperty] private SavedColor? _selectedSavedColor;
    public ObservableCollection<SavedColor> SavedColors { get; } = new();
    private readonly ColorNameService _colorNameService = new();
    private readonly ColorStorageService _colorStorageService = new();
    public void SetClipboard(IClipboard clipboard) => _clipboard = clipboard;
    private IClipboard? _clipboard;
    partial void OnSelectedColorChanged(Color value)
    {
        R = value.R;
        G = value.G;
        B = value.B;
    }

    public byte R { get; private set; } = 128;
    public byte G { get; private set; } = 128;
    public byte B { get; private set; } = 128;

    [RelayCommand]
    private async Task SaveColor()
    {
        if (SavedColors.Any(c => c.R == R && c.G == G && c.B == B)) return;
        var name = await _colorNameService.GetColorNameAsync(R, G, B);
        SavedColors.Add(new SavedColor { Name = name, R = R, G = G, B = B });
        await _colorStorageService.SaveAsync(SavedColors);
    }
    [RelayCommand]
    private async Task CopyHex()
    {
        if (SelectedSavedColor is null || _clipboard is null) return;
        await _clipboard.SetTextAsync(SelectedSavedColor.HexColor);
    }

    [RelayCommand]
    private async Task CopyRgb()
    {
        if (SelectedSavedColor is null || _clipboard is null) return;
        await _clipboard.SetTextAsync(SelectedSavedColor.RgbDisplay);
    }

    public async Task LoadColorsAsync()
    {
        var colors = await _colorStorageService.LoadAsync();
        foreach (var color in colors)
            SavedColors.Add(color);
    }

    [RelayCommand]
    private async Task CopyComplementaryHex()
    {
        if (SelectedSavedColor is null || _clipboard is null) return;
        await _clipboard.SetTextAsync(SelectedSavedColor.ComplementaryHex);
    }

    [RelayCommand]
    private async Task CopyComplementaryRgb()
    {
        if (SelectedSavedColor is null || _clipboard is null) return;
        await _clipboard.SetTextAsync(SelectedSavedColor.ComplementaryRgbDisplay);
    }

    [RelayCommand]
    private async Task DeleteColor()
    {
        if (SelectedSavedColor is null) return;
        SavedColors.Remove(SelectedSavedColor);
        SelectedSavedColor = null;
        await _colorStorageService.SaveAsync(SavedColors);
    }

    [RelayCommand]
    private void LoadComplementaryColor()
    {
        if (SelectedSavedColor is null) return;
        SelectedColor = Color.FromRgb(
            (byte)(255 - SelectedSavedColor.R),
            (byte)(255 - SelectedSavedColor.G),
            (byte)(255 - SelectedSavedColor.B));
    }
}