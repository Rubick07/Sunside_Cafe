using UnityEngine;

public class DoubleBreathingNote : BreathingNote
{
    [SerializeField] private float hitWindow = 0.25f;

    private int tapCount;

    public override void Initialize()
    {
        base.Initialize();

        tapCount = 0;
    }

    protected override void HandleInput()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        tapCount++;

        if (tapCount >= 2)
        {
            float diff = GetAccuracy();

            if (diff <= hitWindow)
                Success();
            else
                Fail();
        }
    }
}
