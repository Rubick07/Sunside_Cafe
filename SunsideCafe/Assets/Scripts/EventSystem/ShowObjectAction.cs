using UnityEngine;

public class ShowObjectAction : PlayerTriggerActionBase
{
    [SerializeField] private GameObject showGameobject;
    public override void ActionEvent()
    {
        showGameobject.SetActive(true);
    }
}
