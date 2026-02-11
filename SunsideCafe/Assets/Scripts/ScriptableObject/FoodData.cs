using UnityEngine;


[CreateAssetMenu(fileName = "FoodData", menuName = "Restaurant/Food")]
public class FoodData : ScriptableObject
{
    public string foodName;
    public int price;

    [Header("Visual")]
    public Sprite icon;
    public GameObject prefab;

}