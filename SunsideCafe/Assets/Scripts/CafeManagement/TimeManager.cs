using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [Header("Time Config")]
    [SerializeField] private float shiftDuration = 120f; // 2 menit per shift
    [SerializeField] private int shiftsPerDay = 5;

    [Header("Current Time")]
    [SerializeField] private int currentDay = 0;
    [SerializeField] private int currentShift = 0;

    float shiftTimer;

    public event Action<int, int> OnShiftChanged;
    public event Action<int> OnDayChanged;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        shiftTimer += Time.deltaTime;

        if (shiftTimer >= shiftDuration)
        {
            NextShift();
        }
    }

    void NextShift()
    {
        shiftTimer = 0;
        currentShift++;

        if (currentShift >= shiftsPerDay)
        {
            currentShift = 0;
            currentDay++;
            OnDayChanged?.Invoke(currentDay);
        }

        OnShiftChanged?.Invoke(currentDay, currentShift);
    }
}