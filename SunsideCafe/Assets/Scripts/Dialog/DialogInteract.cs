using UnityEngine;

public class DialogInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string dialogTitle;
    public void Interact()
    {
        DialogRunnerSingleton.instance.GetDialogueRunner().StartDialogue(dialogTitle);
    }
}
