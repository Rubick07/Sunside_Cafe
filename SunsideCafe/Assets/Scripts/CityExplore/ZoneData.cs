using UnityEngine;

public class ZoneData : MonoBehaviour
{
    [SerializeField] private string zoneName;

    public string GetZoneName()
    {
        return zoneName;
    }
}
