using System;
using UnityEngine;

public abstract class BreathingNote : MonoBehaviour
{
    [Header("Ring")]
    [SerializeField] protected RectTransform ring;

    [SerializeField] protected float startScale = 2f;
    [SerializeField] protected float targetScale = 1f;
    [SerializeField] protected float duration = 2f;

    protected float timer;

    public bool IsFinished { get; protected set; }

    public Action<BreathingNote> OnSuccess;
    public Action<BreathingNote> OnFail;

    public virtual void Initialize()
    {
        timer = 0;
        IsFinished = false;

        ring.localScale = Vector3.one * startScale;
    }

    protected virtual void Update()
    {
        if (IsFinished)
            return;

        timer += Time.deltaTime;

        UpdateRing();

        HandleInput();

        if (timer >= duration)
        {
            TimeOut();
        }
    }

    void UpdateRing()
    {
        float t = timer / duration;

        float scale =
            Mathf.Lerp(startScale, targetScale, t);

        ring.localScale = Vector3.one * scale;
    }

    protected void Success()
    {
        if (IsFinished)
            return;

        IsFinished = true;
        OnSuccess?.Invoke(this);
    }

    protected void Fail()
    {
        if (IsFinished)
            return;

        IsFinished = true;
        OnFail?.Invoke(this);
    }

    protected abstract void HandleInput();

    protected virtual void TimeOut()
    {
        Fail();
    }

    protected float GetAccuracy()
    {
        return Mathf.Abs(timer - duration);
    }

}
