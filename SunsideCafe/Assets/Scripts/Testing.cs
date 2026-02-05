using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private string statID;
    [SerializeField] private int amount = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Test");
            GameEvents.OnStatChanged?.Invoke(statID, amount);
        }
    }
}
