using UnityEngine;

public class SpecialCustomerView : CustomerView
{

    public override void Bind(CustomerData data, CustomerSlotUI slotUI)
    {
        controller = new CustomerController(data, this);
        customerImage.sprite = data.portrait;
        slot = slotUI;

        foreach(FoodData a in data.possibleOrders)
        {
            controller.AddOrder(a);
        }


        bubbleOrderContainerTransform.gameObject.SetActive(false);
        timeBarImage.gameObject.SetActive(false);
    }

    public override void WrongFood()
    {
        SpecialCustomerData a = controller.GetCustomerData() as SpecialCustomerData;

        DialogRunnerSingleton.instance.StartDialog(a.wrongFoodDialogTitle);
    }

    public override void SetActive()
    {
        SpecialCustomerData a = controller.GetCustomerData() as SpecialCustomerData;

        DialogRunnerSingleton.instance.StartDialog(a.startDialogTitle);
    }

}
