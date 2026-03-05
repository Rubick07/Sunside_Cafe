using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FoodItemUI : MonoBehaviour,IDragHandler, IEndDragHandler, IDropHandler, IRemoveable, IServe
{
    [SerializeField] private Image foodImage;
    private FoodItem foodItem;

    RectTransform rect;
    Canvas canvas;
    CanvasGroup canvasGroup;
    Vector2 startPos;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();


        startPos = rect.transform.position;
        foodImage.enabled = false;
    }

    public void OnDrag(PointerEventData e)
    {
        if (foodItem == null)
            return;

        rect.position += (Vector3)(e.delta / canvas.scaleFactor);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData e)
    {
        ReturnToOrigin();
    }

    public void ReturnToOrigin()
    {
        rect.transform.position = startPos;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {

        var drag = eventData.pointerDrag?.GetComponent<KettleUI>();
        if (drag == null) return;

        FoodItem foodItem = drag.GetFoodItem();
        this.foodItem = foodItem;

        foodImage.enabled = true;
        foodImage.sprite = foodItem.data.icon;

        drag.Place();
    }

    public void Consume()
    {
        RemoveFood();
        //Destroy(gameObject);
    }

    public void RemoveFood()
    {
        foodItem = null;
        foodImage.enabled = false;
        foodImage.sprite = null;
    }


    public void Remove()
    {
        RemoveFood();
    }

    public FoodItem GetFoodItem()
    {
        return foodItem;
    }

}
