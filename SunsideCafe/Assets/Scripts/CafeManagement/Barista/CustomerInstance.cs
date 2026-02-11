using System.Collections.Generic;
using UnityEngine;

public class CustomerInstance
{
    public CustomerData data;
    public List<FoodData> order;
    public float remainingPatience;

    public bool isServed;
}

public enum CustomerState
{
    Entering,
    Ordering,
    Waiting,
    Served,
    Leaving,
    AngryLeave
}