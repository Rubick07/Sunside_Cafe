using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class CustomerView : MonoBehaviour, IDropHandler
{
    public event EventHandler<FoodData> OnCustomerGetCorrectFood;

    [SerializeField] protected Image customerImage;
    [SerializeField] protected Image timeBarImage;
    [SerializeField] protected Transform allGroupTransform;
    [Header("BUBBLE ORDER REFERENCE")]
    [SerializeField] protected BubbleOrderUI bubbleOrderPrefabBubbleOrderUI;
    [SerializeField] protected Transform bubbleOrderContainerTransform;

    protected CustomerController controller;
    protected CustomerSlotUI slot;
    protected bool isActive = false;
    protected float patienceTimer;


    protected List<BubbleOrderUI> bubbleOrderUIList = new List<BubbleOrderUI>();

    private void Update()
    {
        if (!isActive)
            return;

        patienceTimer -= Time.deltaTime;

        timeBarImage.fillAmount = (float)patienceTimer / controller.GetCustomerData().patienceTime;
    }

    public virtual void Bind(CustomerData data, CustomerSlotUI slotUI)
    {
        controller = new CustomerController(data, this);
        customerImage.sprite = data.portrait;
        patienceTimer = data.patienceTime;
        slot = slotUI;

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
            ?.GetComponent<IServe>();

        if (foodUI == null) return;

        bool success = controller.TryServe(foodUI.GetFoodItem());
        if (success)
        {
            foodUI.Consume();
            isActive = false;
            CustomerSlotUI customerSlotUI = GetComponentInParent<CustomerSlotUI>();

            OnCustomerGetCorrectFood?.Invoke(this, foodUI.GetFoodItem().data);
        }
        else
        {
            //foodUI.ReturnToOrigin();
        }
    }

    public virtual void SetActive()
    {
        isActive = true;

        bubbleOrderContainerTransform.gameObject.SetActive(true);
        timeBarImage.gameObject.SetActive(true);
    }

    public CustomerSlotUI GetCustomerSlotUI() => slot;

    public CustomerController GetCustomerController() => controller;
}
