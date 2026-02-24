using System;
using UnityEngine;
using UnityEngine.UI;

public class ExploreUI : MonoBehaviour
{
    public static ExploreUI instance;

    [SerializeField] private Button journalButton;

    private void Awake()
    {
        instance = this;

        journalButton.onClick.AddListener(()=>
        {
            JournalUI.instance.Show();
        });

    }
    private void Start()
    {
        JournalUI.instance.OnJournalUIOpen += JournalUI_OnJournalUIOpen;
        JournalUI.instance.OnJournalUIClose += JournalClose_OnJournalUIClose;

        MarketUI.instance.OnShopUIOpen += MarketUI_OnShopUIOpen;
        MarketUI.instance.OnShopUIClose += Market_OnShopUIClose;
        
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
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
