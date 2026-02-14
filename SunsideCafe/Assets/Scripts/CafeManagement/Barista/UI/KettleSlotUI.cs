using UnityEngine;
using UnityEngine.UI;

public class KettleSlotUI : MonoBehaviour
{
    [SerializeField] private Image ingredientImage;
    [SerializeField] private KettleController kettleController;

    private void Start()
    {
        kettleController.OnIngredientListChanged += KettleController_OnIngredientListChanged;
        kettleController.OnIngredientMix += KettleController_OnIngredientMix;
        kettleController.OnIngredientFailMix += KettleController_OnIngredientFailMix;
    }

    private void KettleController_OnIngredientFailMix(object sender, System.EventArgs e)
    {
        ingredientImage.sprite = null;
    }

    private void KettleController_OnIngredientMix(object sender, System.EventArgs e)
    {
        ingredientImage.sprite = null;
    }

    private void KettleController_OnIngredientListChanged(object sender, FoodItem e)
    {
        var com = sender as KettleController;

        if (com == null)
            return;

        var target = com.GetComponent<KettleController>();

        if(e == null)
        {
            ingredientImage.sprite = null;
            return;
        }

        if (target.GetIngredientListCount()-1 == transform.GetSiblingIndex())
            ingredientImage.sprite = e.data.icon;

    }

    private void OnDestroy()
    {
        kettleController.OnIngredientListChanged -= KettleController_OnIngredientListChanged;
        kettleController.OnIngredientMix -= KettleController_OnIngredientMix;

    }
}
