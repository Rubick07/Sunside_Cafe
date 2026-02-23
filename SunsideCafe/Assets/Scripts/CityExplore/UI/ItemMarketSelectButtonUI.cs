using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMarketSelectButtonUI : MonoBehaviour, IBindData<ItemBase>
{
    [SerializeField] private TextMeshProUGUI itemCostTextMeshPro;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private ItemBase itemBase;

    public void Bind(ItemBase data)
    {
        this.itemBase = data;
        itemImage.sprite = itemBase.GetItemSprite();
        itemCostTextMeshPro.text = "RP" + itemBase.GetItemPrice().ToString("N0");

        button.onClick.AddListener(() =>
        {
            MarketUI.instance.GetMarket().SelectItem(data);
        });
    }

}
