# Gnash and Spookz

> A 3D action-platformer developed as a capstone project at **Full Sail University**.

**[Play on itch.io](https://starcloud-games.itch.io/gnash-and-spookz)**

---

## About

Gnash and Spookz is a 3D action-platformer where you control **Gnash**, a scrappy fighter, accompanied by the ghost companion **Spooks**. Journey through diverse worlds, battle enemies, collect wisps and portrait pieces, and unlock powerful new abilities along the way.

## Gameplay Features

- **Combat system** — melee combos, ground pound, air attack, spin attack, and more
- **Companion mechanics** — Spooks assists with a parachute glide, bubble shield, rope, and grab abilities
- **Unlockable abilities** — Spin Attack, Shield, Fireball, Dash, and Decoy, each with cooldown UI
- **Collectibles** — Wisps and Portrait Pieces hidden across every level, with persistent save/load tracking
- **Challenges** — optional in-level mini-challenges including torch lighting, Simon Says, timed platforms, and target shooting
- **Enemy variety** — standard guards, bats, wizards (with vanish/spirit-ball attacks), elite guards, and a multi-phase boss

## Worlds

| World | Theme |
|---|---|
| Intro Level | Scripted opening cutscene |
| Hub Level | Central hub connecting all worlds |
| Coocoo Corsair Cove | Pirate cove |
| Penguin Parkway | Icy penguin territory |
| Krakatoa Volcano | Volcanic hazards & lava |
| Green Oozeland | Toxic waste & ooze |
| Backyard Maze | Suburban labyrinth |
| Kryptek Tower | Wizard tower gauntlet |
| Jungle Jamboree | Dense jungle platforming |
| Creepy Caverns | Dark caverns with stalactites & boulders |
| Wild Wonder Woods | Enchanted forest |
| Titanic Towering Throne | Final boss arena |

## Built With

- **Unity 2020.3.23f1 LTS**
- **Cinemachine** 2.8.3 — camera rigs and cutscene cameras
- **ProBuilder** 4.5.2 — level geometry
- **TextMeshPro** 3.0.6 — UI text
- **Timeline** 1.4.8 — cutscene sequencing

## Team

| Role | Name |
|---|---|
| Design | Mitchell Kraus |
| Design | Travis Bragg |
| Design | Eric Ocampo |
| Design | James Ostrander |
| Design | Yaimee Martinez |
| Art | Star McKinnon-Herrera |
| Art | Jarrod Brown |
| Audio | Aimara Anderson |

## Project Structure

```
Assets/
├── Scripts/
│   ├── Player Scripts/     # Movement, health, jump, animation
│   ├── Attack Scripts/     # Combat and ability scripts
│   ├── Enemy Scripts/      # AI, boss, bat, wizard, elite guard
│   ├── Spooks Scripts/     # Companion behaviors
│   ├── Challenges Scripts/ # Optional in-level challenges
│   ├── Hazard Scripts/     # Environmental hazards
│   ├── Manager Scripts/    # GameManager, SaveLoad, UniqueID
│   ├── DialogSystem/       # Dialogue display and triggers
│   └── Main Menu Scripts/  # Menus, pause, game over
├── Scenes/                 # One folder per world + test scenes
├── Prefabs/
├── Models/
├── Animation/
└── SFX/
```

## Running the Project

1. Install **Unity 2020.3.23f1 LTS** via Unity Hub.
2. Open the project folder in Unity Hub.
3. Open `Assets/Scenes/MainMenuScene.unity` to start from the main menu.

> **Note:** This is the source project. To play without Unity, use the [itch.io build](https://starcloud-games.itch.io/gnash-and-spookz).
