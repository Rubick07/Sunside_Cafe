using System;
using UnityEngine;
using UnityEngine.UI;

public class ExploreUI : MonoBehaviour
{
    public static ExploreUI instance;

    [SerializeField] private Button journalButton;

    private CanvasGroup canvasGroup;

    private float f_countdownTimeToShow = 3f;
    private bool isCountdown;

    private void Awake()
    {
        instance = this;

        canvasGroup = GetComponent<CanvasGroup>();

        journalButton.onClick.AddListener(()=>
        {
            JournalUI.instance.Show();
        });

    }
    private void Start()
    {
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueStart.AddListener(Hide);
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.AddListener(Show);

        JournalUI.instance.OnJournalUIOpen += JournalUI_OnJournalUIOpen;
        JournalUI.instance.OnJournalUIClose += JournalClose_OnJournalUIClose;

        MarketUI.instance.OnShopUIOpen += MarketUI_OnShopUIOpen;
        MarketUI.instance.OnShopUIClose += Market_OnShopUIClose;

        TimelineDayDreamController.OnAnyTimelineStart += TimelineDayDreamController_OnAnyTimelineStart;

        Hide();
    }

    private void Update()
    {
        if (!isCountdown)
            return;

        f_countdownTimeToShow -= Time.deltaTime;

        if(f_countdownTimeToShow <= 0f)
        {
            Show();
            isCountdown = false;
        }

    }

    private void TimelineDayDreamController_OnAnyTimelineStart(object sender, EventArgs e)
    {
        Hide();
    }

    private void Market_OnShopUIClose(object sender, EventArgs e)
    {
        Show();
    }

    private void MarketUI_OnShopUIOpen(object sender, EventArgs e)
    {
        Hide();
    }

    private void JournalClose_OnJournalUIClose(object sender, EventArgs e)
    {
        journalButton.gameObject.SetActive(true);
        Hide();
    }

    private void JournalUI_OnJournalUIOpen(object sender, EventArgs e)
    {
        journalButton.gameObject.SetActive(false);
        Show();
    }

    public void Show()
    {
        if (MarketUI.instance.IsActive())
            return;

        canvasGroup.alpha = 1f;
        //gameObject.SetActive(true);
    }

    public void Hide()
    {
        isCountdown = false;
        canvasGroup.alpha = 0f;
        //gameObject.SetActive(false);
    }

    public void StartCountdown()
    {
        f_countdownTimeToShow = 3f;
        isCountdown = true;
    }


    private void OnDestroy()
    {
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueStart.RemoveListener(Hide);
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.RemoveListener(Show);

        JournalUI.instance.OnJournalUIOpen -= JournalUI_OnJournalUIOpen;
        JournalUI.instance.OnJournalUIClose -= JournalClose_OnJournalUIClose;

        MarketUI.instance.OnShopUIOpen -= MarketUI_OnShopUIOpen;
        MarketUI.instance.OnShopUIClose -= Market_OnShopUIClose;
    }

}
