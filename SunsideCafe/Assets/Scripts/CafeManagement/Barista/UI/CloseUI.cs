using UnityEngine;
using DG.Tweening;

public class CloseUI : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        rectTransform.DOLocalMoveY(885, 0f);

        BaristaManager.instance.OnGameStateChanged += BaristaManager_OnGameStateChanged;
    }

    private void BaristaManager_OnGameStateChanged(object sender, BaristaManager.baristaGameState e)
    {
        if(e == BaristaManager.baristaGameState.Close)
        {
            rectTransform.DOLocalMoveY(0, 1f);
        }
    }
}
