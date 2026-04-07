using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TrashcanUI : MonoBehaviour,IDropHandler, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private Image trashcanImage;
    [SerializeField] private Sprite trashcanCloseSprite;
    [SerializeField] private Sprite trashcanOpenSprite;
    public void OnDrop(PointerEventData eventData)
    {

        var drag = eventData.pointerDrag?.GetComponent<IRemoveable>();
        if (drag == null) return;

        GameEvents.OnPlaySFX.Invoke("TrashSFX");

        drag.Remove();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var drag = eventData.pointerDrag?.GetComponent<IRemoveable>();
        if (drag == null) return;

        trashcanImage.sprite = trashcanOpenSprite;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        trashcanImage.sprite = trashcanCloseSprite;

    }
}
