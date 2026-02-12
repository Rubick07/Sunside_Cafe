using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KettleUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private KettleController kettleController;
    [SerializeField] private Image foodDoneImage;

    private void Start()
    {
        kettleController.OnIngredientMix += KettleController_OnIngredientMix;
    }

    private void KettleController_OnIngredientMix(object sender, System.EventArgs e)
    {
        if(kettleController.GetFoodItem() == null)
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

        kettleController.AddIngredient(drag.GetFoodData());

    }

    public KettleController GetKettleController() => kettleController;

}
