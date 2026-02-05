using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/Objective")]
public class ObjectiveData : ScriptableObject
{
    public string objectiveID;
    public string title;
    [TextArea] public string description;

    public List<ObjectiveCondition> conditions;
    public string onCompletedEventID;
}