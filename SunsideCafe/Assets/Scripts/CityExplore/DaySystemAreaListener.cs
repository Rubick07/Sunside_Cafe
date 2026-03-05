using System.Collections.Generic;
using UnityEngine;

public class DaySystemAreaListener : MonoBehaviour
{
    [SerializeField] private List<GameObject> areaEventList;

    private void Start()
    {
        DaySystem.instance.OnDayChanged += DaySystem_OnDayChanged;
    }

    private void DaySystem_OnDayChanged(object sender, int e)
    {
        foreach(GameObject a in areaEventList)
        {
            a.SetActive(false);
        }

        areaEventList[e].SetActive(true);
    }
}
