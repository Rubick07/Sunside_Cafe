using UnityEngine;

public class TeleportInteract : MonoBehaviour, IInteractable
{
    Teleport teleport;
    private bool canTeleport = true;

    private void Awake()
    {
        teleport = GetComponent<Teleport>();
    }

    public void Interact()
    {
        if (canTeleport)
        {
            GameEvents.OnPlaySFX.Invoke("DoorOpenSFX");

            GameObject player = Helpers.GetPlayerGameObject();
            teleport.TriggerTeleport(player.transform);
        }
        else
        {
            DialogRunnerSingleton.instance.StartDialog("DilarangMasukCafe");
        }

    }

    [Yarn.Unity.YarnCommand("SetTeleportActive")]
    public void TeleportActive()
    {
        canTeleport = true;
    }

    [Yarn.Unity.YarnCommand("SetTeleportDisable")]
    public void TeleportDisable()
    {
        canTeleport = false;
    }

}
