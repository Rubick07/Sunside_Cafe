using UnityEngine;

public class ScheduleGrid
{
    public ShiftInstance[,] grid = new ShiftInstance[5, 5];

    public int width;
    public int height;

    public ScheduleGrid(int shifts, int days)
    {
        grid = new ShiftInstance[shifts, days];

        width = shifts;
        height = days;

        for (int s = 0; s < shifts; s++)
            for (int d = 0; d < days; d++)
                grid[s, d] = new ShiftInstance { day = d, shift = s };
    }

    public ShiftInstance Get(int shifts, int days)
    {
        if (shifts >= grid.GetLength(0)) return null;
        return grid[shifts, days];
    }

    public void Remove(EmployeeData emp)
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                if (grid[x, y].assignedEmployee == emp)
                    grid[x, y] = null;
    }

    public bool CanPlace(EmployeeData emp, Vector2Int origin)
    {
        foreach (var cell in emp.scheduleShape.cells)
        {
            Vector2Int target = origin + cell;

            if (!IsInside(target))
                return false;

            if (!IsEmpty(target))
                return false;
        }
        return true;
    }

    public bool IsInside(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < width 
                &&
               pos.y >= 0 && pos.y < height;
    }

    public bool IsEmpty(Vector2Int pos)
    {
        return grid[pos.x, pos.y].assignedEmployee == null;
    }
}
