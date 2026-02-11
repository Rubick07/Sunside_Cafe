using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CustomerSlotUI : MonoBehaviour
{
    private CustomerView currentCustomer;

    public bool IsEmpty => currentCustomer == null;

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
        Destroy(currentCustomer.gameObject);
        currentCustomer = null;
    }

}