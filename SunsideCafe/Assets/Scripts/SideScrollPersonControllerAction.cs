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

        JournalUI.instance.OnJournalUIOpen += JournalUI_OnJournalUIOpen;
        JournalUI.instance.OnJournalUIClose += JournalUI_OnJournalUIClose;

        TutorialManager.instance.OnTutorialTrigger += TutorialManager_OnTutorialTrigger;
        TutorialManager.instance.OnTutorialComplete += TutorialManager_OnTutorialComplete;

        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueStart.AddListener(()=> 
        {
            personController.SetControllerActive(false);
        });
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.AddListener(() =>
        {
            personController.SetControllerActive(true);
        });
    }

    private void TutorialManager_OnTutorialComplete(object sender, System.EventArgs e)
    {
        personController.SetControllerState(SideScrollPersonController.playerState.NORMAL);
        personController.SetControllerActive(true);
    }

    private void TutorialManager_OnTutorialTrigger(object sender, TutorialTriggerType e)
    {
        personController.SetControllerState(SideScrollPersonController.playerState.TUTORIAL);
        personController.SetControllerActive(false);
    }

    private void JournalUI_OnJournalUIClose(object sender, System.EventArgs e)
    {
        personController.SetControllerState(SideScrollPersonController.playerState.NORMAL);
    }

    private void JournalUI_OnJournalUIOpen(object sender, System.EventArgs e)
    {
        personController.SetControllerState(SideScrollPersonController.playerState.JOURNAL);
    }

    private void TeleportUI_OnAnyTeleportEnd(object sender, System.EventArgs e)
    {
        personController.SetControllerActive(true);
    }

    private void TeleportUI_OnAnyTeleportStart(object sender, System.EventArgs e)
    {
        personController.SetControllerActive(false);
    }

    private void MarketUI_OnShopUIClose(object sender, System.EventArgs e)
    {
        personController.SetControllerState(SideScrollPersonController.playerState.NORMAL);

        personController.SetControllerActive(true);
    }

    private void MarketUI_OnShopUIOpen(object sender, System.EventArgs e)
    {
        personController.SetControllerState(SideScrollPersonController.playerState.OPENSHOP);

        personController.SetControllerActive(false);
    }


}
