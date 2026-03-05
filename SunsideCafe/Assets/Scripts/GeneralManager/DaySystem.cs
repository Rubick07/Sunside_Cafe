using UnityEngine;
using System;

public class DaySystem : MonoBehaviour
{
    public static DaySystem instance;

    public event EventHandler<int> OnDayChanged;

    [SerializeField] private int currentDay;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeDay(int mod)
    {
        currentDay += mod;

        OnDayChanged?.Invoke(this, currentDay);
    }

    public int GetCurrentDay() => currentDay;

    [Yarn.Unity.YarnCommand("NextDay")]
    public void NextDay()
    {
        ChangeDay(1);
    }
}
