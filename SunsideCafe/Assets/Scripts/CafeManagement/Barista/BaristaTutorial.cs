using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BaristaTutorial : MonoBehaviour
{
    [Header("Highlight REFERENCE")]
    [SerializeField] private Image tutorialHighlight;
    [SerializeField] private GameObject ingredientHighlightGameobject;
    [SerializeField] private GameObject tekoHighlightGameobject;
    [SerializeField] private GameObject kopiHighlightGameobject;
    [SerializeField] private GameObject customerHighlightGameobject;
    [SerializeField] private GameObject customerPertama;
    [Header("GROUP REFERENCE")]
    [SerializeField] private GameObject basicBrewUITitleGameObject;
    [SerializeField] private GameObject basicBrewUIFirstGameobject;
    [SerializeField] private GameObject basicBrewUISecondGameobject;
    [SerializeField] private GameObject basicBrewUIThirdGameobject;


    private void Start()
    {
        tutorialHighlight.fillAmount = 0;


        ingredientHighlightGameobject.SetActive(true);
        tekoHighlightGameobject.SetActive(false);
        kopiHighlightGameobject.SetActive(false);
        customerHighlightGameobject.SetActive(false);

        basicBrewUITitleGameObject.SetActive(true);
        basicBrewUIFirstGameobject.SetActive(true);
        basicBrewUISecondGameobject.SetActive(false);
        basicBrewUIThirdGameobject.SetActive(false);

        IngredientDragUI.OnAnyIngredientBeginDrag += IngredientDragUI_OnAnyIngredientBeginDrag;

    }

    private void IngredientDragUI_OnAnyIngredientBeginDrag(object sender, System.EventArgs e)
    {
        IngredientDragUI.OnAnyIngredientBeginDrag -= IngredientDragUI_OnAnyIngredientBeginDrag;

        ingredientHighlightGameobject.SetActive(false);
        tekoHighlightGameobject.SetActive(true);

        basicBrewUITitleGameObject.SetActive(false);

        KettleController.OnAnyIngredientListChanged += KettleController_OnAnyIngredientListChanged;
    }

    private void KettleController_OnAnyIngredientListChanged(object sender, System.EventArgs e)
    {
        KettleController.OnAnyIngredientListChanged -= KettleController_OnAnyIngredientListChanged;

        tekoHighlightGameobject.SetActive(false);

        tutorialHighlight.DOFillAmount(1f, .5f).OnComplete(() => 
        {
            basicBrewUIFirstGameobject.SetActive(false);

            ingredientHighlightGameobject.SetActive(true);

            basicBrewUITitleGameObject.SetActive(true);
            basicBrewUISecondGameobject.SetActive(true);

            IngredientDragUI.OnAnyIngredientBeginDrag += IngredientDragUI_OnAnyIngredientBeginDragSecondTutorial; ;

            tutorialHighlight.fillAmount = 0f;
        });

    }

    private void IngredientDragUI_OnAnyIngredientBeginDragSecondTutorial(object sender, System.EventArgs e)
    {
        IngredientDragUI.OnAnyIngredientBeginDrag -= IngredientDragUI_OnAnyIngredientBeginDragSecondTutorial;

        ingredientHighlightGameobject.SetActive(false);
        tekoHighlightGameobject.SetActive(true);

        basicBrewUITitleGameObject.SetActive(false);
        basicBrewUIFirstGameobject.SetActive(true);
        basicBrewUISecondGameobject.SetActive(false);



        KettleController.OnAnyIngredientListChanged += KettleController_OnAnyIngredientListChangedSecond;
    }

    private void KettleController_OnAnyIngredientListChangedSecond(object sender, System.EventArgs e)
    {
        KettleController.OnAnyIngredientListChanged -= KettleController_OnAnyIngredientListChangedSecond;

        tekoHighlightGameobject.SetActive(false);

        basicBrewUIFirstGameobject.SetActive(false);
        basicBrewUISecondGameobject.SetActive(true);

        KettleController.OnAnyIngredientMix += KettleController_OnAnyIngredientMix;

    }

    private void KettleController_OnAnyIngredientMix(object sender, System.EventArgs e)
    {
        KettleController.OnAnyIngredientMix -= KettleController_OnAnyIngredientMix;

        tutorialHighlight.DOFillAmount(1f, .5f).OnComplete(() =>
        {
            basicBrewUISecondGameobject.SetActive(false);
            
            ingredientHighlightGameobject.SetActive(false);
            tekoHighlightGameobject.SetActive(true);


            basicBrewUITitleGameObject.SetActive(true);
            basicBrewUIThirdGameobject.SetActive(true);

            KettleUI.OnAnyKettleUIStartDrag += KettleUI_OnAnyKettleUIStartDrag;

            tutorialHighlight.fillAmount = 0f;
        });

    }

    private void KettleUI_OnAnyKettleUIStartDrag(object sender, System.EventArgs e)
    {
        KettleUI.OnAnyKettleUIStartDrag -= KettleUI_OnAnyKettleUIStartDrag;

        tekoHighlightGameobject.SetActive(false);
        kopiHighlightGameobject.SetActive(true);

        FoodItemUI.OnAnyFoodItemUIBeginDrag += FoodItemUI_OnAnyFoodItemUIBeginDrag;
    }

    private void FoodItemUI_OnAnyFoodItemUIBeginDrag(object sender, System.EventArgs e)
    {
        FoodItemUI.OnAnyFoodItemUIBeginDrag -= FoodItemUI_OnAnyFoodItemUIBeginDrag;

        kopiHighlightGameobject.SetActive(false);
        customerHighlightGameobject.SetActive(true);

        CustomerView.OnAnyCustomerGetFood += CustomerView_OnAnyCustomerGetFood;
    }

    private void CustomerView_OnAnyCustomerGetFood(object sender, System.EventArgs e)
    {
        CustomerView.OnAnyCustomerGetFood -= CustomerView_OnAnyCustomerGetFood;

        customerHighlightGameobject.SetActive(false);

        tutorialHighlight.DOFillAmount(1f, .5f).OnComplete(() =>
        {
            basicBrewUIThirdGameobject.SetActive(false);

            ingredientHighlightGameobject.SetActive(false);
            //tekoHighlightGameobject.SetActive(true);


            //basicBrewUITitleGameObject.SetActive(true);
            //basicBrewUIThirdGameobject.SetActive(true);
            //KettleUI.OnAnyKettleUIStartDrag += KettleUI_OnAnyKettleUIStartDrag;
            DialogRunnerSingleton.instance.StartDialog("BaristaTutorialDone");


            customerPertama.SetActive(false);
            tutorialHighlight.fillAmount = 0f;
        });

    }
}
