using System.Collections.Generic;
using UnityEngine;

public class ReflectionSystem : MonoBehaviour
{
    [SerializeField] private List<string> dialogueTitleList;

    private void Start()
    {
        int currentDay = DaySystem.instance.GetCurrentDay();

        DialogRunnerSingleton.instance.StartDialog(dialogueTitleList[currentDay]);
    }

}
