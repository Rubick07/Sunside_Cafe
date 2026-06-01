using UnityEngine;

public class DeepBreathingNote : BreathingNote
{
    [SerializeField] private float requiredHoldTime = 1.5f;

    private float holdTimer;

    public override void Initialize()
    {
        base.Initialize();

        holdTimer = 0;
    }

    protected override void HandleInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            holdTimer += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (holdTimer >= requiredHoldTime)
                Success();
            else
                Fail();
        }
    }
}
