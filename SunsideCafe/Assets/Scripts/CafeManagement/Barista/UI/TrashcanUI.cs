using UnityEngine;
using UnityEngine.EventSystems;
public class TrashcanUI : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        var drag = eventData.pointerDrag?.GetComponent<IRemoveable>();
        if (drag == null) return;

        GameEvents.OnPlaySFX.Invoke("TrashSFX");

        drag.Remove();

    }
}
