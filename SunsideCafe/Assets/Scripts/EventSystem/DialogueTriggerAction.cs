using UnityEngine;

public class DialogueTriggerAction : PlayerTriggerActionBase
{
    [SerializeField] private string dialogTitle;
    public override void ActionEvent()
    {
        if (hasTriggered == true)
            return;

        DialogRunnerSingleton.instance.StartDialog(dialogTitle);
    }
}
