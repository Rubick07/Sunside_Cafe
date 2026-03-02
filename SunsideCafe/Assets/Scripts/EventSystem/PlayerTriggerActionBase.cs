using UnityEngine;

public abstract class PlayerTriggerActionBase : MonoBehaviour
{
    [SerializeField] protected bool isRepeatable;
    [SerializeField] protected bool AddOnTriggerEnter;
    [SerializeField] protected bool AddOnTriggerExit;

    protected bool hasTriggered = false;

    public bool GetisRepeatable()
    {
        return isRepeatable;
    }

    public bool GetAddOnTriggerEnter()
    {
        return AddOnTriggerEnter;
    }

    public bool GetAddOnTriggerExit()
    {
        return AddOnTriggerExit;
    }

    public abstract void ActionEvent();
}
