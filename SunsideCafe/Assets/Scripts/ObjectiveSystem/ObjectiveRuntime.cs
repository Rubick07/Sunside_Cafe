using System.Collections.Generic;

[System.Serializable]
public class ObjectiveRuntime
{
    public ObjectiveData data;
    public Dictionary<ObjectiveConditionType, int> progress = new();

    public bool IsCompleted()
    {
        foreach (var c in data.conditions)
        {
            if (!progress.ContainsKey(c.type)) return false;
            if (progress[c.type] < c.targetValue) return false;
        }
        return true;
    }
}