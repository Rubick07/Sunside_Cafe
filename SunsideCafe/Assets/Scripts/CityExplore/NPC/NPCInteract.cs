using UnityEngine;

public class NPCInteract : MonoBehaviour, IInteractable
{
    private NPCBase NPCBase;

    private void Awake()
    {
        NPCBase = GetComponent<NPCBase>();
    }

    public void Interact()
    {
        NPCBase.Interact();
    }
}
