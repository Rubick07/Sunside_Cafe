using System.Collections.Generic;
using UnityEngine;

public class EmployeeListUI : MonoBehaviour
{
    public static EmployeeListUI instance;

    [SerializeField] private EmployeeCardUI cardPrefab;
    [SerializeField] private Transform containerTransform;
    [SerializeField] private EmployeeData[] employees;

    private List<EmployeeCardUI> employeeCardUIList = new List<EmployeeCardUI>();
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Remove();

        foreach (var emp in employees)
        {
            var card = Instantiate(cardPrefab, containerTransform);
            card.Setup(emp);

            employeeCardUIList.Add(card);
        }

    }

    public EmployeeCardUI GetEmployeeCardUI(EmployeeData employeeData)
    {
        foreach(EmployeeCardUI employeeCardUI in employeeCardUIList)
        {
            if(employeeCardUI.GetEmployeeData() == employeeData)
            {
                return employeeCardUI;
            }
        }

        return null;
    }

    public void Remove()
    {
        containerTransform.RemoveAllChild();
        employeeCardUIList.Clear();
    }

    public int GetEmployeeDataLength() => employeeCardUIList.Count;
}
