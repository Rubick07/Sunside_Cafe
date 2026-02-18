using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour, IBindData<RecipeData>
{
    [SerializeField] private Image[] ingredientImagetArray;
    [SerializeField] private Image foodImage;

    public void Bind(RecipeData data)
    {
        foreach(Image a in ingredientImagetArray)
        {
            a.enabled = false;
        }

        int index = 0;
        foreach(FoodData foodData in data.requiredIngredients)
        {
            ingredientImagetArray[index].sprite = foodData.icon;
            ingredientImagetArray[index].enabled = true;

            index++;
        }

        foodImage.sprite = data.output.icon;
    }


}
