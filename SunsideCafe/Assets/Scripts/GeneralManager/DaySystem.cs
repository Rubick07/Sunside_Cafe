using UnityEngine;
using System;

public class DaySystem : MonoBehaviour
{
    public static DaySystem instance;

    public event EventHandler<int> OnDayChanged;

    public enum DayState
    {
        DAY,
        NIGHT
    }

    [SerializeField] private DayState dayState;
    [SerializeField] private int currentDay;

    private void Awake()
    {
        instance = this;
    }
    
    public void ChangeDayState(DayState dayState)
    {
        this.dayState = dayState;
    }

    public DayState GetDayState()
    {
        return dayState;
    }

    public bool IsDay()
    {
        return dayState == DayState.DAY;
    }
    public bool IsNight()
    {
        return dayState == DayState.NIGHT;
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

    [Yarn.Unity.YarnCommand("ChangeDay")]
    public void ChangeDayYarn(int mod)
    {
        ChangeDay(mod);
    }

    [Yarn.Unity.YarnCommand("SetDay")]
    public void SetDay()
    {
        ChangeDayState(DayState.DAY);
    }

    [Yarn.Unity.YarnCommand("SetNight")]
    public void SetNight()
    {
        ChangeDayState(DayState.NIGHT);
    }

}
