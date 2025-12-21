using UnityEngine;

public class PlayerTeleportAction : PlayerTriggerActionBase
{
    private Teleport teleport;

    private void Awake()
    {
        teleport = GetComponent<Teleport>();
    }

    public override void ActionEvent()
    {
        if (!isRepeatable && hasTriggered == false)
            return;

        GameObject player = Helpers.GetPlayerGameObject();

        teleport.TriggerTeleport(player.transform);

    }

}
