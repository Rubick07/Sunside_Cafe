using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogRunnerSingleton : MonoBehaviour
{
    public static DialogRunnerSingleton instance;

    [SerializeField] private Image leftSpriteImage;
    [SerializeField] private Image rightSpriteImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private List<NPCData> NPCDatabase;
    [SerializeField] private DialogueRunner dialogueRunner;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        dialogueRunner.AddCommandHandler("SetSpriteLeftLarge",SetSpriteImageLarge);
        dialogueRunner.AddCommandHandler("SetSpriteLeftNormal",SetSpriteImageNormal);

        dialogueRunner.AddCommandHandler("SetBackgroundActive", SetBackgroundImageActive);
        dialogueRunner.AddCommandHandler("SetBackgroundDisable", SetBackgroundImageDisable);

        dialogueRunner.AddCommandHandler<string, string>("SetLeftSprite", SetLeftSprite);
        dialogueRunner.AddCommandHandler<string, string>("SetRightSprite", SetRightSprite);

        dialogueRunner.AddCommandHandler("SetLeftTalk", SetLeftImageisTalking);
        dialogueRunner.AddCommandHandler("SetRightTalk", SetRightImageIsTalking);

        dialogueRunner.onDialogueStart.AddListener(() =>
        {
            RectTransform rectTransform = leftSpriteImage.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(1, 1, 1);

            SetBackgroundImageDisable();

            leftSpriteImage.enabled = false;
            rightSpriteImage.enabled = false;

            leftSpriteImage.color = Color.white;
            rightSpriteImage.color = Color.white;
        });

        dialogueRunner.onDialogueComplete.AddListener(() =>
        {
            leftSpriteImage.enabled = false;
            rightSpriteImage.enabled = false;
        });

        leftSpriteImage.enabled = false;
        rightSpriteImage.enabled = false;
        backgroundImage.enabled = false;
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

    public void StartDialogCutscene(string title)
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

    public void SetLeftSprite(string character, string emotion)
    {
        if(GetPortrait(character, emotion))
        {
            this.leftSpriteImage.sprite = GetPortrait(character, emotion);
            SetLeftSpriteImageActive();
        }
        else
        {
            leftSpriteImage.enabled = false;
        }
    }

    public void SetRightSprite(string character, string emotion)
    {
        if (GetPortrait(character, emotion))
        {
            this.rightSpriteImage.sprite = GetPortrait(character, emotion);
            SetRightSpriteImageActive();
        }
        else
        {
            SetRightSpriteImageActive();
        }
    }

    public void SetLeftSpriteImageActive()
    {
        if (leftSpriteImage.sprite == null)
            return;

        leftSpriteImage.enabled = true;
    }

    public void SetRightSpriteImageActive()
    {
        if (rightSpriteImage.sprite == null)
            return;

        rightSpriteImage.enabled = true;
    }

    public void SetBackgroundImageActive()
    {
        backgroundImage.enabled = true;
    }

    public void SetBackgroundImageDisable()
    {
        backgroundImage.enabled = false;
    }


    public void SetSpriteImageLarge()
    {
        RectTransform rectTransform = leftSpriteImage.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(1.5f, 1.5f, 1.5f); 
    }
    public void SetSpriteImageNormal()
    {
        RectTransform rectTransform = leftSpriteImage.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(1, 1, 1);
    }

    public void SetLeftImageisTalking()
    {
        leftSpriteImage.color = Color.white;
        rightSpriteImage.color = Color.grey;
    }
    public void SetRightImageIsTalking()
    {
        leftSpriteImage.color = Color.grey;
        rightSpriteImage.color = Color.white;
    }


}
