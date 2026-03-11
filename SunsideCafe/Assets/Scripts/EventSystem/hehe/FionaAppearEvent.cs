using UnityEngine;

public class FionaAppearEvent : MonoBehaviour
{

    public void TriggerEvent()
    {
        MarketUI.instance.OnShopUIClose += MarketUI_OnShopUIClose;
    }

    private void MarketUI_OnShopUIClose(object sender, System.EventArgs e)
    {
        DialogRunnerSingleton.instance.StartDialog("FionaAppearFirstTime");

        MarketUI.instance.OnShopUIClose -= MarketUI_OnShopUIClose;
    }
}
