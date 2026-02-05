using System.Collections.Generic;
using UnityEngine;
using System;

public class ScheduleManager : MonoBehaviour
{
    public static ScheduleManager instance;

    public event EventHandler OnAssignedEmployeeChanged;

    [SerializeField] private int totalDays = 5;
    [SerializeField] private int shiftsPerDay = 5;

    public ScheduleGrid scheduleGrid;

    void Awake()
    {
        scheduleGrid = new ScheduleGrid(shiftsPerDay, totalDays);

        instance = this;
    }

    void OnEnable()
    {
        TimeManager.Instance.OnShiftChanged += HandleShiftChanged;
    }

    void HandleShiftChanged(int day, int shift)
    {
        var active = scheduleGrid.Get(shift, day);
        Debug.Log($"Shift Aktif: Day {day}, Shift {shift} - " +
            (active.assignedEmployee ? active.assignedEmployee.employeeName : "Kosong"));
    }

    public void AssignEmployee(int shifts, int days, EmployeeData employee)
    {
        Vector2Int origin = new Vector2Int(shifts,days);

        foreach (var cell in employee.scheduleShape.cells)
        {
            Vector2Int target = origin + cell;
            scheduleGrid.grid[target.x, target.y].assignedEmployee = employee;
        }

        OnAssignedEmployeeChanged?.Invoke(this, EventArgs.Empty);
    }
    public void Remove(EmployeeData emp)
    {
        scheduleGrid.Remove(emp);
    }

    public bool IsEmployeeCanPlace(EmployeeData employee, int day, int shift)
    {
        return scheduleGrid.CanPlace(employee, new Vector2Int(day, shift));
    }

    public int GetTotalDay() => totalDays;
    public int GetShiftsPerDay() => shiftsPerDay;


}
