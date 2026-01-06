using UnityEngine;

public class TeleportInteract : MonoBehaviour, IInteractable
{
    Teleport teleport;

    private void Awake()
    {
        teleport = GetComponent<Teleport>();
    }

    public void Interact()
    {
        GameObject player = Helpers.GetPlayerGameObject();
        teleport.TriggerTeleport(player.transform);
    }
}
