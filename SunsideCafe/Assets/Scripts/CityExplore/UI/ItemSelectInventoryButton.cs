using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSelectInventoryButton : MonoBehaviour,IBindData<ItemBase> , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI itemAmountText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;
    [SerializeField] private GameObject highlighter;

    private ItemBase item;

    private void Awake()
    {

        button.onClick.AddListener(()=>
        {
            if (item == null)
                return;

            InventoryManagerUI.instance.ChangeSelectedItembase(item);
        });

        highlighter.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlighter.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlighter.SetActive(false);
    }

    public void Bind(ItemBase data)
    {
        itemAmountText.text = InventoryManager.instance.GetInventoryDictionary()[data].ToString();
        itemImage.sprite = data.GetItemSprite();
    }
}
