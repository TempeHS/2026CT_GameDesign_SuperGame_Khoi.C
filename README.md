# Unity Game Development Summary

| Field | Detail |
|---|---|
| **Game Title** |IN=SOMNIA|
| **Student Name(s)** |KhoiC|
| **Class / Course** |10CT1 / Computer Technology|
| **Repository** |https://github.com/TempeHS/2026CT_GameDesign_SuperGame_Khoi.C/tree/main|
| **Unity Version** |6000.0.58f1|
| **Document Version** |0.1|
| **Date** |27/08/2026|

---

## Table of Contents
1. [Game Overview](#1-game-overview)
2. [Video Walkthrough](#2-video-walkthrough)
3. [Game Mechanics](#3-game-mechanics)
4. [Visual Features](#4-visual-features)
5. [Audio Design](#5-audio-design)
6. [User Interface & HUD](#6-user-interface--hud)
7. [Scene & Level Design](#7-scene--level-design)
8. [Scripts & Programming](#8-scripts--programming)
9. [Development Techniques & Tutorials Acknowledged](#9-development-techniques--tutorials-acknowledged)
10. [Third-Party Content Acknowledgements](#10-third-party-content-acknowledgements)
11. [Challenges & Solutions](#11-challenges--solutions)
12. [Branch Development Summary](#12-branch-development-summary)

---

## 1. Game Overview

### 1.1 Genre
Action

### 1.2 Target Audience
People aged 13-24 years, as mental health is prominent in this age range.

### 1.3 Game Summary
My game will be a 2D scrolling platformer that explores mental health issues. In the game, you will play as a person suffering from various mental health problems and you must explore their subconsciousness to help them. You must navigate through obstacles and puzzles to relieve mental strain on the character. The game should be in a pixel art style to represent the disconnection from reality, and its core mechanic is to explore your vices and resolve them.

### 1.4 Win / Loss Conditions
| Condition | Description |
|---|---|
| Win |Defeat the boss of the level.|
| Loss |Lose all your hearts.|

### 1.5 Platform & Build Settings
| Setting | Detail |
|---|---|
| Target Platform |Windows|
| Resolution |1920x1080|
| Build Type |Development|

---

## 2. Video Walkthrough

### 2.1 Full Gameplay Walkthrough

<!--
  Embed a YouTube/Vimeo video or link to a file in the repository.
  YouTube embed syntax:
  [![Video Title](https://img.youtube.com/vi/VIDEO_ID/0.jpg)](https://www.youtube.com/watch?v=VIDEO_ID)

  OR link to a local file:
  [Watch Walkthrough Video](./docs/video/walkthrough.mp4)
-->

| Field | Detail |
|---|---|
| **Video Title** | |
| **Link / Embed** | |
| **Duration** | |
| **Description** | |

### 2.2 Feature Highlight Clips

| Clip | Description | Link |
|---|---|---|
| | | |
| | | |
| | | |

---

## 3. Game Mechanics

### 3.1 Core Mechanics
| ID | Mechanic | Description | Implemented In (Script/Object) |
|---|---|---|---|
| M-1 |Collect|Allows the player to collect orbs around the level.|Orb: OrbController|
| M-2 |Health|Health tracks the player's amount of lives.|Heart: HealthSystem|
| M-3 |Enemy|Jumping on enemies allows you to defeat them.|Enemy: EnemyBehaviour|
| M-4 |Lava|Lava damages the player when they step in it.|Obstacle: PlayerMovement|
| M-5 | | | |

### 3.2 Player Controls
| Action | Input (Keyboard / Controller) | Description |
|---|---|---|
|Jump|SPACE|Allows the player to jump. Jump height varies on how long the player holds the space bar.|
|Drop|S|Allows the player to drop through one way platforms.|
|Horizontal Movement|A / D|Lets the player move left and right.|
| | | |

### 3.3 Physics & Collision
| Feature | Description |
|---|---|
|Tilemap|A grid of tiles that the player walks on.|
|Enemy|When the player jumps on an enemy, a small bounce is applied.|
|Orbs|When the player collides with an orb it disappears and adds to the count.|

### 3.4 Game Loop
| Stage | Description |
|---|---|
| Start / Initialisation | |
| Core Loop | |
| Win / End State | |
| Restart | |

### 3.5 Scoring & Progression
| Element | Description |
|---|---|
| Scoring System | |
| Difficulty Progression | |
| Unlockables / Levels | |

---

## 4. Visual Features

### 4.1 Particle Effects

| Effect Name | Purpose | Screenshot |
|---|---|---|
| | | |
| | | |
| | | |
| | | |

> Add screenshot images using: `![Effect Name](./docs/screenshots/effect_name.png)`

---

### 4.2 Cut Scenes & Cinematics

| Cut Scene | Trigger | Description | Screenshot / Still |
|---|---|---|---|
| | | | |
| | | | |
| | | | |

> Add screenshot images using: `![Cut Scene Name](./docs/screenshots/cutscene_name.png)`

---

### 4.3 Animations

| Animation | Object / Character | Description | Screenshot |
|---|---|---|---|
| | | | |
| | | | |
| | | | |

> Add screenshot images using: `![Animation Name](./docs/screenshots/animation_name.png)`

---

### 4.4 Lighting & Post-Processing

| Feature | Description | Screenshot |
|---|---|---|
|ShadowCaster2D|Casts shadows around the level.| |
|Spot Light|Shines light in one specific spot.| |
|Lava Light|Creates a light game object at every lava tile.| |

> Add screenshot images using: `![Feature Name](./docs/screenshots/lighting_name.png)`

---

### 4.5 Shaders & Materials

| Shader / Material | Applied To | Description | Screenshot |
|---|---|---|---|
| | | | |
| | | | |
| | | | |

> Add screenshot images using: `![Shader Name](./docs/screenshots/shader_name.png)`

---

### 4.6 Additional Visual Screenshots

<!--
  Add any other notable screenshots here.
  Syntax: ![Description](./docs/screenshots/filename.png)
-->

| Description | Screenshot |
|---|---|
| | |
| | |
| | |

---

## 5. Audio Design

### 5.1 Music
| Track | Scene / Trigger | Source / Composer |
|---|---|---|
|WhitePalace|Main Menu|Composed by Christopher Larkin in 'Hollow Knight'.|
|Confined|Anxiety Level|Composed by Mekbok in 'The Foundation'.|

### 5.2 Sound Effects
| Sound Effect | Trigger | Source |
|---|---|---|
|UIHover|When a UI element is hovered.|400 Sounds Pack by Chequered Ink - Itch.io|
|UIClick|When a UI element is clicked.|400 Sounds Pack by Chequered Ink - Itch.io|
| | | |
| | | |

### 5.3 Audio Implementation
| Feature | Description |
|---|---|
| Audio Mixer / Groups | |
| Spatial / 3D Audio | |
| Dynamic Audio | |

---

## 6. User Interface & HUD

### 6.1 HUD Elements
| Element | Purpose | Screenshot |
|---|---|---|
| | | |
| | | |
| | | |

> Add screenshot images using: `![HUD Element](./docs/screenshots/hud_name.png)`

### 6.2 Menus
| Menu | Purpose | Screenshot |
|---|---|---|
| Main Menu | | |
| Pause Menu | | |
| Game Over Screen | | |
| | | |

> Add screenshot images using: `![Menu Name](./docs/screenshots/menu_name.png)`

---

## 7. Scene & Level Design

### 7.1 Scene List
| Scene Name | Purpose | Description |
|---|---|---|
| | | |
| | | |
| | | |
| | | |

### 7.2 Level / Environment Screenshots
| Level / Area | Description | Screenshot |
|---|---|---|
| | | |
| | | |
| | | |

> Add screenshot images using: `![Level Name](./docs/screenshots/level_name.png)`

### 7.3 Scene Management
| Feature | Description |
|---|---|
| Scene Loading Method | |
| Persistent Data Between Scenes | |
| Scene Transition Effects | |

---

## 8. Scripts & Programming

### 8.1 Script Summary
| Script Name | Attached To | Responsibility |
|---|---|---|
|PlayerMovement|Player|Player movement and main controller.|
|BGController|Parallax|Controls parallax background elements.|
|EnemyBehaviour|Enemy|Allows the enemy to move around and jump.|
|OrbController|Orb|Allows orbs to be collected.|
|MainMenu|Main Menu Elements|Individually controls each of the UI elements.|

### 8.2 Key Algorithms / Logic
| Feature | Script | Description |
|---|---|---|
| | | |
| | | |
| | | |

### 8.3 Design Patterns Used
| Pattern | Where Applied | Justification |
|---|---|---|
| | | |
| | | |
| | | |

---

## 9. Development Techniques & Tutorials Acknowledged

> List every tutorial, course, video, or article that informed or guided your implementation. Include what you used it for and what you changed or adapted.

| # | Title | Author / Creator | URL / Source | What You Used It For | What You Changed / Adapted |
|---|---|---|---|---|---|
| 1 |Quick Shadow Creation with One Click - Unity2D Auto SHADOW CASTER 2D creator|Rehope Games|https://www.youtube.com/watch?v=n3tgimClTrI|I used it to create shadows in my level and modify lights for different objects.|I added a Game Object Brush to automatically generate lights in my scene.|
| 2 |Make Your MAIN MENU Quickly! - Unity UI Tutorial For Beginners|Rehope Games|https://www.youtube.com/watch?v=DX7HyN7oJjE|I used it to make my main menu and UI elements in the level.|I added UI animations and improved the settings panel.|
| 3 |How to Add MUSIC and SOUND EFFECTS to a Game in Unity - Unity 2D Platformer Tutorial #16|Rehope Games|https://www.youtube.com/watch?v=N8whM1GjH4w|I used it to start music in my game and implement sound effects.|I used the sound effects for UI elements as well.|
| 4 |Dynamic Heart System - Heart Health Bar - Unity Tutorial|Hyyder Works|https://www.youtube.com/watch?v=lBRwsl25jUs|I made a heart health system to keep track of the player health.|I changed the script to generate a custom amount of hearts.|
| 5 |Easy Tilemaps and Dynamic Auto Tiling - Unity 2D|Game Code Library|https://www.youtube.com/watch?v=8UctaO5DwUE|I used this to make the tilemap that creates the level|I added tiles that have different functions like ones that damage you.|
| 6 |Adding Dust Particle Effects - 2D Platformer Unity #6|Game Code Library|https://www.youtube.com/watch?v=aEGJn5hu_qw|I used this to make the player particle effects.|I also added particle systems for the enemy and flares.|
| 7 | | | | | |
| 8 | | | | | |

---

## 10. Third-Party Content Acknowledgements

> All third-party assets (art, audio, fonts, scripts, packages) must be listed here with their licence. Using an asset without acknowledgement may constitute academic misconduct.

### 10.1 Visual Assets
| Asset Name | Type | Creator / Source | Licence | URL | Used For |
|---|---|---|---|---|---|
| | | | | | |
| | | | | | |
| | | | | | |

### 10.2 Audio Assets
| Asset Name | Type | Creator / Source | Licence | URL | Used For |
|---|---|---|---|---|---|
| | | | | | |
| | | | | | |
| | | | | | |

### 10.3 Scripts & Code Snippets
| Script / Snippet | Source | Licence | URL | Used For | Changes Made |
|---|---|---|---|---|---|
| | | | | | |
| | | | | | |

### 10.4 Unity Packages & Plugins
| Package Name | Version | Source | Licence | URL | Purpose |
|---|---|---|---|---|---|
| | | | | | |
| | | | | | |
| | | | | | |

### 10.5 Fonts
| Font Name | Creator / Source | Licence | URL |
|---|---|---|---|
| | | | |
| | | | |

---

## 11. Challenges & Solutions

| # | Challenge Encountered | How It Was Solved |
|---|---|---|
| 1 | | |
| 2 | | |
| 3 | | |
| 4 | | |
| 5 | | |

---

## 12. Branch Development Summary

> One section per feature branch. Add or remove sections to match your repository. Branches should be named for the feature they implement e.g. `feature/player-movement`. Link each branch name directly to the branch in your GitHub repository.

---

### Branch 1 — `main`

| Field | Detail |
|---|---|
| **Branch Name** | `main` |
| **Purpose** | Stable, releasable version of the game |
| **Merged From** | |
| **Final Commit** | |

---

### Branch 2 — `feature/`

| Field | Detail |
|---|---|
| **Branch Name** | |
| **Feature Developed** | |
| **Merged Into** | |
| **Date Started** | |
| **Date Merged** | |

#### What Was Built
<!-- Describe what this branch added or changed -->

#### Key Commits
| Commit Message | What Changed |
|---|---|
| | |
| | |
| | |

#### Problems Encountered & Resolved
| Problem | Resolution |
|---|---|
| | |
| | |

#### Screenshot / Evidence
<!-- Add a screenshot of the feature working -->
> `![Feature Name](./docs/screenshots/branch_feature_name.png)`

---

### Branch 3 — `feature/`

| Field | Detail |
|---|---|
| **Branch Name** | |
| **Feature Developed** | |
| **Merged Into** | |
| **Date Started** | |
| **Date Merged** | |

#### What Was Built


#### Key Commits
| Commit Message | What Changed |
|---|---|
| | |
| | |
| | |

#### Problems Encountered & Resolved
| Problem | Resolution |
|---|---|
| | |
| | |

#### Screenshot / Evidence
> `![Feature Name](./docs/screenshots/branch_feature_name.png)`

---

### Branch 4 — `feature/`

| Field | Detail |
|---|---|
| **Branch Name** | |
| **Feature Developed** | |
| **Merged Into** | |
| **Date Started** | |
| **Date Merged** | |

#### What Was Built


#### Key Commits
| Commit Message | What Changed |
|---|---|
| | |
| | |
| | |

#### Problems Encountered & Resolved
| Problem | Resolution |
|---|---|
| | |
| | |

#### Screenshot / Evidence
> `![Feature Name](./docs/screenshots/branch_feature_name.png)`

---

### Branch 5 — `feature/`

| Field | Detail |
|---|---|
| **Branch Name** | |
| **Feature Developed** | |
| **Merged Into** | |
| **Date Started** | |
| **Date Merged** | |

#### What Was Built


#### Key Commits
| Commit Message | What Changed |
|---|---|
| | |
| | |
| | |

#### Problems Encountered & Resolved
| Problem | Resolution |
|---|---|
| | |
| | |

#### Screenshot / Evidence
> `![Feature Name](./docs/screenshots/branch_feature_name.png)`

---

### Branch 6 — `feature/`

| Field | Detail |
|---|---|
| **Branch Name** | |
| **Feature Developed** | |
| **Merged Into** | |
| **Date Started** | |
| **Date Merged** | |

#### What Was Built


#### Key Commits
| Commit Message | What Changed |
|---|---|
| | |
| | |
| | |

#### Problems Encountered & Resolved
| Problem | Resolution |
|---|---|
| | |
| | |

#### Screenshot / Evidence
> `![Feature Name](./docs/screenshots/branch_feature_name.png)`

---

### Branch Development Overview

> Complete this summary table once all branches are finished.

| Branch Name | Feature | Date Started | Date Merged | Status |
|---|---|---|---|---|
| `main` | Stable release | | | |
| `feature/` | | | | |
| `feature/` | | | | |
| `feature/` | | | | |
| `feature/` | | | | |
| `feature/` | | | | |

---

> **Student Declaration:** All work submitted is my own except where explicitly acknowledged above.