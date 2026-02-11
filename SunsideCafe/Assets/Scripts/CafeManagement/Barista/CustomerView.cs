using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class CustomerView : MonoBehaviour, IDropHandler
{
    public event EventHandler OnCustomerGetCorrectFood;

    [SerializeField] private Image customerImage;
    [SerializeField] private Image timeBarImage;
    [SerializeField] private Transform allGroupTransform;
    [Header("BUBBLE ORDER REFERENCE")]
    [SerializeField] private BubbleOrderUI bubbleOrderPrefabBubbleOrderUI;
    [SerializeField] private Transform bubbleOrderContainerTransform;

    private CustomerController controller;
    private bool isActive = false;
    private float patienceTimer;


    private List<BubbleOrderUI> bubbleOrderUIList = new List<BubbleOrderUI>();

    private void Update()
    {
        if (!isActive)
            return;

        patienceTimer -= Time.deltaTime;

        timeBarImage.fillAmount = (float)patienceTimer / controller.GetCustomerData().patienceTime;
    }

    public void Bind(CustomerData data)
    {
        controller = new CustomerController(data);
        customerImage.sprite = data.portrait;
        patienceTimer = data.patienceTime;

        int randomOrder = UnityEngine.Random.Range(1, data.possibleOrders.Count);

        for(int i = 0; i < randomOrder; i++)
        {
            int random = UnityEngine.Random.Range(0, data.possibleOrders.Count -1);

            controller.AddOrder(data.possibleOrders[random]);
        }

        foreach(FoodData fdata in controller.GetOrder())
        {
            BubbleOrderUI bubbleOrderUI = Helpers.CreateUI<BubbleOrderUI, FoodData>(bubbleOrderPrefabBubbleOrderUI, bubbleOrderContainerTransform, fdata);

            bubbleOrderUIList.Add(bubbleOrderUI);
        }

        bubbleOrderContainerTransform.gameObject.SetActive(false);
        timeBarImage.gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var foodUI = eventData.pointerDrag
            ?.GetComponent<FoodItemUI>();

        if (foodUI == null) return;

        bool success = controller.TryServe(foodUI.GetFoodData());

        if (success)
        {
            foodUI.Consume();

            OnCustomerGetCorrectFood?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            foodUI.ReturnToOrigin();
        }
    }

    public void SetActive()
    {
        isActive = true;

        bubbleOrderContainerTransform.gameObject.SetActive(true);
        timeBarImage.gameObject.SetActive(true);
    }
}
