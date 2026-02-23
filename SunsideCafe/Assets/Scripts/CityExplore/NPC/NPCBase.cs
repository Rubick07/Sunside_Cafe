using UnityEngine;

public abstract class NPCBase : MonoBehaviour
{
    [SerializeField] protected NPCData data;

    public abstract void Interact();

    public abstract void TriggerDialog();

    public NPCData GetNPCData() => data; 

}
