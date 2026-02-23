using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/Step")]
public class TutorialData : ScriptableObject
{
    public string tutorialID;
    [TextArea]
    public string description;
    public TutorialTriggerType triggerType;
}

public enum TutorialTriggerType
{
    PressMoveKey,
}
