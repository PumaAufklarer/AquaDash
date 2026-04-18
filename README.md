# HybridArms

A 2D platform game built with Godot 4.6 and C#.

## Prerequisites

- Godot 4.6.1 (with .NET support)
- .NET 8.0 SDK

## Setup

1. Clone the repository
2. Install Git hooks:
   ```bash
   git config core.hooksPath .githooks
   ```
3. Open the project in Godot or build with:
   ```bash
   dotnet build
   ```

## Development

### Code Style

We use `dotnet format` to enforce code style. To format your code:

```bash
dotnet format
```

## Project Structure

```
HybridArms/
├── assets/          # Game assets (textures, sounds, etc.)
├── scenes/          # Godot scene files
├── src/             # C# source code
│   └── gameplay/    # Gameplay logic
│       ├── controller/  # Controllers for player, UI, camera
│       └── utils/       # Utility classes
└── docs/            # Documentation
```

## License

TBD
