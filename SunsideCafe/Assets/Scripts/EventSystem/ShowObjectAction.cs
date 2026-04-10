using UnityEngine;

public class ShowObjectAction : PlayerTriggerActionBase
{
    [SerializeField] private GameObject showGameobject;
    public override void ActionEvent()
    {
        Debug.LogError("Test");
        showGameobject.SetActive(true);
    }
}
