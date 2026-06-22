using UnityEngine;
using DG.Tweening;

public class CloseUI : MonoBehaviour
{
    private RectTransform rectTransform;

    private bool clear = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        rectTransform.DOLocalMoveY(885, 0f);

        BaristaManager.instance.OnGameStateChanged += BaristaManager_OnGameStateChanged;
    }

    private void Update()
    {
        if (Input.anyKeyDown && clear == true)
        {
            GameManager.instance.RemoveScene();
        }
    }

    private void BaristaManager_OnGameStateChanged(object sender, BaristaManager.baristaGameState e)
    {
        if(e == BaristaManager.baristaGameState.Close)
        {
            rectTransform.DOLocalMoveY(0, 1f).OnComplete(()=> 
            {
                clear = true;
            });
        }
    }

    private void OnDestroy()
    {
        BaristaManager.instance.OnGameStateChanged -= BaristaManager_OnGameStateChanged;
    }
}
