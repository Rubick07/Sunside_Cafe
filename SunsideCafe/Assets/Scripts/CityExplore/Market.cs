using UnityEngine;
using System;

public class Market : MonoBehaviour, IInteractable
{
    public static event EventHandler<ItemBase> OnAnySelectedItemBaseChanged;

    [SerializeField] private MarketItemSO marketItemSO;
    [SerializeField] private ShopNPC shopNPC;

    private ItemBase selectedItembase;

    public void Interact()
    {
        MarketUI.instance.SetMarket(this);
    }

    public void BuySelectedItem()
    {
        if (EconomyManager.instance.UseMoney(selectedItembase.GetItemPrice()))
        {
            InventoryManager.instance.AddItem(selectedItembase);
        }
        else
        {

        }
    }

    public void SellItem(ItemBase itemBase)
    {
        if (InventoryManager.instance.GetItemAmounts(itemBase) != 0)
        {
            InventoryManager.instance.RemoveItem(itemBase, 1);
            EconomyManager.instance.AddMoney(itemBase.GetItemPrice() / 2);
        }
        else
        {
            Debug.Log("ITEM TIDAK CUKUP UNTUK DIJUAL");
        }
    }

    public void SelectItem(ItemBase itemBase)
    {
        selectedItembase = itemBase;

        OnAnySelectedItemBaseChanged?.Invoke(this, itemBase);
    }

    public ItemBase[] GetItemToSellInMarket()
    {
        return marketItemSO.ItemToSellInMarket;
    }

    public NPCBase GetShopNPC()
    {
        return shopNPC;
    }

    public string GetNPCShopText() => shopNPC.GetShopText();

}
