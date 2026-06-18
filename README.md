<p align="center">
  <img width="100%" alt="Sunside" src="https://github.com/user-attachments/assets/5dac01b8-45c3-4fb3-b65f-5907f16febe7">
  </br>
</p>

## Developer & Contributions
**Evan Jonathan** (Game Programmer) <br>
**Radovieo Anugraha Daffacetta** (Game Artist)<br>
**Vincent Pho Wijaya** (Game Designer) 

## About
Sunside Cafe is a story-driven cafe simulation game about Lucas, a college student struggling with burnout. 
During his summer vacation, he travels to his uncle's small town in hopes of finding peace and recovering from the pressure of university life. 
While helping run his uncle's cafe, Lucas gradually uncovers the problems of the uncle—and his own
<br>

<br>

## Key Features

• Customer Order Management <br>
• Cafe Upgrade System<br>
• Daily Schedule Progression<br>
• Rhythm-Based Mindfulness Minigames<br>
• Multiple Story Endings<br>
• For each minigame, it is in a different scene<br>


<table>
<tr>
<td align="center" width="50%">
<strong>Explore the island</strong><br>
<img width="100%" alt="Tactical" src="https://github.com/user-attachments/assets/4194228d-5b9c-4dd2-a70f-52a3106782b5">
</td>
</tr>
</table>


## Scene Flow
```mermaid
flowchart LR
  mm[Main Menu]
  ca[City Area]
  m[Minigames]
  Credit[Ending Scene]


  mm -- "Start Game" --> ca
  ca -- "Trigger Minigames" --> m
  m -- "Minigames Clear" --> ca

  ca -- "Credit" --> Credit

  Credit --> mm

```

## Layer / Module Design
```mermaid
---
config:
  theme: neutral
  look: neo
---
graph TD
    subgraph "Core Systems"
        IM[InputManager]
        Ts[Turn System]
        
    end
    
    subgraph "Player Systems"
        UAS[Unit Action System]
        CC[Camera Controller]
    end
    
    subgraph "Unit System"
        U[Unit]
        UM[Unit Manager]
        HS[Health System]
        BA[Base Action]
    end
    
    subgraph "Tile-based Systems"
        GS[Grid System]
        LG[LevelGrid]
        GSV[Grid System Visual]
    end

    subgraph "Enemy Systems"
        EA[Enemy AI]
    end

    subgraph "UI Systems"
        UnitActionSystemUI[Unit Action SystemUI]
        TurnSystemUI[Turn System UI]
        ActionBusyUI[Action Busy UI]
        HealthSystemUI[HealthSystemUI]
    end

    IM --> UAS
    IM --> CC

    Ts --> TurnSystemUI
    UAS --> UnitActionSystemUI
    UAS --> U
    U --> UM
    U --> HS
    U --> BA
    U --> UnitActionSystemUI

    BA --> ActionBusyUI
    HS --> HealthSystemUI

    GS --> LG
    LG --> GSV

    EA --> U
    
    
    
    classDef coreStyle fill:#e1f5fe,stroke:#01579b,stroke-width:2px
    classDef playerStyle fill:#e8f5e8,stroke:#1b5e20,stroke-width:2px
    classDef enemyStyle fill:#ffebee,stroke:#b71c1c,stroke-width:2px
    classDef unitStyle fill:#fff3e0,stroke:#e65100,stroke-width:2px
    classDef uiStyle fill:#f3e5f5,stroke:#4a148c,stroke-width:2px
    
    class IM,Ts coreStyle
    class UAS,CC playerStyle
    class EAI enemyStyle
    class U,UM,HS unitStyle
    class UnitActionSystemUI,TurnSystemUI,ActionBusyUI uiStyle

```

## Modules and Features

The 2D Narrative Adventure gameplay with SideScrollPersonController,InputManager, GameManager, and DialogueRunnerSingleton is powered by an extensive Unity C# scripting system.

|  📂 Name     | 🎬 Scene |  📋 Responsibility                                                 |
| ------------------- |----------------| ------------------------------------------------------------ |
| `SideScrollPersonController` | City_Area |Handles player movement and controls in side-scrolling sections|
| `InputManager` | City_Area |Handles player input through the Input System |
| `BaristaManager`    | All Cafe_Barista scenes |Manages the flow of the Barista minigame|
|  `RecipeManager.cs` | All Cafe_Barista scenes | Manages recipes and ingredient combinations|
| `KettleManager.cs`  | All Cafe_Barista scenes | Handles ingredient mixing and brewing processes|
| `GameManager.cs`  | City_Area | Manages game states and minigame initialization|
| `ScheduleManager.cs`| All Cafe_ShiftSystem scenes | Handles unit animations and visual effects|
| `MindfulnessManager.cs`| All Mindfulness_Practice scenes| Manages the mindfulness minigame flow  |
| `DialogueRunnerSingleton.cs`| City_Area | Handles dialogue events and progression |
| `TimelineDayDreamController.cs`| City_Area | Manages Timeline events and triggers |


<br>

## Game Flow Chart
```mermaid
---
config:
  theme: redux
  look: neo
---
flowchart TD
  start([Battle Start])
  start --> TurnSystemCheck{Check Is Player Turn}

  TurnSystemCheck -->|Yes| move{Player Input}
  TurnSystemCheck -->|No| EnemyAI[EnemyAI]

  
  move -->|Left Mouse Button| SU[Select Unit]
  move -->|Click End Turn Button| EndTurn[EndTurn]

  EndTurn --> ChangeTurnSystemEnemy[Change To Enemy Turn]

  ChangeTurnSystemEnemy --> TurnSystemCheck

  SU --> CheckAction{does it have action points?}

  CheckAction -->|Yes| SelectAction[SelectAction]
  CheckAction -->|No| ded[Cant perform Action]

  ded --> move

  SelectAction --> SelectActionTargetGrid[SelectActionTargetGrid]
  
  SelectActionTargetGrid --> PlayerUnitActionPerform[Player Unit Action Perform]

  PlayerUnitActionPerform --> CheckEnemyHealth{Is There Enemy Unit Health <= 0?}

    CheckEnemyHealth -->|Yes| EnemyUnitDead[Enemy Unit Dead]
    CheckEnemyHealth -->|No| PlayerUnitActionComplete[Player Unit Action Complete]

    EnemyUnitDead --> CheckEnemyUnitList{Check Unit Manager Are there still Enemy unit on the battlefield?}

    CheckEnemyUnitList -->|Yes| move
    CheckEnemyUnitList -->|No| Victory[Victory!]
    
    PlayerUnitActionComplete --> move
  
    EnemyAI --> ChooseEnemyUnit[Choose Enemy Unit]

    ChooseEnemyUnit --> CheckEnemyUnitActionPoin[Check if Enemy Unit has Action Points]

    CheckEnemyUnitActionPoin -->|Yes| chooseBestEnemyAction[Choose Best Enemy Action]
    CheckEnemyUnitActionPoin -->|No| CheckOtherEnemyUnit[Check Other Enemy Unit]

    CheckOtherEnemyUnit --> EnemyEnd{Check if All Enemy Unit dont have ActionValue}

    EnemyEnd -->|Yes| EnemyUnitEndTurn[Enemy Unit End Turn]
    EnemyEnd -->|No| ChooseEnemyUnit[Check Other Enemy Unit]

    ChooseBestEnemyAction --> EnemyActionPerform[EnemyActionPerform]

    EnemyActionPerform --> CheckPlayerHealth{Is There Player Unit Health <= 0?}

    CheckPlayerHealth -->|Yes| PlayerUnitDead[Player Unit Dead]
    CheckPlayerHealth -->|No| EnemyAI

    PlayerUnitDead --> CheckPlayerUnitList{Check Unit Manager Are there still Player unit on the battlefield?}

    CheckPlayerUnitList -->|Yes| EnemyAI
    CheckPlayerUnitList -->|No| Defeat[DEFEAT!]

    EnemyUnitEndTurn --> ChangeToPlayerTurn[Change To Player Turn]
    ChangeToPlayerTurn --> TurnSystemCheck
    
```

<br>

## Event Signal Diagram
```mermaid
classDiagram
    %% --- Unit Systems ---
    class Unit {
        +OnAnyActionPointsChanged()
        +OnAnyUnitSpawned()
        +OnAnyUnitDead()
    }

    class UnitActionSystem {
        +OnSelectedUnitChanged()
        +OnSelectedActionChanged()
        +OnBusyChanged(bool)
        +OnActionStarted()
    }

    class HealthSystem {
        +OnDead()
        +OnDamaged()
    }

    class BaseAction{
        OnAnyActionStart()
        OnAnyActionComplete()  
    }


    class LevelGrid{
      OnAnyUnitMovedGridPosition()
    }

    %% --- Relations ---
    UnitManager --> Unit : Update List

    Unit --> HealthSystem : Take Damage

    HealthSystem --> Unit : Dead

    UnitActionSystem --> BaseAction : PerformAction

    MoveAction --> LevelGrid : UpdatePosition

```

<br>
## Play The Game
<a href="https://drive.google.com/file/d/1HzndWfJgO8YdllTWBCcsIL16DL1zuH0n/view?usp=sharing">Download</a>

<br>

## Installation & Setup
Using Google Drive
1. Download Sunside Cafe from Google Drive
2. Extract .zip file
3. Launch Sunside Cafe to play.

Using Github
1. Clone this repository
2. Open the project in Unity (6 or later recommended)
3. Open the main gameplay scene
4. Press Play to start testing

## Controls
## Player Controller
| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D           | Standard movement |
| E             | Interact with Objects/Environments/NPCs            |
| Esc              | Pause |
| Tab            | Open/Close Journal |
| Shift           | Sprint/Run            |

## Barista Minigames
| Key Binding       | Function          |
| ----------------- | ----------------- |
| Tab          | Open/Close Recipe |
| Left Mouse Button | Pick up ingredients, drag kettle, serve food to customers|

## Scheduling Minigames
| Key Binding       | Function          |
| ----------------- | ----------------- |
| Q                  | Rotate Left schedule |
| E                  | Rotate Right schedule |
| Left Mouse Button  | Drag employee schedule |
| Right Mouse Button | Delete employee schedule|

## Mindfulness Minigames
| Key Binding       | Function          |
| ----------------- | ----------------- |
| Space          | Press at the right timing to complete the mindfulness activity |

<br>

