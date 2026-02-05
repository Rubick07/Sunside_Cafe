using UnityEngine;
using System;

public class DaySystem : MonoBehaviour
{
    public static DaySystem instance;

    public event EventHandler OnDayChanged;

    [SerializeField] private int currentDay;

    public void ChangeDay(int mod)
    {
        currentDay += mod;

        OnDayChanged?.Invoke(this, EventArgs.Empty);
    }

}
