using UnityEngine;
using System.Collections.Generic;
using System;

public class Plate : MonoBehaviour
{
    public event EventHandler<FoodItem> OnIngredientListChanged;
    public event EventHandler OnIngredientMix;
    public event EventHandler<PlateState> OnKettleStateChanged;

    public enum PlateState
    {
        putIngredients,
        Ready,
        Ondrag
    }

    private PlateState kettleState;

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

        MixIngredient();

        return true;
    }

    public void MixIngredient()
    {
        FoodItem fd = RecipeManager.instance.TryCombine(ingredients);

        if (fd == null)
        {
            if (maxIngredient == ingredients.Count - 1)
                RemoveIngredients();

            return;
        }

        foodItem = fd;
        ingredients.Clear();
        OnIngredientMix?.Invoke(this, EventArgs.Empty);

        SetState(PlateState.Ready);
    }

    public void SetState(PlateState state)
    {
        kettleState = state;

        OnKettleStateChanged?.Invoke(this, state);
    }

    public void RemoveIngredients()
    {
        ingredients.Clear();
        OnIngredientListChanged?.Invoke(this, null);
    }

    public void RemoveFood()
    {
        foodItem = null;

        RemoveIngredients();
        SetState(PlateState.putIngredients);
    }

    public int GetIngredientListCount() => ingredients.Count;

    public bool IsFull() => ingredients.Count == maxIngredient;

    public FoodItem GetFoodItem() => foodItem;

    public PlateState GetKettleState() => kettleState;

}
