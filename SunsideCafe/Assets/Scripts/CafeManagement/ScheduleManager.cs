using System.Collections.Generic;
using UnityEngine;
using System;

public class ScheduleManager : MonoBehaviour
{
    public static ScheduleManager instance;

    public event EventHandler<EmployeeData> OnAssignedEmployeeChanged;

    [SerializeField] private int totalDays = 5;
    [SerializeField] private int shiftsPerDay = 5;

    [SerializeField] private Vector2Int[] blockerArray;

    public ScheduleGrid scheduleGrid;

    void Awake()
    {
        scheduleGrid = new ScheduleGrid(shiftsPerDay, totalDays);

        foreach(Vector2Int i in blockerArray)
        {
            scheduleGrid.Get(i.x, i.y).state = ShiftInstance.State.Blocked;
        }

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

    public EmployeeData GetEmployeeFromGrid(int shift, int day)
    {
        return scheduleGrid.Get(shift, day).assignedEmployee;
    }

    public void AssignEmployee(int shifts, int days, EmployeeData employee)
    {
        Vector2Int origin = new Vector2Int(shifts,days);

        EmployeeCardUI employeeCardUI = EmployeeListUI.instance.GetEmployeeCardUI(employee);

        foreach (var cell in employeeCardUI.GetScheduleShapeRuntime().cells)
        {
            Vector2Int target = origin + cell;
            scheduleGrid.grid[target.x, target.y].assignedEmployee = employee;
        }

        OnAssignedEmployeeChanged?.Invoke(this, employee);
    }
    public void Remove(EmployeeData emp)
    {
        scheduleGrid.Remove(emp);

        OnAssignedEmployeeChanged?.Invoke(this, emp);
    }

    public bool IsEmployeeCanPlace(EmployeeData employee, int day, int shift)
    {
        return scheduleGrid.CanPlace(employee, new Vector2Int(day, shift));
    }

    public int GetTotalDay() => totalDays;
    public int GetShiftsPerDay() => shiftsPerDay;


}
