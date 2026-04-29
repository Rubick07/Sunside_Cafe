using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlateUI : MonoBehaviour, IDropHandler, IDragHandler, IEndDragHandler, IRemoveable, IServe
{
    [SerializeField] private Plate plate;
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

        foodDoneImage.enabled = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var drag = eventData.pointerDrag?.GetComponent<IngredientDragUI>();

        if (drag == null) return;
        if (drag.GetFoodData().foodType != FoodData.foodDataType.MAKANAN) return;

        GameEvents.OnPlaySFX.Invoke("PlateServingSFX");


        plate.AddIngredient(drag.GetFoodData());



        foodDoneImage.enabled = true;
        foodDoneImage.sprite = drag.GetFoodData().icon;
    }
    public void OnDrag(PointerEventData eventData)
    {

        /*        if (plate.GetKettleState() != KettleController.KettleState.Ready)
                    return;*/

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
        plate.RemoveFood();
        foodDoneImage.enabled = false;
    }

    public FoodItem GetFoodItem()
    {
        return plate.GetFoodItem();
    }

    public void Consume()
    {
        Remove();
    }
}
