using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class KettleUI : MonoBehaviour, IDropHandler, IDragHandler, IEndDragHandler, IRemoveable, IBeginDragHandler, IFoodItemAble
{
    public static event EventHandler OnAnyKettleUIStartDrag;

    [SerializeField] private KettleController kettleController;
    [SerializeField] private Image foodDoneImage;

    RectTransform rect;
    Canvas canvas;
    CanvasGroup canvasGroup;
    Vector2 startPos;



    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        startPos = rect.transform.localPosition;

    }

    private void Start()
    {
        kettleController.OnIngredientMix += KettleController_OnIngredientMix;
    }

    private void KettleController_OnIngredientMix(object sender, System.EventArgs e)
    {
        if (kettleController.GetFoodItem() == null)
        {
            foodDoneImage.enabled = false;
        }
        else
        {
            foodDoneImage.enabled = true;
            foodDoneImage.sprite = kettleController.GetFoodItem().data.icon;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var drag = eventData.pointerDrag?.GetComponent<IngredientDragUI>();

        if (drag == null) return;
        if (drag.GetFoodData().foodType != FoodData.foodDataType.Bahan) return;

        kettleController.AddIngredient(drag.GetFoodData());
    }
    public void OnDrag(PointerEventData eventData)
    {

        if (kettleController.GetKettleState() != KettleController.KettleState.Ready)
            return;

        rect.anchoredPosition += (Vector2)(eventData.delta / canvas.scaleFactor);
        canvasGroup.blocksRaycasts = false;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rect.transform.localPosition = startPos;
        canvasGroup.blocksRaycasts = true;
    }

    public void Remove()
    {
        kettleController.RemoveFood();
        foodDoneImage.enabled = false;
    }

    public FoodItem GetFoodItem()
    {
        return kettleController.GetFoodItem();
    }

    public void Place()
    {
        kettleController.RemoveFood();
        foodDoneImage.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnAnyKettleUIStartDrag?.Invoke(this, EventArgs.Empty);
    }
}
