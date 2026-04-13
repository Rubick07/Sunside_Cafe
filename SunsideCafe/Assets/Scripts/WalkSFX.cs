using UnityEngine;

public class WalkSFX : MonoBehaviour
{
    string currentZone;
    private void Start()
    {
        Teleport.OnAnyTeleportTrigger += Teleport_OnAnyTeleportTrigger;
    }

    private void Teleport_OnAnyTeleportTrigger(object sender, ZoneData e)
    {
        currentZone = e.GetZoneName();
    }

    public void PlayWalkSFX()
    {
        if(currentZone == "Beach")
        {
            GameEvents.OnPlaySFX.Invoke("Footsteps_SandSFX");
        }
        else
        {
            GameEvents.OnPlaySFX.Invoke("Footsteps_AsphaltSFX");
        }
    }
}
