using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private CustomerSlotUI[] slots;
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private float timeToSpawnCustomer;
    [SerializeField] private RectTransform spawnPositionRectTransform;

    private void Start()
    {
        Spawn(CustomerManager.instance.GetCustomerDataList()[0]);
    }


    public void Spawn(CustomerData data)
    {
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                GameObject viewGameobject = Instantiate(customerPrefab, spawnPositionRectTransform);

                viewGameobject.transform.SetParent(null);

                CustomerView view = viewGameobject.GetComponent<CustomerView>();

                view.Bind(data);
                slot.Assign(view);
                return;
            }
        }
    }
}
