using UnityEngine;

public class ZoneAmbienceAction : MonoBehaviour
{
    private void Start()
    {
        Teleport.OnAnyTeleportTrigger += Teleport_OnAnyTeleportTrigger;


    }

    private void Teleport_OnAnyTeleportTrigger(object sender, ZoneData e)
    {
        if(e.GetAmbienceName() == "NatureAmbience")
        {
            if (DaySystem.instance.IsDay())
            {
                GameEvents.OnPlayAmbience.Invoke("NatureAmbienceDay");
            }
            else
            {
                GameEvents.OnPlayAmbience.Invoke("NatureAmbienceNight");
            }


            return;
        }

        GameEvents.OnPlayAmbience.Invoke(e.GetAmbienceName());
    }
}
