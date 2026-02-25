using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryManagerUI : MonoBehaviour
{
    public static InventoryManagerUI instance;

    [Header("INVENTORY REFENRECE")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemDescText;

    [Header("BUTTON INVENTORY REFERENCE")]
    [SerializeField] private ItemSelectInventoryButton inventoryButtonPrefab;
    [SerializeField] private Transform buttonContainerTransform;

    private List<ItemSelectInventoryButton> itemSelectInventoryButtonList = new List<ItemSelectInventoryButton>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        JournalUI.instance.OnJournalUIOpen += JournalUI_OnJournalUIOpen;

        Remove();
        CreateButton();
        Refresh();
    }

    private void JournalUI_OnJournalUIOpen(object sender, System.EventArgs e)
    {
        Refresh();
    }

    public void ChangeSelectedItembase(ItemBase itemBase)
    {
        itemNameText.text = itemBase.name;
        itemImage.sprite = itemBase.GetItemSprite();
        itemDescText.text = itemBase.GetItemDesc();

    }

    public void CreateButton()
    {
        for(int i = 0; i < 20; i++)
        {
            ItemSelectInventoryButton itemSelectInventoryButton = Instantiate(inventoryButtonPrefab, buttonContainerTransform);
            itemSelectInventoryButtonList.Add(itemSelectInventoryButton);
        }
    }

    public void Refresh()
    {
        int index = 0;
        foreach(ItemBase itembase in InventoryManager.instance.GetInventoryDictionary().Keys)
        {
            Debug.Log(itembase.name);  
            itemSelectInventoryButtonList[index].Bind(itembase);
            index++;
        }
    }

    public void Remove()
    {
        buttonContainerTransform.RemoveAllChild();
        itemSelectInventoryButtonList.Clear();
    }

}
