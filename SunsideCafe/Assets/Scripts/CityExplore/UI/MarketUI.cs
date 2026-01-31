using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MarketUI : MonoBehaviour
{
    public enum State
    {
        MainMenu,
        BuyMenu,
        SellMenu,
        EquipmentMenu,
        QuantityMenu
    }

    public event EventHandler OnShopUIOpen;
    public event EventHandler OnShopUIClose;
    public event EventHandler<State> OnStateChanged;
    public static MarketUI instance;

    [SerializeField] private State state;
    [Header("SHOP TEXT REFERENCE")]
    [SerializeField] private TextMeshProUGUI shopNameTextMeshPro;
    [SerializeField] private TextMeshProUGUI moneyTextMeshPro;
    [Header("SHOP BUTTON REFERENCE")]
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private Button chatButton;
    [SerializeField] private Button exitButton;

    [Header("Market Item REFERENCE")]
    [SerializeField] private ItemMarketBuyButtonUI itemButtonBuyPrefab;
    [SerializeField] private ItemMarketSellButtonUI itemButtonSellPrefab;
    [SerializeField] private Transform itemButtonContainerTransform;

    private List<ItemMarketBuyButtonUI> itemButtonBuyList = new List<ItemMarketBuyButtonUI>();
    private List<ItemMarketSellButtonUI> itemButtonSellList = new List<ItemMarketSellButtonUI>();

    private Market currentMarket;

    private bool isOpenMarket;

    private void Awake()
    {
        instance = this;

        buyButton.onClick.AddListener(CreateItemButtonBuy);
        sellButton.onClick.AddListener(CreateItemButtonSell);
        chatButton.onClick.AddListener(()=> 
        {
            currentMarket.GetShopNPC().TriggerDialog();
        });

        exitButton.onClick.AddListener(() => Hide());
    }

    private void Start()
    {
        EconomyManager.instance.OnMoneyChanged += EconomyManager_OnMoneyChanged;

        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueStart.AddListener(()=> 
        {
            gameObject.SetActive(false);
        });

        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.AddListener(() =>
        {
            if (isOpenMarket)
                gameObject.SetActive(true);

        });

        UpdateVisualMoneyText(EconomyManager.instance.GetMoney());

        RemoveButtonList();
        Hide();

    }

    private void EconomyManager_OnMoneyChanged(object sender, int e)
    {
        UpdateVisualMoneyText(e);
    }

    public void UpdateVisualMoneyText(int e)
    {
        moneyTextMeshPro.text = "RP" + e.ToString("N0");
    }

    private void CreateItemButtonBuy()
    {
        RemoveButtonList();

        foreach (ItemBase itembase in currentMarket.GetItemToSellInMarket())
        {
            ItemMarketBuyButtonUI ui = Helpers.CreateUI<ItemMarketBuyButtonUI, ItemBase>(itemButtonBuyPrefab, itemButtonContainerTransform, itembase);

            itemButtonBuyList.Add(ui);
        }

        SetMarketUIState(State.BuyMenu);
    }

    private void CreateItemButtonSell()
    {
        RemoveButtonList();

        foreach (ItemBase itembase in InventoryManager.instance.GetInventoryDictionary().Keys)
        {
            ItemMarketSellButtonUI ui = Helpers.CreateUI<ItemMarketSellButtonUI, ItemBase>(itemButtonSellPrefab, itemButtonContainerTransform, itembase);

            itemButtonSellList.Add(ui);

        }

        SetMarketUIState(State.SellMenu);
    }

    private void RemoveButtonList()
    {
        itemButtonContainerTransform.RemoveAllChild();

        itemButtonBuyList.Clear();
        itemButtonSellList.Clear();
    }

    public void SetMarketUIState(State state)
    {
        this.state = state;
        OnStateChanged?.Invoke(this, state);
    }

    public void Show()
    {
        isOpenMarket = true;

        gameObject.SetActive(true);

        OnShopUIOpen?.Invoke(this, EventArgs.Empty);
    }

    public void Hide()
    {
        isOpenMarket = false;

        OnShopUIClose?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(false);
    }

    public void SetMarket(Market market)
    {
        currentMarket = market;
        RemoveButtonList();
        Show();
    }

    public Market GetMarket()
    {
        return currentMarket;
    }
}
