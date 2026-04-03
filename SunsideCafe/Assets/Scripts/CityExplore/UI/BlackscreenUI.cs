using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class BlackscreenUI : MonoBehaviour
{
    public static BlackscreenUI instance;

    public static event EventHandler OnBlackScreenFadeIn;
    public static event EventHandler OnBlackScreenFadeOut;


    [SerializeField] private Image blackscreenImage;


    private void Awake()
    {
        instance = this;

        SetTransparent();
    }

    public void FadeIn(Action fadeInAction, float timeToFadeIn)
    {
        SetTransparent();
        OnBlackScreenFadeIn?.Invoke(this, EventArgs.Empty);


        blackscreenImage.DOFade(1, timeToFadeIn).OnComplete(() =>
        {
            fadeInAction();

            FadeOut();
        });
    }

    public void FadeIn(Action fadeInAction, float timeToFadeIn, Action fadeOutAction)
    {
        SetTransparent();
        OnBlackScreenFadeIn?.Invoke(this, EventArgs.Empty);


        blackscreenImage.DOFade(1, timeToFadeIn).OnComplete(() =>
        {
            fadeInAction();

            blackscreenImage.DOFade(0, timeToFadeIn).OnComplete(() =>
            {

                FadeOut(fadeOutAction);
            });
        });
    }

    private void SetTransparent()
    {
        Color color = blackscreenImage.color;
        color.a = 0;
        blackscreenImage.color = color;
    }

    public void FadeOut()
    {
        OnBlackScreenFadeOut?.Invoke(this, EventArgs.Empty);

        blackscreenImage.DOFade(0, 1f);
    }

    public void FadeOut(Action fadeOutAction)
    {
        OnBlackScreenFadeOut?.Invoke(this, EventArgs.Empty);

        blackscreenImage.DOFade(0, 0f).OnComplete(() => {
            fadeOutAction();

        });
    }

    [Yarn.Unity.YarnCommand("BlackscreenFadeIn")]
    public void BlackscreenFadeIn()
    {
        SetTransparent();
        blackscreenImage.DOFade(1, .5f);
    }
    [Yarn.Unity.YarnCommand("BlackscreenFadeOut")]
    public void BlackscreenFadeOut()
    {
        blackscreenImage.DOFade(0, .5f);
    }
}
