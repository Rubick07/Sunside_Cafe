using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class IngredientDragUI : MonoBehaviour,IDragHandler, IEndDragHandler,IBeginDragHandler
{
    public static event EventHandler OnAnyIngredientBeginDrag;

    [SerializeField] private Image icon;
    [SerializeField] private FoodData data;

    RectTransform rect;
    Canvas canvas;
    CanvasGroup canvasGroup;
    Vector2 startPos;

    private void Start()
    {
        icon.sprite = data.icon;
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();


        startPos = rect.transform.localPosition;

    }

    public void Init(FoodData ingredient, Vector2 startPos)
    {
        data = ingredient;
        icon.sprite = ingredient.icon;

        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        rect.position = startPos;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(data.soundName != "")
        {
            GameEvents.OnPlaySFX(data.soundName);
        }

        OnAnyIngredientBeginDrag?.Invoke(this, EventArgs.Empty);
    }

    public void OnDrag(PointerEventData e)
    {
        rect.anchoredPosition += (Vector2)(e.delta / canvas.scaleFactor);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData e)
    {
        rect.transform.localPosition = startPos;
        canvasGroup.blocksRaycasts = true;
        //Destroy(gameObject);
    }

    public FoodData GetFoodData() => data;

}
