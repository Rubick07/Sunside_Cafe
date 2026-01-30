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

}
