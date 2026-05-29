using UnityEngine;


[CreateAssetMenu(fileName = "FoodData", menuName = "Restaurant/Food")]
public class FoodData : ScriptableObject
{
    public enum foodDataType
    {
        MAKANAN,
        MINUMAN,
        AddOn,
        Bahan
    }

    public string foodName;
    public foodDataType foodType;
    public int price;
    public string soundName = "";

    [Header("Visual")]
    public Sprite icon;
    public GameObject prefab;

}