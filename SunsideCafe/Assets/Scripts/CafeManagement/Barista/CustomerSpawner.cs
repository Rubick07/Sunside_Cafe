using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public static CustomerSpawner instance;

    [SerializeField] private CustomerSlotUI[] slots;
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private float timeToSpawnCustomer;
    [SerializeField] private RectTransform spawnPositionRectTransform;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Spawn(CustomerManager.instance.GetCustomerDataList()[0]);
    }

    public void SpawnCustomer()
    {
        int random = Random.Range(0, CustomerManager.instance.GetCustomerDataList().Count);

        Spawn(CustomerManager.instance.GetCustomerDataList()[random]);
    }

    private void Spawn(CustomerData data)
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
