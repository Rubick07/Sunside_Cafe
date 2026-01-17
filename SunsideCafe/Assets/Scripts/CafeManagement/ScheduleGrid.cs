using UnityEngine;

public class ScheduleGrid
{
    public ShiftInstance[,] grid = new ShiftInstance[5, 5];

    public ScheduleGrid(int days, int shifts)
    {
        grid = new ShiftInstance[days, shifts];

        for (int d = 0; d < days; d++)
            for (int s = 0; s < shifts; s++)
                grid[d, s] = new ShiftInstance { day = d, shift = s };
    }

    public ShiftInstance Get(int day, int shift)
    {
        if (day >= grid.GetLength(0)) return null;
        return grid[day, shift];
    }
}
