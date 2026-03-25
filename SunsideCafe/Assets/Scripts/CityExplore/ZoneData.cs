using UnityEngine;

public class ZoneData : MonoBehaviour
{
    [SerializeField] private string zoneName;
    [SerializeField] private string ambienceSound;

    private Collider zoneConfiner;

    private void Awake()
    {
        zoneConfiner = GetComponent<Collider>();
    }

    public string GetZoneName()
    {
        return zoneName;
    }

    public string GetAmbienceName()
    {
        return ambienceSound;
    }

    public Collider GetZoneConfiner()
    {
        return zoneConfiner;
    }

}
