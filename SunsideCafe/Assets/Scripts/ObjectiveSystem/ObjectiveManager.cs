using UnityEngine;
using System.Collections.Generic;
using System;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager instance;

    public event EventHandler<ObjectiveRuntime> OnObjectiveClear;


    [SerializeField] private List<ObjectiveRuntime> activeObjectives = new();


    [SerializeField] int currentObjective;

    void Awake()
    {
        instance = this;
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
        foreach(var cond in activeObjectives[currentObjective].data.conditions)
        {
            if (cond.type.ToString() == statID)
            {

                if (!activeObjectives[currentObjective].progress.ContainsKey(cond.type))
                    activeObjectives[currentObjective].progress[cond.type] = 0;

                activeObjectives[currentObjective].progress[cond.type] += amount;

                if (activeObjectives[currentObjective].IsCompleted())
                {
                    CompleteObjective(activeObjectives[currentObjective]);
                    currentObjective++;

                    OnObjectiveClear?.Invoke(this, activeObjectives[currentObjective]);
                }
            }

        }

/*        foreach (var obj in activeObjectives)
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
        }*/
    }

    void CompleteObjective(ObjectiveRuntime obj)
    {
        GameEvents.OnObjectiveCompleted?.Invoke(obj.data.objectiveID);
        Debug.Log("Objective Completed: " + obj.data.title);
    }

    public string GetCurrentObjectiveTitle()
    {
        return activeObjectives[currentObjective].data.title;
    }

    public ObjectiveData GetCurrentObjectiveData()
    {
        return activeObjectives[currentObjective].data;
    }

}
