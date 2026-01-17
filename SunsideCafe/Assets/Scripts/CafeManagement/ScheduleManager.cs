using System.Collections.Generic;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    public static ScheduleManager instance;

    [SerializeField] private int totalDays = 5;
    [SerializeField] private int shiftsPerDay = 5;

    public ScheduleGrid scheduleGrid;

    void Awake()
    {
        scheduleGrid = new ScheduleGrid(totalDays, shiftsPerDay);

        instance = this;
    }

    void OnEnable()
    {
        TimeManager.Instance.OnShiftChanged += HandleShiftChanged;
    }

    void HandleShiftChanged(int day, int shift)
    {
        var active = scheduleGrid.Get(day, shift);
        Debug.Log($"Shift Aktif: Day {day}, Shift {shift} - " +
            (active.assignedEmployee ? active.assignedEmployee.employeeName : "Kosong"));
    }

    public void AssignEmployee(int day, int shift, EmployeeData employee)
    {
        scheduleGrid.grid[day, shift].assignedEmployee = employee;
    }

    public bool IsEmployeeWorking(EmployeeData employee, int day, int shift)
    {
        for (int s = 0; s < shiftsPerDay; s++)
        {
            if (scheduleGrid.grid[day, s].assignedEmployee == employee)
                return true;
        }
        return false;
    }

}
