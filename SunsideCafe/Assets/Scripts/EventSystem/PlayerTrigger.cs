using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public UnityEvent OnPlayerTriggerEnter;
    public UnityEvent OnPlayerTriggerExit;

    private PlayerTriggerActionBase[] playerTriggerActionBaseArray;

    private void Awake()
    {
        playerTriggerActionBaseArray = GetComponents<PlayerTriggerActionBase>();


        foreach (PlayerTriggerActionBase playerTriggerActionBase in playerTriggerActionBaseArray)
        {
            if (playerTriggerActionBase.GetAddOnTriggerEnter())
                OnPlayerTriggerEnter.AddListener(playerTriggerActionBase.ActionEvent);

            if (playerTriggerActionBase.GetAddOnTriggerExit())
                OnPlayerTriggerExit.AddListener(playerTriggerActionBase.ActionEvent);
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

}
