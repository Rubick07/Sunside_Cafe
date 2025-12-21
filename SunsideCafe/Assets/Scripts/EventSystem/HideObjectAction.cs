using UnityEngine;

public class HideObjectAction : PlayerTriggerActionBase
{
    [SerializeField] private GameObject hideGameobject;
    public override void ActionEvent()
    {
        hideGameobject.SetActive(false);
    }
}
