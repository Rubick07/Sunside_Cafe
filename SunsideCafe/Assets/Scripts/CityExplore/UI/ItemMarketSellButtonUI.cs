using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMarketSellButtonUI : MonoBehaviour, IBindData<ItemBase>
{
    [SerializeField] private TextMeshProUGUI itemNameTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemAmountsTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemSellCostTextMeshPro;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private ItemBase itemBase;

    private void Start()
    {
        InventoryManager.instance.OnInventoryChanged += InventoryManager_OnInventoryChanged;
    }
    
    public void Bind(ItemBase data)
    {
        this.itemBase = data;
        itemImage.sprite = itemBase.GetItemSprite();
        itemNameTextMeshPro.text = data.name.ToUpper();
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(data).ToString();

        int ItemSellCost = data.GetItemPrice() / 2;
        itemSellCostTextMeshPro.text = "RP" + ItemSellCost.ToString("N0");

        button.onClick.AddListener(() =>
        {
            MarketUI.instance.GetMarket().SellItem(data);
        });
    }

    public Button GetButton()
    {
        return button;
    }
    private void InventoryManager_OnInventoryChanged(object sender, System.EventArgs e)
    {
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(itemBase).ToString();
    }

    private void OnDestroy()
    {
        InventoryManager.instance.OnInventoryChanged -= InventoryManager_OnInventoryChanged;
    }


}
