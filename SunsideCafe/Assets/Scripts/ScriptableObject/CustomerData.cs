using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cafe/Customer")]
public class CustomerData : ScriptableObject
{
    public string customerName;
    public Sprite portrait;

    public float patienceTime = 30f;
    public int coinReward;

    public List<FoodData> possibleOrders;
}
