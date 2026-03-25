using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaristaManagerUISpecialSpawn : MonoBehaviour
{
    [SerializeField] private CustomerSpawner spawner;
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI timerText;
    private bool isActive;

    private void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            StartBarista();
            startButton.gameObject.SetActive(false);
        });

        BaristaManager.instance.OnGameStateChanged += BaristaManager_OnGameStateChanged;

        timerText.text = "Not Open Yet";
    }


    private void BaristaManager_OnGameStateChanged(object sender, BaristaManager.baristaGameState e)
    {
        if (e == BaristaManager.baristaGameState.Open)
            isActive = true;
        else isActive = false;
    }

    void Update()
    {
        if (!isActive)
            return;

        float minutes = Helpers.TimeConverterToMinutes(BaristaManager.instance.GetTimer());
        float seconds = Helpers.TimeConverterSecond(BaristaManager.instance.GetTimer());

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    [Yarn.Unity.YarnCommand("StartBaristaSpecialCustomer")]
    public void StartBarista()
    {
        BaristaManager.instance.ChangeBaristaManagerState(BaristaManager.baristaGameState.FriendSession);
        spawner.SpawnSpecialCustomer();
    }
}
