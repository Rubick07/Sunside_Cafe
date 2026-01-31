using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogRunnerSingleton : MonoBehaviour
{
    public static DialogRunnerSingleton instance;

    [SerializeField] private Image spriteImage;
    private DialogueRunner dialogueRunner;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        dialogueRunner = FindFirstObjectByType<Yarn.Unity.DialogueRunner>();

        dialogueRunner.AddCommandHandler("SetSpriteDisable",SetSpriteImageDisable);
        dialogueRunner.AddCommandHandler("SetSpriteActive",SetSpriteImageActive);

        dialogueRunner.onDialogueComplete.AddListener(() =>
        {
            spriteImage.enabled = false;
        });

        spriteImage.enabled = false;

    }

    public DialogueRunner GetDialogueRunner()
    {
        return dialogueRunner;
    }

    public void StartDialog(string title, Sprite spriteImage = null)
    {
        this.spriteImage.sprite = spriteImage;

        if (spriteImage != null)
        { 
            this.spriteImage.enabled= true;
        }
        else
        {
            this.spriteImage.enabled = false;
        }

        dialogueRunner.StartDialogue(title);
    }

    public void SetSpriteImageActive()
    {
        if (spriteImage.sprite == null)
            return;

        spriteImage.enabled = true;
    }

    public void SetSpriteImageDisable()
    {
        spriteImage.enabled = false;
    }

}
