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
        GameEvents.OnPlaySFX.Invoke("PopUpSFX");

        AddActionTutorial(tutorialTriggerType);

        OnTutorialTrigger?.Invoke(this, tutorialTriggerType);
    }

    public void TutorialComplete()
    {
        OnTutorialComplete?.Invoke(this, EventArgs.Empty);
    }

    public void AddActionTutorial(TutorialTriggerType tutorialTriggerType)
    {

        switch (tutorialTriggerType)
        {
            case TutorialTriggerType.PressMoveKey:
                InputManager.Instance.GetInputActions().Player.Move.performed += Move_performed;
                break;

            case TutorialTriggerType.Interact:
                InputManager.Instance.GetInputActions().Player.Interact.performed += Interact_performed; ;
                break;
        }

    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        InputManager.Instance.GetInputActions().Player.Interact.performed -= Interact_performed; ;

        TutorialComplete();
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        InputManager.Instance.GetInputActions().Player.Move.performed -= Move_performed;
        TutorialComplete();
    }

}

public enum TutorialTriggerType
{
    PressMoveKey,
    Interact,
    AreaChange
}
