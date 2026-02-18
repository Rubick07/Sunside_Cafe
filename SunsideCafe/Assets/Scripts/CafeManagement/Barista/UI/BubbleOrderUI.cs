using UnityEngine;
using UnityEngine.UI;

public class BubbleOrderUI : MonoBehaviour, IBindData<FoodData>
{
    [SerializeField] private Image foodImage;
    private FoodData foodData;

    CustomerView customerView;
    public void Bind(FoodData data)
    {
        this.foodData = data;
        foodImage.sprite = data.icon;

        customerView = GetComponentInParent<CustomerView>();
        customerView.OnCustomerGetCorrectFood += CustomerView_OnCustomerGetCorrectFood;
    }

    private void CustomerView_OnCustomerGetCorrectFood(object sender, FoodData e)
    {
        if (e == foodData)
            Hide();


    }


    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void OnDestroy()
    {
        customerView.OnCustomerGetCorrectFood -= CustomerView_OnCustomerGetCorrectFood;
    }
}
