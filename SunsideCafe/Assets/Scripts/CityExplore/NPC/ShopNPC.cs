using UnityEngine;

public class ShopNPC : NPCBase
{
    [SerializeField] private string dialogTitle;
    [TextArea()]
    [SerializeField] private string shopText;

    public override void Interact()
    {
        //throw new System.NotImplementedException();
    }

    public override void TriggerDialog()
    {
        DialogRunnerSingleton.instance.StartDialog(dialogTitle);
    }

    public string GetShopText() => shopText;

}
