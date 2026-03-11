using System;
using UnityEngine;

public class ObjectiveBuyListener : MonoBehaviour
{
    [SerializeField] private ItemBase itemBase;
    [SerializeField] private ObjectiveConditionType objectiveCondition;

    private void OnEnable()
    {
        InventoryManager.instance.OnInventoryChanged += InventoryManager_OnInventoryChanged;
    }

    private void OnDisable()
    {
        InventoryManager.instance.OnInventoryChanged -= InventoryManager_OnInventoryChanged;
    }

    private void InventoryManager_OnInventoryChanged(object sender, ItemBase e)
    {
        if(itemBase == e)
            GameEvents.OnStatChanged.Invoke(objectiveCondition.ToString(), 1);

    }
}
