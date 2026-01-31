using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMarketBuyButtonUI : MonoBehaviour, IBindData<ItemBase>
{
    [SerializeField] private TextMeshProUGUI itemNameTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemAmountsTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemCostTextMeshPro;
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
        itemCostTextMeshPro.text = "RP" + itemBase.GetItemPrice().ToString("N0");

        button.onClick.AddListener(() =>
        {
            MarketUI.instance.GetMarket().BuyItem(data);
        });
    }

    private void InventoryManager_OnInventoryChanged(object sender, System.EventArgs e)
    {
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(itemBase).ToString();
    }

    private void OnDestroy()
    {
        if (!itemBase)
            return;

        InventoryManager.instance.OnInventoryChanged -= InventoryManager_OnInventoryChanged;
    }

}
