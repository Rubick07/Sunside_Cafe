using UnityEngine;
using Yarn.Unity;

public class DialogRunnerSingleton : MonoBehaviour
{
    public static DialogRunnerSingleton instance;

    private DialogueRunner dialogueRunner;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        dialogueRunner = FindFirstObjectByType<Yarn.Unity.DialogueRunner>();
    }

    public DialogueRunner GetDialogueRunner()
    {
        return dialogueRunner;
    }

}
