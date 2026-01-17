using UnityEngine;
public enum BuffType
{
    IncomeMultiplier,
    Productivity,
    CustomerPatience,
    ServiceSpeed
}

[CreateAssetMenu(menuName = "Cafe/Trait")]
public class TraitData : ScriptableObject
{
    public string traitName;
    public BuffType buffType;
    public float value;
    public bool onlyActiveDuringShift = true;
}