using UnityEngine;

public class SchedulingTutorialAction : MonoBehaviour
{
    public void TriggerDialog()
    {
        DialogRunnerSingleton.instance.StartDialog("Day2SchedulingComplete");
    }
}
