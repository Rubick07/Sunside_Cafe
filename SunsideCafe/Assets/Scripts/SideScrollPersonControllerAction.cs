using UnityEngine;

public class SideScrollPersonControllerAction : MonoBehaviour
{
    private SideScrollPersonController personController;

    private void Awake()
    {
        personController = GetComponent<SideScrollPersonController>();
    }

    private void Start()
    {
        MarketUI.instance.OnShopUIOpen  += MarketUI_OnShopUIOpen;
        MarketUI.instance.OnShopUIClose += MarketUI_OnShopUIClose;
        TeleportUI.OnAnyTeleportStart += TeleportUI_OnAnyTeleportStart;
        TeleportUI.OnAnyTeleportEnd += TeleportUI_OnAnyTeleportEnd;
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueStart.AddListener(()=> 
        {
            personController.SetControllerState(false);
        });
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.AddListener(() =>
        {
            personController.SetControllerState(true);
        });
    }

    private void TeleportUI_OnAnyTeleportEnd(object sender, System.EventArgs e)
    {
        personController.SetControllerState(true);
    }

    private void TeleportUI_OnAnyTeleportStart(object sender, System.EventArgs e)
    {
        personController.SetControllerState(false);
    }

    private void MarketUI_OnShopUIClose(object sender, System.EventArgs e)
    {
        personController.SetControllerState(true);
    }

    private void MarketUI_OnShopUIOpen(object sender, System.EventArgs e)
    {
        personController.SetControllerState(false);
    }
}
