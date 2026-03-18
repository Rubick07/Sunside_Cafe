using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public static CustomerSpawner instance;

    [SerializeField] private CustomerSlotUI[] slots;
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private GameObject specialCustomerPrefab;
    [SerializeField] private float timeToSpawnCustomer;
    [SerializeField] private RectTransform spawnPositionRectTransform;

    private CustomerData currentCustomerData;
    private bool alreadySpawnSpecialCustomer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        BaristaManager.instance.OnGameStateChanged += BaristaManager_OnGameStateChanged;
    }

    private void BaristaManager_OnGameStateChanged(object sender, BaristaManager.baristaGameState e)
    {
        if(e == BaristaManager.baristaGameState.Open)
        {
            SpawnCustomer();
        }
    }

    public void SpawnSpecialCustomer()
    {
        if(CustomerManager.instance.GetSpecialCustomerDataList().Count == 0)
        {
            BaristaManager.instance.ChangeBaristaManagerState(BaristaManager.baristaGameState.Close);
        }

        if (alreadySpawnSpecialCustomer)
            return;

        CustomerData customerData = CustomerManager.instance.GetSpecialCustomerDataList()[0];

        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                GameObject viewGameobject = Instantiate(specialCustomerPrefab, spawnPositionRectTransform);

                viewGameobject.transform.SetParent(null);

                CustomerView view = viewGameobject.GetComponent<CustomerView>();

                view.Bind(customerData, slot);
                slot.Assign(view);

                alreadySpawnSpecialCustomer = true;
                return;
            }
        }
    }

    public void SpawnCustomer()
    {
        if(BaristaManager.instance.GetBaristaGameState() == BaristaManager.baristaGameState.Open)
        {
            SpawnRandomCustomer();
        }
        else if(BaristaManager.instance.GetBaristaGameState() == BaristaManager.baristaGameState.FriendSession)
        {
            SpawnSpecialCustomer();
        }
        
    }

    private void SpawnRandomCustomer()
    {
        int random = 0;
        do
        {
            random = Random.Range(0, CustomerManager.instance.GetCustomerDataList().Count);

        } while (currentCustomerData == CustomerManager.instance.GetCustomerDataList()[random]);

        Spawn(CustomerManager.instance.GetCustomerDataList()[random]);

        currentCustomerData = CustomerManager.instance.GetCustomerDataList()[random];
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

                view.Bind(data, slot);
                slot.Assign(view);
                return;
            }
        }
    }

    private void OnDestroy()
    {
        BaristaManager.instance.OnGameStateChanged -= BaristaManager_OnGameStateChanged;
    }
}
