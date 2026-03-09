using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public UnityEvent OnPlayerTriggerEnter;
    public UnityEvent OnPlayerTriggerExit;

    private PlayerTriggerActionBase[] playerTriggerActionBaseArray;

    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();

        playerTriggerActionBaseArray = GetComponents<PlayerTriggerActionBase>();


        foreach (PlayerTriggerActionBase playerTriggerActionBase in playerTriggerActionBaseArray)
        {
            if (playerTriggerActionBase.GetAddOnTriggerEnter())
                OnPlayerTriggerEnter.AddListener(playerTriggerActionBase.ActionEvent);

            if (playerTriggerActionBase.GetAddOnTriggerExit())
                OnPlayerTriggerExit.AddListener(playerTriggerActionBase.ActionEvent);

            if (!playerTriggerActionBase.GetisRepeatable())
                OnPlayerTriggerEnter.AddListener(playerTriggerActionBase.HasTriggered);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggerExit?.Invoke();
        }
    }

    [Yarn.Unity.YarnCommand("SetPlayerTriggerActive")]
    public void SetEnable()
    {
        collider.enabled = true;
    }

    [Yarn.Unity.YarnCommand("SetPlayerTriggerDisable")]
    public void SetDisable()
    {
        collider.enabled = false;
    }



}
