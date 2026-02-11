using System.Collections.Generic;
using UnityEngine;

public class CafeBuffSystem : MonoBehaviour
{
    public float incomeMultiplier = 1f;
    public float productivity = 1f;

    public void ApplyTraits(List<TraitData> traits)
    {
        ResetBuffs();

        foreach (var trait in traits)
        {
            switch (trait.buffType)
            {
                case BuffType.IncomeMultiplier:
                    incomeMultiplier += trait.value;
                    break;
                case BuffType.Productivity:
                    productivity += trait.value;
                    break;
            }
        }
    }

    void ResetBuffs()
    {
        incomeMultiplier = 1f;
        productivity = 1f;
    }
}
