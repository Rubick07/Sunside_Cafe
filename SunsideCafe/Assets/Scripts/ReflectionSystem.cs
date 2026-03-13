using System.Collections.Generic;
using UnityEngine;

public class ReflectionSystem : MonoBehaviour
{
    [SerializeField] private List<string> dialogueTitleList;
    private void StartReflection()
    {
        int currentDay = DaySystem.instance.GetCurrentDay();
        Debug.Log(dialogueTitleList[currentDay]);

        DialogRunnerSingleton.instance.StartDialog(dialogueTitleList[currentDay]);
    }

    [Yarn.Unity.YarnCommand("ReflectionStart")]
    public void StartReflectionDialogue()
    {
        StartReflection();
    }

}
