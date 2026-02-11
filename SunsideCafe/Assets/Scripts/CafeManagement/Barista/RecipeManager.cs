using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private List<RecipeData> recipes;

    public FoodItem TryCombine(List<FoodItem> ingredients)
    {
        foreach (var recipe in recipes)
        {
            if (MatchRecipe(recipe, ingredients))
            {
                int totalLevel = ingredients.Sum(i => i.level);
                int finalLevel = totalLevel + recipe.bonusLevel;

                return new FoodItem(recipe.output, finalLevel);
            }
        }

        return null; // Tidak ada resep cocok
    }

    bool MatchRecipe(RecipeData recipe, List<FoodItem> ingredients)
    {
        if (ingredients.Count != recipe.requiredIngredients.Length)
            return false;

        return recipe.requiredIngredients
            .All(req => ingredients.Any(i => i.data == req));
    }
}
