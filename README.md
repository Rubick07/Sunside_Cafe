
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
| Game Programmer | Evan Jonathan | 3 months |
| Game Artist | Radovieo Anugraha Daffacetta | 3 months |
| Game Designer & Sound | Vincent Pho Wijaya | 3 months |


<br>

##  📜Scripts and Features
• Customer Order Management <br>
• Cafe Upgrade System<br>
• Daily Schedule Progression<br>
• Rhythm-Based Mindfulness Minigames<br>
• Multiple Story Endings<br>
• For each minigame, it is in a different scene<br>



|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `SideScrollPersonController.cs` |Handles player movement and controls in side-scrolling sections|
|  `InputManager.cs` |Handles player input through the Input System |
| `BaristaManager.cs`  | Manages the flow of the Barista minigame |
| `RecipeManager.cs`  | Manages recipes and ingredient combinations |
| `KettleManager.cs`  | Handles ingredient mixing and brewing processes|
| `GameManager.cs`  | Manages game states and minigame initialization|
| `ScheduleManager.cs`  | Manages the scheduling minigame flow|
| `MindfulnessManager.cs`  | Manages the mindfulness minigame flow |
| `DialogueRunnerSingleton.cs`  | Handles dialogue events and progression |
| `TimelineDayDreamController.cs`  | Manages Timeline events and triggers |
| `etc`  | |


<br>


## 📂Files description

```
├── SunsideCafe                     # In this folder, containing all the Unity project files, to be opened by a Unity Editor
   ├── Assets                       # Project assets and resources
      ├── 2D_Assets                 # 2D sprites, backgrounds, and UI images
      ├── Animation_Asset           # Animation clips and Animator Controllers
      ├── Audio                     # Sound effects and background music
      ├── Fonts                     # Font assets
      ├── Plugin                    # Third-party plugins and development tools
      ├── Prefabs                   # Reusable game object prefabs
      ├── Resources                 # Resources loaded at runtime
      ├── Scenes                    # Game scenes
      ├── Scripts                   # Gameplay and system scripts
      ├── Settings                  # Unity project settings and configurations
      ├── SignalEmitter             # Timeline Signal Emitters
      ├── TextMeshPro               # TextMeshPro assets and resources
      ├── Timeline                  # Timeline assets for cutscenes and events
      ├── Tumbal                    # Temporary placeholder assets used during development
      ├── TutorialInfo              # Unity-generated tutorial and URP resources
      ├── UIREF                     # UI references imported from Figma
   ├── ...
      
```
<br>

## 🕹️Game controls

The following controls are bound in-game, for gameplay and testing.

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
