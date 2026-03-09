using UnityEngine;

public class DialogInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string dialogTitle;
    [SerializeField] private bool isRepeatable;

    private bool hasTriggered;
    public void Interact()
    {
        if (hasTriggered)
            return;

        DialogRunnerSingleton.instance.GetDialogueRunner().StartDialogue(dialogTitle);
        
        if(!isRepeatable)
            hasTriggered = true;

    }
}
