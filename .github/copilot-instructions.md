# Gnash and Spookz — Copilot Instructions

## Project Overview

This is a 3D action-platformer Unity game (Unity **2020.3.23f1 LTS**). The player controls a character (Gnash) who can fight enemies, collect wisps and portrait pieces across multiple levels, and unlock abilities. "Spooks" is a companion character with their own scripted behaviors.

## Architecture

### Scene Structure
- **MainMenuScene** — entry point
- **HubLevel** — central hub connecting all world levels
- **World levels**: CoocooCorsairCove, PenguinParkway, KrakatoaVolcano, GreenOozeland, Backyard_Maze, KryptekTower, Jungle Jamboree, Creepy Caverns, Wild Wonder Woods, Titanic Towering Throne
- **BossTest** — boss encounter scene
- **IntroLevel** — scripted intro/cutscene level; HUD is hidden here and `PlayerMovement.isIntroAnim` is set true
- Test/metrics scenes exist for development use

### Save System
`SaveLoad.cs` is a static utility that serializes/deserializes objects using `BinaryFormatter` to `Application.persistentDataPath + "/saves/<key>.txt"`. Most game state (collected items, door states) uses this via `CollectableItemSet` and `DoorSet`, which wrap `HashSet<string>`. Player stats (lives, max health, ability unlocks) use `PlayerPrefs`.

### Collectible Persistence
Each collectible `GameObject` has a `UniqueID` component. The ID is derived from `transform.position.sqrMagnitude + "-" + name + "-" + transform.GetSiblingIndex()`. On scene load, `CollectableItemSet` checks this ID and destroys already-collected items. On pickup, the ID is added to the set and saved.

### Ability System
Abilities are gated by `PlayerPrefs` integer keys:
- `SpinAttackAbility`, `ShieldAbility`, `FireBallAbility`, `DashAbility`, `DecoyAbility` — `1` = unlocked, `0` = locked

Each ability script checks `PlayerPrefs.GetInt("<AbilityKey>") == 1` in `Start()` and `Update()` to show/hide UI and enable input.

### GameManager (Singleton)
`GameManager` is a scene-level singleton (`public static GameManager manager`). It is **not** a DontDestroyOnLoad singleton — a new instance is expected in every gameplay scene. It manages HUD visibility and routes wisp/portrait collection events to the per-scene UI counters in `CollectableMenuUI`. HUD is disabled for IntroLevel; collectables UI is disabled for Titanic Towering Throne.

### Player Scripts (`Assets/Scripts/Player Scripts/`)
- **`PlayerMovement.cs`** — camera-relative movement via `CharacterController`; `PlayerMovement.canMove` (static bool) is the global movement lock used by many other scripts
- **`Player_Jump.cs`** — ground check via `Physics.CheckSphere`; variable jump height via hold-to-extend pattern; integrates with `SpooksParachuting`
- **`PlayerHealth.cs`** — health + lives system; lives/max health in `PlayerPrefs`; `PlayerHealth.isInCutscene` (static bool) blocks damage during cutscenes
- **`PlayerAnimController.cs`** — drives the player `Animator`

### Enemy Scripts (`Assets/Scripts/Enemy Scripts/`)
- **`Enemy.cs`** (base enemy) — `NavMeshAgent`-based; two patrol modes (`RandomNav` / `WaypointNav`) set via serialized enum; transitions to chase on trigger enter with `"Player"` tag
- Specialised enemies: `Bat_Enemy`, wizard variants, elite guards, lava/toxic effect scripts
- Attack damage flows from enemy → `PlayerHealth.DamageHealth()`; attack from player → `Enemy.TakeDamage()` / `Bat_Enemy.TakeDamage()`

### Attack Scripts (`Assets/Scripts/Attack Scripts/`)
- **`BaseAttack.cs`** — disables `PlayerMovement` component during swing; colliders activated/deactivated per animation frame
- Abilities (`SpinAttack`, `ShootAbility`, `RollAttack`, etc.) each manage their own cooldown timer and UI `Image.fillAmount` radial fill

### Challenges (`Assets/Scripts/Challenges Scripts/`)
Optional in-level challenges (defeat N enemies, torch lighting, Simon Says, timed platforms, target shooting). Each challenge has a `challengeEnabled` bool and score tracked in its component.

## Key Conventions

- **Static booleans as global flags**: `PlayerMovement.canMove`, `PlayerHealth.isInCutscene`, `PlayerMovement.isIntroAnim` are static fields used across many scripts as scene-wide state. Set these when locking/unlocking player control.
- **`GameObject.Find` / `FindObjectOfType` in `Awake`/`Start`**: Scene object references are resolved at runtime by name (e.g., `GameObject.Find("AudioSource")`, `GameObject.Find("HUD")`). These GameObject names must match exactly.
- **Tags used for game logic**: `"Player"`, `"Wisp"`, `"PortraitPiece"` tags are checked in `OnTriggerEnter`/`OnTriggerStay` across many scripts. Keep tags consistent when creating new collectibles or enemies.
- **Script authorship headers**: Several scripts include `// Created by:` and source citation comments. Follow this pattern when adding new scripts.
- **`PlayerPrefs` for cross-scene state**: Anything that must persist between scene loads (lives, health, ability unlock state, collectible counts) goes in `PlayerPrefs`. Session-within-scene collectible tracking goes through `SaveLoad`/`CollectableItemSet`.
- **Attack enabling pattern**: Attack scripts disable the `PlayerMovement` MonoBehaviour (not the GameObject) during an attack animation, and re-enable it in the "off" method. Do not disable the GameObject for movement lock.
- **Enemy death**: Enemies call `StartCoroutine(Death())` which waits 0.5 s then calls `gameObject.SetActive(false)` — they are deactivated, not destroyed, to allow death animation to play.

## Packages

| Package | Version |
|---|---|
| Cinemachine | 2.8.3 |
| ProBuilder | 4.5.2 |
| TextMeshPro | 3.0.6 |
| Timeline | 1.4.8 |
| Unity Test Framework | 1.1.29 |
