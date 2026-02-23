using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CustomerSlotUI : MonoBehaviour
{
    public static Transform exitPosition;

    private CustomerView currentCustomer;

    public bool IsEmpty => currentCustomer == null;

    private void Start()
    {
        exitPosition = GameObject.Find("ExitPosition").transform;
    }

    public void Assign(CustomerView view)
    {
        currentCustomer = view;
        view.transform.SetParent(transform);

        RectTransform rectTransform = view.GetComponent<RectTransform>();

        rectTransform.DOLocalMoveX(0, 1f).OnComplete(()=> 
        {
            view.SetActive();    
        });
    }

    public void Clear()
    {
        if (currentCustomer is SpecialCustomerView)
        {
            SpecialCustomerData a = currentCustomer.GetCustomerController().GetCustomerData() as SpecialCustomerData;

            DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.AddListener(CustomerComplete);
            DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.AddListener(Test);
            DialogRunnerSingleton.instance.StartDialog(a.clearDialogTitle);

            return;
        }

        CustomerComplete();

    }

    private void Test()
    {
        BaristaManager.instance.ChangeBaristaManagerState(BaristaManager.baristaGameState.Close);
        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.RemoveListener(Test);
    }

    private void CustomerComplete()
    {
        RectTransform rectTransform = currentCustomer.GetComponent<RectTransform>();

        rectTransform.DOMoveX(exitPosition.position.x, 1f).OnComplete(() =>
        {
            Destroy(currentCustomer.gameObject);
            currentCustomer = null;
            CustomerSpawner.instance.SpawnCustomer();
        });

        DialogRunnerSingleton.instance.GetDialogueRunner().onDialogueComplete.RemoveListener(CustomerComplete);

    }
}