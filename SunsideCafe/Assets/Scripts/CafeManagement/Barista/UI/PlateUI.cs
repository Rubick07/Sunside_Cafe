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

        startPos = rect.transform.position;
    }

    private void Start()
    {
        plate.OnIngredientMix += KettleController_OnIngredientMix;
    }

    private void KettleController_OnIngredientMix(object sender, System.EventArgs e)
    {
        if (plate.GetFoodItem() == null)
        {
            foodDoneImage.enabled = false;
        }
        else
        {
            foodDoneImage.enabled = true;
            foodDoneImage.sprite = plate.GetFoodItem().data.icon;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var drag = eventData.pointerDrag?.GetComponent<IngredientDragUI>();

        if (drag == null) return;
        if (drag.GetFoodData().foodType != FoodData.foodDataType.MAKANAN) return;

        plate.AddIngredient(drag.GetFoodData());
    }
    public void OnDrag(PointerEventData eventData)
    {

/*        if (plate.GetKettleState() != KettleController.KettleState.Ready)
            return;*/

        rect.position += (Vector3)(eventData.delta / canvas.scaleFactor);
        canvasGroup.blocksRaycasts = false;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rect.transform.position = startPos;
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
