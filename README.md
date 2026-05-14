# Ocean Treasure Flow — Underwater Reflex Collection Game

Unity 6 underwater reflex-based collection game built with URP. Open your chest to swim, stretch your hands to collect treasures, and dodge obstacles in an endless ocean adventure.

## Game Design (from GDD)

| Mechanic | Control | Description |
|---|---|---|
| **Chest Open** | Hold **Space** | Swim forward; release to drift |
| **Directional Control** | **A / D** or **← / →** | Dodge obstacles left/right |
| **Hand Stretch** | **Left Click** | Collect all treasures within range |
| **Miss Limit** | — | Game over after too many treasures pass by |
| **Speed Progression** | — | Game speed gradually increases over time |

## Built With

- **Unity 6000.3.14f1** (Unity 6)
- **Universal Render Pipeline** (URP) 17.3.0
- **AI Navigation** 2.0.12
- **TextMeshPro** for UI
- **ProBuilder** 6.0.9 for level prototyping

## Project Structure

```
Assets/
├─ Editor/                       # Editor tools + assembly def
│  ├─ BuilderTool.cs             # One-click builds
│  ├─ SceneNavigator.cs          # Quick scene loader
│  └─ ScriptCreator.cs           # Custom script templates
├─ Scripts/
│  ├─ Core/
│  │  ├── GameManager.cs          # Game state, difficulty, event routing
│  │  ├── GameEvents.cs           # Centralized event system
│  │  └── AudioManager.cs         # Music + SFX (persistent singleton)
│  ├─ Environment/
│  │  ├── Treasure.cs             # Collectible (misses → game over)
│  │  ├── TreasureSpawner.cs      # Progressive treasure spawning
│  │  ├── Obstacle.cs             # Rock / sea plant (hit → game over)
│  │  ├── ObstacleSpawner.cs      # Progressive obstacle spawning
│  │  ├── BubbleEffect.cs         # Rising bubble particle
│  │  ├── BubbleSpawner.cs        # Ambient bubble generation
│  │  └── UnderwaterCamera.cs     # Floating camera bob
│  ├── Player/
│  │  ├── ChestMovement.cs        # Chest-open swimming + lateral dodge
│  │  ├── HandStretch.cs          # Reach-and-collect mechanic
│  │  └── MissCounter.cs          # Miss tracking with UI
│  └── UI/
│     ├── UIManager.cs            # Menu/pause/game-over panel flow
│     ├── ScoreManager.cs         # Score, streak + high score persistence
│     ├── SettingsManager.cs      # Volume controls (→ AudioManager)
│     ├── SpeedDisplay.cs         # Current speed multiplier indicator
│     └── LevelConfig.cs          # Difficulty ScriptableObject
├─ Tests/
│  ├── Runtime/                   # Play mode tests
│  └── Editor/                    # Edit mode tests
└── [Art, Materials, Prefabs, Scenes, Settings, TextMesh Pro]
```

## Assembly Definitions

| Assembly | Path | Auto-Referenced |
|---|---|---|
| `ChestOpening.Runtime` | `Assets/Scripts/` | Yes |
| `ChestOpening.Editor` | `Assets/Editor/` | Editor-only |
| `ChestOpening.Tests` | `Assets/Tests/Runtime/` | UNITY_INCLUDE_TESTS |
| `ChestOpening.EditorTests` | `Assets/Tests/Editor/` | UNITY_INCLUDE_TESTS |

## Additions vs. Original Codebase

| Addition | Files | GDD Reference |
|---|---|---|
| Directional controls (A/D) | `ChestMovement.cs` | "Directional Control — Avoid Obstacles" |
| Hand stretch collect | `HandStretch.cs` | "Hand Stretch — Collect Treasure" |
| Miss counter system | `MissCounter.cs` | "Miss Counter System" |
| Treasure + spawner | `Treasure.cs`, `TreasureSpawner.cs` | "Treasure Spawn System" |
| Obstacle + spawner | `Obstacle.cs`, `ObstacleSpawner.cs` | "Obstacle System" |
| Speed progression | `ChestMovement.cs` | "Speed Progression System" |
| Audio (music + SFX) | `AudioManager.cs` | "Music" + "Sound Effects" |
| High score persistence | `ScoreManager.cs` | Post-game score display |
| Bubble VFX | `BubbleEffect.cs`, `BubbleSpawner.cs` | "Bubbles" environment element |
| Speed indicator | `SpeedDisplay.cs` | Progressive speed feedback |
| GameManager event system | `GameManager.cs`, `GameEvents.cs` | "Game Over System" |

## Controls

| Key | Action |
|---|---|
| **Space** (hold) | Open chest — swim forward |
| **A / D** or **← / →** | Dodge obstacles |
| **Left Click** | Stretch hands — collect nearby treasures |
| **Escape** | Pause / Resume |

## Editor Tools

- **Chest Opening → Scene Navigator** (`Ctrl+Shift+N`) — Quick scene switching
- **Chest Opening → Build → Development/Release** — One-click builds
- **Assets → Create → Chest Opening → Script** — MonoBehaviour/ScriptableObject templates

## Testing

Run via **Window → General → Test Runner** or CLI.
