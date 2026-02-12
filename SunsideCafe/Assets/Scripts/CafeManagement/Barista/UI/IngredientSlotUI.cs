using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientSlotUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private FoodData ingredient;
    [SerializeField] private IngredientDragUI dragPrefab;
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //var drag = Instantiate(dragPrefab, canvas.transform);
       //drag.Init(ingredient, eventData.position);
    }
}
