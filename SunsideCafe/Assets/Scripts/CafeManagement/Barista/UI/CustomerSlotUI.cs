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
        RectTransform rectTransform = currentCustomer.GetComponent<RectTransform>();

        rectTransform.DOMoveX(exitPosition.position.x, 1f).OnComplete(() =>
        {
            Destroy(currentCustomer.gameObject);
            currentCustomer = null;
            CustomerSpawner.instance.SpawnCustomer();
        });

    }

}