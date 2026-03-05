using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CafeBackgroundUI : MonoBehaviour
{
    [SerializeField] private Image cafeBackgroundImage;

    private void Start()
    {
        SetTransparent();
    }

    private void FadeIn(float time)
    {
        SetTransparent();
        cafeBackgroundImage.DOFade(1f, time);
    }

    private void FadeOut()
    {
        cafeBackgroundImage.DOFade(0f, .5f);
    }

    private void SetTransparent()
    {
        Color color = cafeBackgroundImage.color;
        color.a = 0;
        cafeBackgroundImage.color = color;
    }

    [Yarn.Unity.YarnCommand("CafeBackgroundFadeIn")]
    public void CafeFadeIn(float time)
    {
        FadeIn(time);
    }
    [Yarn.Unity.YarnCommand("CafeBackgroundFadeOut")]
    public void CafeFadeOut()
    {
        FadeOut();
    }

}
