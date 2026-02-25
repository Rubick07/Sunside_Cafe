using UnityEngine;
using System;
public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    public event EventHandler<TutorialTriggerType> OnTutorialTrigger;
    public event EventHandler OnTutorialComplete;

    private void Awake()
    {
        instance = this;
    }

    public void TriggerTutorial(TutorialTriggerType tutorialTriggerType)
    {
        OnTutorialTrigger?.Invoke(this, tutorialTriggerType);
    }

    public void TutorialComplete()
    {
        OnTutorialComplete?.Invoke(this, EventArgs.Empty);
    }



}

public enum TutorialTriggerType
{
    PressMoveKey,
    Interact
}
