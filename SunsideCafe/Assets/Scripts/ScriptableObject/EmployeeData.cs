using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cafe/Employee")]
public class EmployeeData : ScriptableObject
{
    public string employeeName;
    public Sprite portrait;
    public List<TraitData> traits;
}