using UnityEngine;

public class ImportantNPC : NPCBase
{
    [SerializeField] private string dialogName;

    public string GetDialogName()
    {
        return dialogName;
    }

    public override void Interact()
    {
        DialogRunnerSingleton.instance.StartDialog(dialogName, data.npcSprite);
    }

    public override void TriggerDialog()
    {
        DialogRunnerSingleton.instance.StartDialog(dialogName, data.npcSprite);
    }
}
