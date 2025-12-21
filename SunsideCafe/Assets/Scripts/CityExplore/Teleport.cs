using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

    public void TriggerTeleport(Transform teleportObject)
    {
        TeleportUI.instance.TriggerAnimation(()=> {
            teleportObject.position = targetTransform.position;
        });
    }

}
