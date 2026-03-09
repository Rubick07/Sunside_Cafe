using UnityEngine;
using UnityEngine.UI;

public class TimetableUI : MonoBehaviour
{
    public static TimetableUI instance;

    [SerializeField] private Button completeButton;
    [SerializeField] private ShiftSlotUI slotPrefab;
    [SerializeField] private Transform containerTransform;
    [SerializeField] private CanvasGroup canvasGroup;
    private ShiftSlotUI[,] slots;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Remove();

        slots = new ShiftSlotUI[ScheduleManager.instance.GetShiftsPerDay(), ScheduleManager.instance.GetTotalDay()];

        GridLayoutGroup gridLayout = containerTransform.GetComponent<GridLayoutGroup>();
        gridLayout.constraintCount = ScheduleManager.instance.GetShiftsPerDay();

        for (int d = 0; d < ScheduleManager.instance.GetTotalDay(); d++)
            for (int s = 0; s < ScheduleManager.instance.GetShiftsPerDay(); s++)
            {
                var slot = Instantiate(slotPrefab, containerTransform);

                slots[s, d] = slot;

                slot.Setup(d,s);
            }

        completeButton.onClick.AddListener(()=> 
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });

        ScheduleManager.instance.OnAssignedEmployeeChanged += ScheduleManager_OnAssignedEmployeeChanged;
        Debug.Log(ScheduleManager.instance.IsAllEmployeeAssigned());
        completeButton.interactable = ScheduleManager.instance.IsAllEmployeeAssigned();
    }

    private void ScheduleManager_OnAssignedEmployeeChanged(object sender, EmployeeData e)
    {
        completeButton.interactable = ScheduleManager.instance.IsAllEmployeeAssigned();
    }

    public void ShowPreview(Vector2Int origin)
    {
        foreach (ShiftSlotUI slot in slots)
        {
            slot.Clear();
        }

        if (ScheduleManager.instance.IsEmployeeCanPlace(EmployeeCardUI.currentEmployeeData, origin.x, origin.y))
        {
            EmployeeCardUI employeeCardUI = EmployeeListUI.instance.GetEmployeeCardUI(EmployeeCardUI.currentEmployeeData);

            foreach (var cell in employeeCardUI.GetScheduleShapeRuntime().cells)
            {
                Vector2Int target = origin + cell;
                slots[target.x, target.y].SetPreview();
            }
        }
        else
        {
            //ClearPreview();
        }
    }

    public void ClearPreview()
    {
        foreach (var s in slots)
            s.Clear();
    }

    public void Remove()
    {
        containerTransform.RemoveAllChild();
    }

}
