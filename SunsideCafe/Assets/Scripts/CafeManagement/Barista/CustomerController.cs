using System.Collections.Generic;
using UnityEngine;

public class CustomerController
{
    CustomerData data;
    List<FoodData> order = new List<FoodData>();

    public CustomerController(CustomerData data)
    {
        this.data = data;
    }

    public CustomerData GetCustomerData() => data;

    public void AddOrder(FoodData foodDatas) => order.Add(foodDatas);
    public List<FoodData> GetOrder() => order;

    public bool TryServe(FoodData food)
    {
        if (order.Contains(food))
        {
            order.Remove(food);

            if (order.Count == 0)
                CompleteOrder();

            return true;
        }
        return false;
    }

    void CompleteOrder()
    {
        // reward, score, remove customer
    }
}
