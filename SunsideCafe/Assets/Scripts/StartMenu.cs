using UnityEngine;
using TMPro;
using DG.Tweening;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI blinkText;

    private void Start()
    {
        blinkText.DOFade(0f, 0.8f).SetLoops(-1, LoopType.Yoyo);

        GameEvents.OnPlayMusic.Invoke("MainMenuBGM");
    }
}
