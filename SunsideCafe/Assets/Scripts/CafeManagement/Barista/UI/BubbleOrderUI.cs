using UnityEngine;
using UnityEngine.UI;

public class BubbleOrderUI : MonoBehaviour, IBindData<FoodData>
{
    [SerializeField] private Image foodImage;
    private FoodData foodItem;

    private void Start()
    {

    }

    public void Bind(FoodData data)
    {
        this.foodItem = data;
        foodImage.sprite = data.icon;

        CustomerView customerView = GetComponentInParent<CustomerView>();
        customerView.OnCustomerGetCorrectFood += CustomerView_OnCustomerGetCorrectFood;
    }

    private void CustomerView_OnCustomerGetCorrectFood(object sender, System.EventArgs e)
    {
        Hide();
    }


    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

}
