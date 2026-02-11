using UnityEngine;

public class FoodItem
{
    public FoodData data;
    public int level;

    public FoodItem(FoodData data, int level)
    {
        this.data = data;
        this.level = level;
    }

}