using System.Collections.Generic;
using UnityEngine;
using System;

public class KettleController : MonoBehaviour
{
    public event EventHandler<FoodItem> OnIngredientListChanged;
    public event EventHandler OnIngredientMix;
    public event EventHandler OnIngredientFailMix;

    public enum KettleState
    {
        putIngredients,
        Mix,
        Ready
    }

    private KettleState kettleState;

    [SerializeField] private float timeToMix;

    private FoodItem foodItem;
    private int maxIngredient = 3;
    List<FoodItem> ingredients = new();

    public bool AddIngredient(FoodData data)
    {
        if (maxIngredient == ingredients.Count - 1)
            return false;

        FoodItem newFoodItem = new FoodItem(data);

        ingredients.Add(newFoodItem);

        Debug.Log("Masuk: " + data.foodName);
        // cek resep, update UI, dll


        OnIngredientListChanged?.Invoke(this, newFoodItem);

        return true;
    }

    public void MixIngredient()
    {
        FoodItem fd = RecipeManager.instance.TryCombine(ingredients);

        if (fd == null)
        {
            ingredients.Clear();
            OnIngredientFailMix?.Invoke(this, EventArgs.Empty);
            return;
        }

        foodItem = fd;

        ingredients.Clear();
        OnIngredientMix?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveIngredients()
    {

    }

    public int GetIngredientListCount() => ingredients.Count;

    public bool IsFull() => ingredients.Count == maxIngredient;

    public FoodItem GetFoodItem() => foodItem;
}
