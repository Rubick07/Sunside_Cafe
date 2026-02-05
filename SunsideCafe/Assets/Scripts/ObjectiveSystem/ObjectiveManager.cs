using UnityEngine;
using System.Collections.Generic;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;

    [SerializeField] private List<ObjectiveRuntime> activeObjectives = new();

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        GameEvents.OnStatChanged += HandleStatChanged;
    }

    void OnDisable()
    {
        GameEvents.OnStatChanged -= HandleStatChanged;
    }

    void HandleStatChanged(string statID, int amount)
    {
        foreach (var obj in activeObjectives)
        {
            foreach (var cond in obj.data.conditions)
            {
                if (cond.type.ToString() == statID)
                {

                    if (!obj.progress.ContainsKey(cond.type))
                        obj.progress[cond.type] = 0;

                    obj.progress[cond.type] += amount;

                    if (obj.IsCompleted())
                        CompleteObjective(obj);
                }
            }
        }
    }

    void CompleteObjective(ObjectiveRuntime obj)
    {
        GameEvents.OnObjectiveCompleted?.Invoke(obj.data.objectiveID);
        Debug.Log("Objective Completed: " + obj.data.title);
    }
}
