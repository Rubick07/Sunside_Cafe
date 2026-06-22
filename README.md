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
<img width="100%" alt="Explore" src="https://github.com/user-attachments/assets/6ec0e809-48a9-43f1-96f9-cf8e136172e7">
</td>
  <td align="center" width="50%">
<strong>Play Minigames</strong><br>
<img width="100%" alt="Minigames" src="https://github.com/user-attachments/assets/d76412f3-e9be-42f9-a03a-910766f8579b">
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
        IM[Input Manager]
        TimelineDayDreamController[Timeline Day Dream Controller]
        DialogRunnerSingleton[Dialog Runner Singleton]
        PauseSystem[Pause System]
        GameManager[Game Manager]
    end
    
    subgraph "Player Systems"
        SideScrollPersonController[Side Scroll Person Controller]
        SideScrollAnimator[Side Scroll Animator]
        ScheduleController[Schedule Controller]
        BaristaController[Barista Controller]
    end

    subgraph "Barista Systems"
        BaristaManager[Barista Manager]
        KettleController[Kettle Controller]
        RecipeManager[Recipe Manager]
        CustomerManager[Customer Manager]
    end

    subgraph "Scheduling Systems"
        ScheduleManager[Schedule Manager]
        ScheduleGrid[Schedule Grid]
    end

    subgraph "Mindfulness Systems"
        MindfulnessManager[Mindfulness Manager]
        BreathingNote[Breathing Note]
    end

    subgraph "UI Systems"
        PauseSystemUI[Pause System UI]
        TimetableUI[Timetable UI]
        BaristaManagerUI[Barista Manager UI]
        DialogRunner[Dialog Runner]
    end

    IM -->SideScrollPersonController
    IM -->ScheduleController
    IM -->BaristaController

    TimelineDayDreamController -->DialogRunnerSingleton

    SideScrollPersonController --> SideScrollAnimator

    KettleController -->RecipeManager
    RecipeManager --> KettleController

    PauseSystem --> PauseSystemUI
    ScheduleManager --> TimetableUI
    BaristaManager -->BaristaManagerUI

    DialogRunnerSingleton --> DialogRunner
    
    classDef coreStyle fill:#e1f5fe,stroke:#01579b,stroke-width:2px
    classDef playerStyle fill:#e8f5e8,stroke:#1b5e20,stroke-width:2px
    classDef baristaStyle fill:#ffebee,stroke:#b71c1c,stroke-width:2px
    classDef SchedulingStyle fill:#fff3e0,stroke:#e65100,stroke-width:2px
    classDef MindStyle fill:#fff3e0,stroke:#e65100,stroke-width:2px
    classDef uiStyle fill:#f3e5f5,stroke:#4a148c,stroke-width:2px
    
    class IM,TimelineDayDreamController,PauseSystem,GameManager,DialogRunnerSingleton coreStyle
    class SideScrollPersonController,SideScrollAnimator,ScheduleController,BaristaController playerStyle
    class BaristaManager,KettleController,RecipeManager,CustomerManager baristaStyle
    class ScheduleManager,ScheduleGrid SchedulingStyle
    class MindfulnessManager,BreathingNote MindStyle
    class PauseSystemUI,TimetableUI,BaristaManagerUI,DialogRunner uiStyle

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
  start([Game Start])
  start --> MainMenu{MainMenu}

  MainMenu -->|New Game| NewGame[New Game]
  MainMenu -->|Options| Options[Open Options]
  MainMenu -->|Exit| ExitGame[Exit Game]

  Options --> MainMenu

  NewGame --> StartGame[Game Start]

  StartGame --> OpeningCutscene[Opening Cutscene]
  OpeningCutscene --> MoveTutorial[Move Tutorial]
  MoveTutorial --> ExploreIsland[Explore Island]

  ExploreIsland --> ClearObjective[ClearObjective]
  ExploreIsland --> TriggerMinigames[Trigger Minigames]

  ClearObjective --> StoryProgression[Story Progression]
  ClearObjective --> ExploreIsland


  TriggerMinigames --> MinigamesComplete[MinigamesComplete]

  MinigamesComplete --> ClearObjective

  StoryProgression --> ExploreIsland
  StoryProgression --> StoryEnd[Ending]

  StoryEnd --> Credit[Credit]
  Credit --> MainMenu
  
```

<br>

## Event Signal Diagram
```mermaid
classDiagram
    %% --- Explore Systems ---
    class SideScrollPersonController {
        +OnPlayerMove()
        +OnPlayerIdle()
    }
    class SideScrollAnimator {
    }
    class SideScrollPersonControllerAction {
    }

    class TimelineDayDreamController {
        +OnAnyTimelineStart()
    }
    class ExploreUI {
    }

    class DialogRunnerSingleton {
        +OnDialogueStart()
        +OnDialogueEnd()
    }

    class PauseSystem {
        +OnGamePause()
        +OnGameUnPause()
    }

    class PauseSystemUI {
    }

    class GameManager {
        +OnGameStateChanged(GameState)
        +OnGameSceneUnloadChanged()
    }


    %% --- Scheduling Systems ---
    class BaristaManager {
        +OnGameStateChanged(baristaGameState)
    }

    class KettleController {
        +OnAnyIngredientListChanged()
        +OnAnyIngredientMix()
        +OnIngredientListChanged(FoodItem)
        +OnIngredientMix()
        +OnKettleStateChanged(KettleState)
    }
    class CustomerSpawner {
    }
    class BaristaTutorial {
    }
    class KettleControllerUI {
    }
    

    %% --- Barista Systems ---
    class ScheduleManager {
        +OnAssignedEmployeeChanged()
    }

    class ScheduleGrid {

    }

    class TimetableUI {

    }
    class ShiftSlotUI {

    }


    %% --- Mindfulness Systems ---
    class MindfulnessManager{
        +OnSuccessHit()
    }

    class BreathingNote{
        +OnSuccess()
        +OnFail()
    }
    class MindfullnessTutorial{
    }

    %% --- Relations ---

    BreathingNote --> MindfulnessManager : GiveSignal
    MindfulnessManager --> MindfullnessTutorial : GiveSuccessSignal

    ScheduleManager --> ScheduleGrid : CreateGridArray
    ScheduleManager --> TimetableUI : Check if all employee assigned
    ScheduleManager --> ShiftSlotUI : Refresh UI

    BaristaManager --> CustomerSpawner : Give Signal if close/open
    KettleController --> BaristaTutorial : Give Signal if tutorial complete
    KettleController --> KettleControllerUI : Give Signal if ready to mix

    SideScrollPersonController --> SideScrollAnimator : Signal to play animation
    TimelineDayDreamController --> ExploreUI : Signal to Show/Hide ExploreUI

    DialogRunnerSingleton --> ExploreUI : Signal to Show/Hide ExploreUI
    DialogRunnerSingleton --> SideScrollPersonControllerAction : Signal if player can move

    PauseSystem --> PauseSystemUI : Signal to Show/Hide PauseSystemUI

    GameManager --> SideScrollPersonControllerAction : Signal to check current state
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
3. Open the MainMenu scene
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

