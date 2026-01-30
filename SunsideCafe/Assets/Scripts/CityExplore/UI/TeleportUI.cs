using System;
using UnityEngine;
using DG.Tweening;

public class TeleportUI : MonoBehaviour
{
    public static TeleportUI instance;

    public static event EventHandler OnAnyTeleportStart;
    public static event EventHandler OnAnyTeleportEnd;


    [SerializeField] private RectTransform blackScreenTransform;

    private void Awake()
    {
        instance = this;

        blackScreenTransform.DOAnchorPosY(0, 0f);
        blackScreenTransform.gameObject.SetActive(false);
    }

    public void TriggerAnimation(Action action)
    {
        OnAnyTeleportStart?.Invoke(this, EventArgs.Empty);

        blackScreenTransform.gameObject.SetActive(true);
        AnimationLeftToRight(action);

    }

    private void AnimationLeftToRight(Action action)
    {
        blackScreenTransform.DOAnchorPosX(-1938, 0f);


        blackScreenTransform.DOAnchorPosX(0, 1f).OnComplete(() =>
        {

            action();
            OnAnyTeleportEnd?.Invoke(this, EventArgs.Empty);

            blackScreenTransform.DOAnchorPosX(1948, 1f).OnComplete(()=> {
                blackScreenTransform.DOAnchorPosY(0, 0f);
                blackScreenTransform.gameObject.SetActive(false);
            });
        });
    }

    private void AnimationDown(Action action)
    {
        blackScreenTransform.DOAnchorPosY(1085, 0f);


        blackScreenTransform.DOAnchorPosY(0, 1f).OnComplete(() =>
        {

            action();
            blackScreenTransform.DOAnchorPosY(-1128, 1f).OnComplete(() => {
                blackScreenTransform.DOAnchorPosY(0, 0f);
                blackScreenTransform.gameObject.SetActive(false);

            });
        });
    }
}
