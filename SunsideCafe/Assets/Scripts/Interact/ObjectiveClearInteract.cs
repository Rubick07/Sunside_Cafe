using UnityEngine;

public class ObjectiveClearInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private ObjectiveConditionType conditionType;

    private bool hasTriggered = false;

    public void Interact()
    {
        if (hasTriggered)
            return;

        GameEvents.OnStatChanged.Invoke(conditionType.ToString(), 1);
        hasTriggered = true;
    }

}
