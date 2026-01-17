using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EmployeeCardUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Image highlight;

    private EmployeeData employeeData;

    Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    Vector2 startPosition;
    Transform startParent;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void Setup(EmployeeData data)
    {
        employeeData = data;
        icon.sprite = data.portrait;
    }

    public EmployeeData GetEmployeeData()
    {
        return employeeData;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.anchoredPosition;
        startParent = transform.parent;

        transform.SetParent(canvas.transform); // supaya di atas UI lain
        canvasGroup.blocksRaycasts = false;

        transform.position = eventData.position;

        canvasGroup.alpha = 0.7f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        transform.localScale = Vector3.one * 1.05f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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
