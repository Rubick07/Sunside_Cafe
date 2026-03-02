using UnityEngine;
using System.Collections.Generic;
using System;

public class Plate : MonoBehaviour
{
    private FoodItem foodItem;

    public bool AddIngredient(FoodData data)
    {
        if (foodItem != null)
            return false;

        FoodItem newFoodItem = new FoodItem(data);
        foodItem = newFoodItem;

        //Debug.Log("Masuk: " + data.foodName);
        return true;
    }

    public void RemoveFood()
    {
        foodItem = null;
    }

    public FoodItem GetFoodItem() => foodItem;

}
