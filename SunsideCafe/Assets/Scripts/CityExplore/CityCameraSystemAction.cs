using UnityEngine;

public class CityCameraSystemAction : MonoBehaviour
{
    private CityCameraSystem cityCameraSystem;

    private void Awake()
    {
        cityCameraSystem = GetComponent<CityCameraSystem>();
    }

    private void Start()
    {
        Teleport.OnAnyTeleportTrigger += Teleport_OnAnyTeleportTrigger;
    }

    private void Teleport_OnAnyTeleportTrigger(object sender, ZoneData e)
    {
        cityCameraSystem.ChangeCameraConfiner(e.GetZoneConfiner());
    }

    private void OnDestroy()
    {
        Teleport.OnAnyTeleportTrigger -= Teleport_OnAnyTeleportTrigger;
    }
}
