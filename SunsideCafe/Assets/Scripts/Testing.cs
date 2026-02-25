using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private string statID;
    [SerializeField] private int amount = 1;
    [SerializeField] private TutorialTriggerType triggerType;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TutorialManager.instance.TriggerTutorial(triggerType);
            Debug.Log("Test");
            GameEvents.OnStatChanged?.Invoke(statID, amount);
        }
    }
}
