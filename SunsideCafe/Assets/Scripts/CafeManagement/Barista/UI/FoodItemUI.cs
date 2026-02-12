using UnityEngine;
using UnityEngine.EventSystems;

public class FoodItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private FoodData foodData;

    RectTransform rect;
    Canvas canvas;
    Vector2 startPos;
    Transform startParent;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData e)
    {
        startPos = rect.anchoredPosition;
        startParent = transform.parent;
        transform.SetParent(canvas.transform, true);
    }

    public void OnDrag(PointerEventData e)
    {
        rect.anchoredPosition += e.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData e)
    {
        ReturnToOrigin();
    }

    public void ReturnToOrigin()
    {
        transform.SetParent(startParent, false);
        rect.anchoredPosition = startPos;
    }

    public void Consume()
    {
        Destroy(gameObject);
    }

    public FoodData GetFoodData() => foodData;
}
