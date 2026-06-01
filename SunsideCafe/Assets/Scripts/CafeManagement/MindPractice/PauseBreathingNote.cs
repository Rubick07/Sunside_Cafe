using UnityEngine;

public class PauseBreathingNote : BreathingNote
{
    protected override void HandleInput()
    {
        if (Input.anyKeyDown)
        {
            Fail();
        }
    }

    protected override void TimeOut()
    {
        Success();
    }
}
