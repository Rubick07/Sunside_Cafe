using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class ObjectiveManagerUI : MonoBehaviour
{
    public static ObjectiveManagerUI instance;

    [SerializeField] private TextMeshProUGUI objectiveNameText;

    private RectTransform rectTransform;

    private bool isActive;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        instance = this;
    }

    private void Start()
    {
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueStart.AddListener(Hide);
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.AddListener(Show);

        JournalUI.instance.OnJournalUIOpen += JournalUI_OnJournalUIOpen;
        JournalUI.instance.OnJournalUIClose += JournalClose_OnJournalUIClose;

        MarketUI.instance.OnShopUIOpen += MarketUI_OnShopUIOpen;
        MarketUI.instance.OnShopUIClose += Market_OnShopUIClose;

        ObjectiveManager.instance.OnObjectiveClear += ObjetiveManager_OnObjectiveClear;

        objectiveNameText.text = ObjectiveManager.instance.GetCurrentObjectiveTitle();

        Hide();
    }

    private void ObjetiveManager_OnObjectiveClear(object sender, ObjectiveRuntime e)
    {
        objectiveNameText.text = e.data.title;
    }

    private void Market_OnShopUIClose(object sender, EventArgs e)
    {
        ShowAnimation();
    }

    private void MarketUI_OnShopUIOpen(object sender, EventArgs e)
    {
        Hide();
    }

    private void JournalClose_OnJournalUIClose(object sender, EventArgs e)
    {
        ShowAnimation();
    }

    private void JournalUI_OnJournalUIOpen(object sender, EventArgs e)
    {
        Hide();
    }

    public void ShowAnimation()
    {
        if(isActive)
            return;

        rectTransform.DOMoveX(325, .5f).OnComplete(() =>
        {
            isActive = true;
        });
    }

    public void HideAnimation()
    {
        rectTransform.DOMoveX(-295f, .5f);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    [Yarn.Unity.YarnCommand("HideObjectiveUI")]
    public void Hide()
    {
        rectTransform.DOMoveX(-295f, 0f);

        isActive = false;
    }

    [Yarn.Unity.YarnCommand("ShowObjectiveUI")]
    public void ShowAnimationYarn()
    {
        ShowAnimation();
    }
}
