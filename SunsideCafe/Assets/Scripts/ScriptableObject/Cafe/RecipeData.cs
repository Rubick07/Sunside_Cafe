using UnityEngine;

[CreateAssetMenu(menuName = "Restaurant/Recipe")]
public class RecipeData : ScriptableObject
{
    public string recipeName;
    public FoodData output;

    [Tooltip("Input harus semua terpenuhi")]
    public FoodData[] requiredIngredients;

    public int bonusLevel = 1;
}