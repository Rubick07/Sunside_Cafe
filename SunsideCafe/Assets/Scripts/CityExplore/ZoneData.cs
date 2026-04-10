using UnityEngine;

public class ZoneData : MonoBehaviour
{
    [SerializeField] private string zoneName;
    [SerializeField] private string ambienceSound;
    [SerializeField] private string musicName;
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

    public string GetMusicName()
    {
        return musicName;
    }

    public Collider GetZoneConfiner()
    {
        return zoneConfiner;
    }

}
