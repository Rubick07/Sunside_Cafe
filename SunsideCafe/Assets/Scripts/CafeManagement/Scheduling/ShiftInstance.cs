using UnityEngine;

[System.Serializable]
public class ShiftInstance
{
    public enum State
    {
        Empty,
        Occupied,
        Blocked
    }

    public int day;
    public int shift;
    public EmployeeData assignedEmployee;
    public State state;
}
