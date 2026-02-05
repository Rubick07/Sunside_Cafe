using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShiftSlotUI : MonoBehaviour, IDropHandler, IPointerEnterHandler
{
    [SerializeField] private int day;
    [SerializeField] private int shift;

    [SerializeField] private Image employeeIcon;
    [SerializeField] private Image highlighter;
    [SerializeField] private Image assignedHighlighter;

    void Start()
    {
        ScheduleManager.instance.OnAssignedEmployeeChanged += ScheduleManager_OnAssignedEmployeeChanged;
        Refresh();
    }

    public void Assign(EmployeeData employee)
    {
        ScheduleManager.instance.AssignEmployee(shift, day, employee);
    }

    void Refresh()
    {
        var data = ScheduleManager.instance.scheduleGrid.Get(shift, day);
        employeeIcon.sprite = data.assignedEmployee ? data.assignedEmployee.portrait : null;
        employeeIcon.enabled = data.assignedEmployee != null;

        assignedHighlighter.enabled = data != null;
    }

    public void Setup(int day, int shift)
    {
        this.day = day;
        this.shift = shift;

    }

    public void SetPreview()
    {
        highlighter.enabled = true;
    }

    public void Clear()
    {
        highlighter.enabled = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var card = eventData.pointerDrag?.GetComponent<EmployeeCardUI>();
        if (card == null) return;

        if (!ScheduleManager.instance.IsEmployeeCanPlace(card.GetEmployeeData(), shift, day))
        {
            Debug.Log("Tidak bisa Dipasang");
            return;
        }

        Assign(card.GetEmployeeData());
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (EmployeeCardUI.currentEmployeeData == null)
            return;

        TimetableUI.instance.ShowPreview(new Vector2Int(shift, day));
    }

    private void ScheduleManager_OnAssignedEmployeeChanged(object sender, System.EventArgs e)
    {
        Clear();
        Refresh();
    }

    private void OnDisable()
    {
        ScheduleManager.instance.OnAssignedEmployeeChanged -= ScheduleManager_OnAssignedEmployeeChanged;
    }
}
