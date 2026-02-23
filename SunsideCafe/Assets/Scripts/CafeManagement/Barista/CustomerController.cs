using System.Collections.Generic;
using UnityEngine;

public class CustomerController
{
    CustomerData data;
    List<FoodData> order = new List<FoodData>();

    private CustomerView customerView;
    public CustomerController(CustomerData data, CustomerView customerView)
    {
        this.data = data;
        this.customerView = customerView;
    }

    public CustomerData GetCustomerData() => data;

    public void AddOrder(FoodData foodDatas)
    {
        order.Add(foodDatas);
    } 
    public List<FoodData> GetOrder() => order;

    public bool TryServe(FoodItem food)
    {
        if (order.Contains(food.data))
        {
            order.Remove(food.data);

            if (order.Count == 0)
            {
                CompleteOrder();
            }
            return true;
        }
        return false;
    }

    void CompleteOrder()
    {
        // reward, score, remove customer
        customerView.GetCustomerSlotUI().Clear();
    }
}
