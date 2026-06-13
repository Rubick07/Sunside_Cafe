using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


public class FoodItemUI : MonoBehaviour,IDragHandler, IEndDragHandler, IDropHandler, IRemoveable, IServe, IBeginDragHandler
{
    public static event EventHandler OnAnyFoodItemUIBeginDrag;
    public static event EventHandler OnAnyFoodItemUIDrop;
    public static event EventHandler OnAnyAddOnAdded;

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

        var drag = eventData.pointerDrag?.GetComponent<IFoodItemAble>();
        if (drag == null) return;

        FoodItem foodItem = drag.GetFoodItem();

        if (foodItem == null)
            return;

        if (foodItem.data.foodType == FoodData.foodDataType.MAKANAN || foodItem.data.foodType == FoodData.foodDataType.Bahan)
            return;

        if (foodItem.data.foodType == FoodData.foodDataType.AddOn && this.foodItem == null)
            return;

        if(foodItem.data.foodType == FoodData.foodDataType.AddOn && this.foodItem != null)
        {
            List<FoodItem> ingredients = new();
            ingredients.Add(foodItem);
            ingredients.Add(this.foodItem);

            foodItem = RecipeManager.instance.TryCombine(ingredients);

            OnAnyAddOnAdded?.Invoke(this, EventArgs.Empty);
        }

        if (foodItem == null)
        {
            return;
        }

        this.foodItem = foodItem;

        Color a = foodImage.color;
        a.a = 1;

        foodImage.color = a;

        foodImage.sprite = foodItem.data.icon;

        var drag2 = eventData.pointerDrag?.GetComponent<KettleUI>();

        if (drag2 != null)
        {
            GameEvents.OnPlaySFX("WaterPouringSFX");
            drag2.Place();
        }


        OnAnyFoodItemUIDrop?.Invoke(this, EventArgs.Empty);
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnAnyFoodItemUIBeginDrag?.Invoke(this, EventArgs.Empty);
    }
}
