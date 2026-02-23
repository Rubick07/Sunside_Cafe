using UnityEngine;


[CreateAssetMenu(fileName = "FoodData", menuName = "Restaurant/Food")]
public class FoodData : ScriptableObject
{
    public enum foodDataType
    {
        MAKANAN,
        MINUMAN
    }

    public string foodName;
    public foodDataType foodType;
    public int price;

    [Header("Visual")]
    public Sprite icon;
    public GameObject prefab;

}