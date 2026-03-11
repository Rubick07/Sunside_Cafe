using UnityEngine;
using UnityEngine.Events;
public class ObjectiveEventListener : MonoBehaviour
{
    [SerializeField] private string objectiveID;
    [SerializeField] private UnityEvent OnObjectiveClear;
    private void OnEnable()
    {
        GameEvents.OnObjectiveCompleted += Handle;
    }

    private void OnDisable()
    {
        GameEvents.OnObjectiveCompleted -= Handle;
    }

    void Handle(string id)
    {
        Debug.Log(id + " Complete");
        if (id == objectiveID)
        {
            OnObjectiveClear?.Invoke();
        }
    }
}
