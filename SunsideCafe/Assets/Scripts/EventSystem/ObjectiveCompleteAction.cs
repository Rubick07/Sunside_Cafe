using UnityEngine;

public class ObjectiveCompleteAction : PlayerTriggerActionBase
{
    [SerializeField] private ObjectiveConditionType objectiveCondition;
    public override void ActionEvent()
    {
        if (hasTriggered)
            return;

        GameEvents.OnStatChanged.Invoke(objectiveCondition.ToString(), 1);
    }
}
