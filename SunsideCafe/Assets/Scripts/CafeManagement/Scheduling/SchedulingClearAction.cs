using UnityEngine;

public class SchedulingClearAction : MonoBehaviour
{
    [SerializeField] private string dialogTitle;
    public void TriggerDialog()
    {
        DialogRunnerSingleton.instance.StartDialog(dialogTitle);
    }
}
