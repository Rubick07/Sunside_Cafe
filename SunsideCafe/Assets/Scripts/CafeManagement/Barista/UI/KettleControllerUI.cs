using UnityEngine;
using UnityEngine.UI;

public class KettleControllerUI : MonoBehaviour
{
    [SerializeField] private KettleController kettleController;
    [SerializeField] private Button mixButton;

    private void Start()
    {
        kettleController.OnIngredientListChanged += KettleController_OnIngredientListChanged;
        kettleController.OnIngredientMix += KettleController_OnIngredientMix;
        kettleController.OnIngredientFailMix += KettleController_OnIngredientFailMix;

        mixButton.onClick.AddListener(kettleController.MixIngredient);
    }

    private void KettleController_OnIngredientFailMix(object sender, System.EventArgs e)
    {
        mixButton.gameObject.SetActive(false);
    }

    private void KettleController_OnIngredientMix(object sender, System.EventArgs e)
    {
        mixButton.gameObject.SetActive(false);
    }

    private void KettleController_OnIngredientListChanged(object sender, FoodItem e)
    {
        if (kettleController.CanMix())
            mixButton.gameObject.SetActive(true);

        else mixButton.gameObject.SetActive(false);

    }

    private void OnDestroy()
    {
        kettleController.OnIngredientListChanged -= KettleController_OnIngredientListChanged;
        kettleController.OnIngredientMix -= KettleController_OnIngredientMix;

    }
}
