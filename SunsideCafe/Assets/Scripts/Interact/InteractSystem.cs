using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    public static InteractSystem instance;
    [SerializeField] private LayerMask interactLayerMask;

    RaycastHit hit;

    private void Awake()
    {
        instance = this;
    }



    public void InteractCheck()
    {
        Physics.Raycast(transform.position + new Vector3(0, 1f, 0), transform.forward, out hit, 5f, interactLayerMask);
        if (hit.collider != null)
        {
            IInteractable[] interactable = hit.collider.gameObject.GetComponents<IInteractable>();
            Debug.Log(interactable.Length);

            foreach(IInteractable i in interactable)
            {
                Debug.Log(i);
                i.Interact();
            }

        }
    }
    public void SideScrollInteractCheck(Transform pos)
    {
        Physics.Raycast(pos.position, Vector3.forward, out hit, 10f, interactLayerMask);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject);
            IInteractable[] interactable = hit.collider.gameObject.GetComponents<IInteractable>();

            foreach (IInteractable i in interactable)
            {
                i.Interact();
            }
        }
    }
}
