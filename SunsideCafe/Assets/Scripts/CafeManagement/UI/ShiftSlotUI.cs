using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShiftSlotUI : MonoBehaviour, IDropHandler 
{
    [SerializeField] private int day;
    [SerializeField] private int shift;

    [SerializeField] private Image employeeIcon;

    void Start()
    {
        Refresh();
    }

    public void Assign(EmployeeData employee)
    {
        if (ScheduleManager.instance.IsEmployeeWorking(employee, day, shift))
        {
            Debug.Log("Employee already working!");
            return;
        }

        ScheduleManager.instance.AssignEmployee(day, shift, employee);
        Refresh();
    }

    void Refresh()
    {
        var data = ScheduleManager.instance.scheduleGrid.Get(day, shift);
        employeeIcon.sprite = data.assignedEmployee ? data.assignedEmployee.portrait : null;
        employeeIcon.enabled = data.assignedEmployee != null;
    }

    public void Setup(int day, int shift)
    {
        this.day = day;
        this.shift = shift;

    }

    public void OnDrop(PointerEventData eventData)
    {
        var card = eventData.pointerDrag?.GetComponent<EmployeeCardUI>();
        if (card == null) return;

        Assign(card.GetEmployeeData());
    }
}
