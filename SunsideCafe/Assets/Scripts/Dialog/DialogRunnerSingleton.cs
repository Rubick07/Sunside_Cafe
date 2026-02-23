using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogRunnerSingleton : MonoBehaviour
{
    public static DialogRunnerSingleton instance;

    [SerializeField] private Image spriteImage;
    [SerializeField] private List<NPCData> NPCDatabase;
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
        dialogueRunner.AddCommandHandler<string, string>("SetSprite", SetSprite);

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
/*        this.spriteImage.sprite = spriteImage;

        if (spriteImage != null)
        { 
            this.spriteImage.enabled= true;
        }
        else
        {
            this.spriteImage.enabled = false;
        }
*/
        dialogueRunner.StartDialogue(title);
    }


    public Sprite GetPortrait(string character, string emotion)
    {
        foreach (var c in NPCDatabase)
        {
            if (c.npcName == character)
                return c.GetEmotion(emotion);
        }

        Debug.LogWarning($"Character '{character}' not found");
        return null;
    }

    public void SetSprite(string character, string emotion)
    {
        if(GetPortrait(character, emotion))
        {
            this.spriteImage.sprite = GetPortrait(character, emotion);
            SetSpriteImageActive();
        }
        else
        {
            SetSpriteImageDisable();
        }
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

    public void SetSpriteImageLarge()
    {
        RectTransform rectTransform = spriteImage.GetComponent<RectTransform>();
    }
    public void SetSpriteImageNormal()
    {

    }


}
