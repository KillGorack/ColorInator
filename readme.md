# ColorInator

A lightweight color picker and palette manager built with Avalonia UI and .NET 8.

## Features

- Pick colors using a full spectrum color picker
- Automatically name colors via [The Color API](https://www.thecolorapi.com)
- View complementary color with one click — loads it back into the picker
- Copy hex and RGB values to clipboard
- Save and persist a personal color palette across sessions
- Delete colors from the palette
- Duplicate color prevention

## Tech Stack

- [Avalonia UI](https://avaloniaui.net) — cross-platform UI framework
- [CommunityToolkit.Mvvm](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/) — MVVM helpers
- [Avalonia.Controls.ColorPicker](https://docs.avaloniaui.net) — color picker control
- .NET 8

## Architecture

The project follows MVVM pattern with a service layer:

- `Models/` — data shape (SavedColor)
- `ViewModels/` — application state and commands
- `Services/` — external concerns (API calls, file persistence)
- `Views/` — UI only, no logic

## Running the Project

```bash
cd ColorInator
dotnet run
```

## Building a Binary

```bash
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true
```

Binary will be at `bin/Release/net8.0/linux-x64/publish/ColorInator`.

Keep the `.so` files in the same folder as the binary.

## Downloads

Pre-built binaries available at [KillGorack.com](https://www.killgorack.com/PX4/index.php?ap=software&id=8&cn=det)

- Windows x64
- Linux x64

## Data Storage

Saved colors are stored at:
```
~/.config/ColorInator/colors.json
```

<img width="810" height="506" alt="image" src="https://github.com/user-attachments/assets/44790849-db0b-4130-8bb3-4c84b90ec8b4" />


## Credits

Color naming powered by [The Color API](https://www.thecolorapi.com) — free, no key required.
