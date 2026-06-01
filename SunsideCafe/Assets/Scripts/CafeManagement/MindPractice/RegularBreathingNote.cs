using UnityEngine;

public class RegularBreathingNote : BreathingNote
{
    [SerializeField]
    private float hitWindow = 0.2f;

    protected override void HandleInput()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        float diff = GetAccuracy();

        if (diff <= hitWindow)
            Success();
        else
            Fail();
    }
}
