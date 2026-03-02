using UnityEngine;

[CreateAssetMenu(menuName = "Cafe/SpecialCustomer")]
public class SpecialCustomerData : CustomerData
{
    [Header("DIALOG NAME")]
    public string startDialogTitle;
    public string clearDialogTitle;
    public string wrongFoodDialogTitle;
}
