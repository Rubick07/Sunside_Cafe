using UnityEngine;

public class ScheduleShapeRuntime
{
    public enum State 
    {
        Normal,
        Left,
        Right
    }

    public Vector2Int[] cells;
    public State state = State.Normal;

    public ScheduleShapeRuntime(Vector2Int[] source)
    {
        cells = new Vector2Int[source.Length];
        source.CopyTo(cells, 0);
    }

    public void RotateLeftShape()
    {
        if (state == State.Left)
            return;

        if (state == State.Normal)
            state = State.Left;

        if (state == State.Right)
            state = State.Normal;

        int index = 0;

        foreach(Vector2Int i in cells)
        {
            cells[index] = i.RotateLeft();
            index++;
        }
    }

    public void RotateRightShape()
    {
        if (state == State.Right)
            return;

        if (state == State.Normal)
            state = State.Right;

        if (state == State.Left)
            state = State.Normal;

        int index = 0;
        foreach (Vector2Int i in cells)
        {
            cells[index] = i.RotateRight();
            index++;
        }
    }


}