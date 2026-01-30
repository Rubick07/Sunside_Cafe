using UnityEngine;

public class ZoneData : MonoBehaviour
{
    [SerializeField] private string zoneName;

    private Collider zoneConfiner;

    private void Awake()
    {
        zoneConfiner = GetComponent<Collider>();
    }

    public string GetZoneName()
    {
        return zoneName;
    }

    public Collider GetZoneConfiner()
    {
        return zoneConfiner;
    }

}
