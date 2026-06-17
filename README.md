
<p align="center">
  <img width="100%" alt="Sunside" src="https://github.com/user-attachments/assets/5dac01b8-45c3-4fb3-b65f-5907f16febe7">
  </br>
</p>


## 🔴About
Sunside Cafe is a story-driven cafe simulation game about Lucas, a college student struggling with burnout. 
During his summer vacation, he travels to his uncle's small town in hopes of finding peace and recovering from the pressure of university life. 
While helping run his uncle's cafe, Lucas gradually uncovers the problems of the uncle—and his own


<br>

## 🕹️Download Game
google drive: https://drive.google.com/file/d/1HzndWfJgO8YdllTWBCcsIL16DL1zuH0n/view?usp=sharing

<br>

## 📋 Project Info
This project using Unity 6000.0.63f1

| **Role** | **Name** | **Development Time** 
|:-|:-|:-|
| Game Programmer | Evan Jonathan | 3 month |
| Game Artist | Radovieo Anugraha Daffacetta | 3 month |
| Game Designer & Sound | Vincent Pho Wijaya | 3 month |


<br>

##  📜Scripts and Features

- In this game, player explore the map and play various minigames to advance the story
- There are special customer that player need to fulfill for continue the game
- For each minigame, it is in a different scene



|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `SideScrollPersonController.cs` |Manages Side Scroll Player Input|
|  `InputManager.cs` | Manages player input from input system |
| `BaristaManager.cs`  | Manages Barista Minigames flow |
| `RecipeManager.cs`  | Manages Recipe for ingredients mix |
| `KettleManager.cs`  | Manages for ingredients add and mix |
| `GameManager.cs`  | Manages game state and add minigames to scene |
| `ScheduleManager.cs`  | Manages for Scheduling minigames flow |
| `MindfulnessManager.cs`  | Manages for Mindfulness minigames flow |
| `DialogueRunnerSingleton.cs`  | Manages for dialogue system Event |
| `TimelineDayDreamController.cs`  | Manages for timeline event and trigger |
| `etc`  | |


<br>


## 📂Files description

```
├── SunsideCafe                     # In this folder, containing all the Unity project files, to be opened by a Unity Editor
   ├── Assets                       # In this folder, it contains all our code, assets, scenes, etc was not automatically created by Unity
      ├── 2D_Assets                 # In this folder, it contaions all sprites, background, UI image, etc
      ├── Animation_Asset           # In this folder, it contaions all animation clip and animation Controller
      ├── Audio                     # In this folder, it contaions all SFX and BGM
      ├── Fonts                     # In this folder, it contaions all font import
      ├── Plugin                    # In this folder, it contaions plugin for development
      ├── Prefabs                   # In this folder, it contaions all prefabs for the games
      ├── Resources                 # In this folder, it contaions plugin settings
      ├── Scenes                    # In this folder, there are scenes. You can open these scenes to play the game via Unity
      ├── Scripts                   # In this folder, it contaions all script for the games
      ├── Settings                  # In this folder, it contaions base settings from unity
      ├── SignalEmitter             # In this folder, it contaions Signal emitter for timeline
      ├── TextMeshPro               # In this folder, it contaions plugin for TextMeshPro
      ├── Timeline                  # In this folder, it contaions Timeline for cutscene
      ├── Tumbal                    # In this folder, it contaions image for placeholder when development
      ├── TutorialInfo              # In this folder, it contaions URP packages
      ├── UIREF                     # In this folder, it contaions UI reference from figma for applying to games
   ├── ...
      
```
<br>

## 🕹️Game controls

The following controls are bound in-game, for gameplay and testing.

## Player Controller
| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D           | Standard movement |
| E             | Interact with Object/Environment/NPC              |
| Esc              | Pause |
| Tab            | Open/Close Journal |
| Shift           | Sprint/Run            |

## Barista Minigames
| Key Binding       | Function          |
| ----------------- | ----------------- |
| Tab          | Open/Close Recipe |
| Left Mouse Button | Pick up ingredients, drag kettle, drag food to customer|

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
