using UnityEngine;

[CreateAssetMenu(fileName = "ItemBase", menuName = "Scriptable Objects/ItemBase")]
public class ItemBase : ScriptableObject
{
    public enum ItemType
    {
        Consumable,
        Equipment
    }

    [SerializeField] protected int itemPrice;
    [SerializeField] protected ItemType itemType;
    [TextArea(5, 10)]
    [SerializeField] protected string itemDescription;
    [SerializeField] protected Sprite itemSprite;


    public int GetItemPrice()
    {
        return itemPrice;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public Sprite GetItemSprite()
    {
        return itemSprite;
    }
}
