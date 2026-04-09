using UnityEngine;

[CreateAssetMenu(menuName = "Restaurant/Recipe")]
public class RecipeData : ScriptableObject
{
    public string recipeName;
    [TextArea(5, 10)]
    public string recipeDesc;

    public FoodData output;

    [Tooltip("Input harus semua terpenuhi")]
    public FoodData[] requiredIngredients;

    public int bonusLevel = 1;
}