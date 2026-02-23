using UnityEngine;

[CreateAssetMenu(fileName = "ItemBase", menuName = "Scriptable Objects/ItemBase")]
public class ItemBase : ScriptableObject
{
    public enum ItemType
    {
        KeyItems,
        Ingredients,
        Equipments
    }

    [SerializeField] protected int itemPrice;
    [SerializeField] protected ItemType itemType;
    [TextArea(5, 10)]
    [SerializeField] protected string itemDescription;
    [SerializeField] protected Sprite itemSprite;


    public int GetItemPrice() => itemPrice;


    public string GetItemDesc() => itemDescription;

    public ItemType GetItemType() => itemType;
    

    public Sprite GetItemSprite() => itemSprite;
    
}
