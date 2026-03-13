using System.Collections.Generic;
using UnityEngine;

public class DaySystemAreaListener : MonoBehaviour
{
    [SerializeField] private List<GameObject> areaEventList;

    private void Start()
    {
        DaySystem.instance.OnDayChanged += DaySystem_OnDayChanged;
        SetAreaEvent(0);
    }

    private void DaySystem_OnDayChanged(object sender, int e)
    {
        SetAreaEvent(e);
    }

    private void SetAreaEvent(int e)
    {
        foreach (GameObject a in areaEventList)
        {
            a.SetActive(false);
        }

        if (e > areaEventList.Count)
            return;

        areaEventList[e].SetActive(true);
    }
}
