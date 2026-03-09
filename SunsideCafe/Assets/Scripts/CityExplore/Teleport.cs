using UnityEngine;
using System;

public class Teleport : MonoBehaviour
{
    public static event EventHandler<ZoneData> OnAnyTeleportTrigger;

    [SerializeField] private Transform targetTransform;

    
    public void TriggerTeleport(Transform teleportObject)
    {
        TeleportUI.instance.TriggerAnimation(()=> {
            teleportObject.position = targetTransform.position;

            OnAnyTeleportTrigger?.Invoke(this, targetTransform.GetComponentInParent<ZoneData>());
        });
    
    }

    [Yarn.Unity.YarnCommand("Teleport")]
    public void TeleportPlayer()
    {
        GameObject player = Helpers.GetPlayerGameObject();

        player.transform.position = targetTransform.position;

        OnAnyTeleportTrigger?.Invoke(this, targetTransform.GetComponentInParent<ZoneData>());
    }

    public ZoneData GetZoneDataTarget() => targetTransform.GetComponentInParent<ZoneData>();

}
