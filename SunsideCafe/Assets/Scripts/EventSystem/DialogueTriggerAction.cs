using UnityEngine;

public class DialogueTriggerAction : PlayerTriggerActionBase
{
    [SerializeField] private string dialogTitle;
    public override void ActionEvent()
    {
        if (!isRepeatable && hasTriggered == true)
            return;

        DialogRunnerSingleton.instance.StartDialog(dialogTitle);
        hasTriggered = true;
    }
}
