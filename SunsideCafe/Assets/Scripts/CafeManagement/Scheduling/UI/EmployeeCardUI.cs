using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class EmployeeCardUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static EmployeeData currentEmployeeData;
    public static EmployeeCardUI currentEmployeeCard;

    public static event EventHandler OnAnyCardBeginDrag;

    [SerializeField] private TextMeshProUGUI employeeNameText;
    [SerializeField] private Image icon;
    [SerializeField] private Image highlight;
    [SerializeField] private Image blocker;
    [SerializeField] private SchedulePieceView pieceViewSmall;
    [SerializeField] private SchedulePieceView pieceViewBig;
    private EmployeeData employeeData;

    Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    Vector2 startPosition;
    Transform startParent;

    private ScheduleShapeRuntime shapeRuntime;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }
    public void Setup(EmployeeData data)
    {
        employeeData = data;

        employeeNameText.text = data.employeeName;
        icon.sprite = data.portrait;
        shapeRuntime = new ScheduleShapeRuntime(data.scheduleShape.cells);

        pieceViewSmall.BuildShape(shapeRuntime);

        blocker.enabled = false;
    }

    public void SetBlockerActive() => blocker.enabled = true;

    public void SetBlockerDisable()
    {
        blocker.enabled = false;
    }

    public void RotateLeft()
    {
        pieceViewBig.Clear();

        shapeRuntime.RotateLeftShape();
        pieceViewBig.BuildShape(shapeRuntime);
    }

    public void RotateRight()
    {
        pieceViewBig.Clear();

        shapeRuntime.RotateRightShape();
        pieceViewBig.BuildShape(shapeRuntime);
    }


    public EmployeeData GetEmployeeData()
    {
        return employeeData;
    }

    public ScheduleShapeRuntime GetScheduleShapeRuntime() => shapeRuntime;

    public void OnBeginDrag(PointerEventData eventData)
    {

        currentEmployeeData = this.employeeData;
        currentEmployeeCard = this;

        startPosition = rectTransform.anchoredPosition;
        startParent = transform.parent;

        pieceViewBig.BuildShape(shapeRuntime);

        transform.SetParent(canvas.transform); // supaya di atas UI lain
        canvasGroup.blocksRaycasts = false;

        transform.position = eventData.position;

        canvasGroup.alpha = 0.7f;

        OnAnyCardBeginDrag?.Invoke(this, EventArgs.Empty);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        transform.localScale = Vector3.one * 1.05f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetPos();


        /*
                if (ShiftSlotUI.currentHoverShiftSlotUI != null)
                {
                    this.enabled = false;
                    blocker.enabled = true;
                }

        */
    }

    public void ResetPos()
    {
        currentEmployeeData = null;
        currentEmployeeCard = null;

        pieceViewBig.Clear();


        transform.SetParent(startParent);

        rectTransform.anchoredPosition = startPosition;
        canvasGroup.blocksRaycasts = true;

        canvasGroup.alpha = 1f;

        transform.localScale = Vector3.one;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.enabled = true; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.enabled = false;
    }
}
