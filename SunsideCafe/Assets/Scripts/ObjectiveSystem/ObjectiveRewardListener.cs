using UnityEngine;

public class ObjectiveRewardListener : MonoBehaviour
{
    [SerializeField] private string objectiveID;
    [SerializeField] private int rewardMoney;

    void OnEnable()
    {
        GameEvents.OnObjectiveCompleted += Handle;
    }

    private void OnDisable()
    {
        GameEvents.OnObjectiveCompleted -= Handle;
    }

    void Handle(string id)
    {
        Debug.Log(id +" Complete");
        if (id == objectiveID)
        {
            Debug.Log("Reward given!");
        }
    }


}
