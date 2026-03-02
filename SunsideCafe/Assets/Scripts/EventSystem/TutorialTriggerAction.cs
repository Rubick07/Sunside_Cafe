using UnityEngine;

public class TutorialTriggerAction : PlayerTriggerActionBase
{
    [SerializeField] private TutorialTriggerType triggerType;
    public override void ActionEvent()
    {
        TutorialManager.instance.TriggerTutorial(triggerType);
    }
}
