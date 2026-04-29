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


        startPos = rect.transform.localPosition;

        Color a = foodImage.color;
        a.a = 0;

        foodImage.color = a;

        //foodImage.enabled = false;
    }

    public void OnDrag(PointerEventData e)
    {
        if (foodItem == null)
            return;

        rect.anchoredPosition += (Vector2)(e.delta / canvas.scaleFactor);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData e)
    {
        ReturnToOrigin();
    }

    public void ReturnToOrigin()
    {
        rect.transform.localPosition = startPos;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {

        var drag = eventData.pointerDrag?.GetComponent<KettleUI>();
        if (drag == null) return;

        FoodItem foodItem = drag.GetFoodItem();

        if (foodItem == null)
            return;


        this.foodItem = foodItem;

        Color a = foodImage.color;
        a.a = 1;

        foodImage.color = a;

        foodImage.sprite = foodItem.data.icon;

        GameEvents.OnPlaySFX("WaterPouringSFX");


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


        Color a = foodImage.color;
        a.a = 0;

        foodImage.color = a;

        //foodImage.enabled = false;

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
