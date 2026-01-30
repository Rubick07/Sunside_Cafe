using UnityEngine;

public class DialogInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string dialogTitle;
    public void Interact()
    {
        Debug.Log("Test");
        DialogRunnerSingleton.instance.GetDialogueRunner().StartDialogue(dialogTitle);
    }
}
