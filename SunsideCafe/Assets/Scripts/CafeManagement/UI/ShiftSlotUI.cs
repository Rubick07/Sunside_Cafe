using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShiftSlotUI : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static ShiftSlotUI currentHoverShiftSlotUI;

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

        assignedHighlighter.enabled = data.assignedEmployee != null;
    }

    public void Setup(int day, int shift)
    {
        this.day = day;
        this.shift = shift;

    }

    public Vector2Int GetPos() => new Vector2Int(shift,day);

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
        currentHoverShiftSlotUI = this;

        if (EmployeeCardUI.currentEmployeeData == null)
            return;

        RefreshPreview();
    }

    public void RefreshPreview()
    {
        TimetableUI.instance.ShowPreview(new Vector2Int(shift, day));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        currentHoverShiftSlotUI = null;
        TimetableUI.instance.ClearPreview();
    }

    private void ScheduleManager_OnAssignedEmployeeChanged(object sender, EmployeeData e)
    {
        Clear();
        Refresh();
    }

    private void OnDisable()
    {
        ScheduleManager.instance.OnAssignedEmployeeChanged -= ScheduleManager_OnAssignedEmployeeChanged;
    }

}
