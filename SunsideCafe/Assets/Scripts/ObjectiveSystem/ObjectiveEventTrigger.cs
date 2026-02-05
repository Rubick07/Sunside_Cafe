using UnityEngine;

public class ObjectiveEventTrigger : MonoBehaviour
{
    [SerializeField] private string statID;
    [SerializeField] private int amount = 1;

    public void Trigger()
    {
        GameEvents.OnStatChanged?.Invoke(statID, amount);
    }
}
