using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager instance;

    [SerializeField] private List<CustomerData> customerDataList;
    [SerializeField] private List<SpecialCustomerData> SpecialCustomerDataList;

    private void Awake()
    {
        instance = this;
    }

    public List<CustomerData> GetCustomerDataList() => customerDataList;
    public List<SpecialCustomerData> GetSpecialCustomerDataList() => SpecialCustomerDataList;

}
