using UnityEngine;
using TMPro;

public class ZoneTeleportTargetName : MonoBehaviour
{
    [SerializeField] ZoneData zoneData;

    private TextMeshProUGUI zoneAreaNameText;

    private void Awake()
    {
        zoneAreaNameText = GetComponentInChildren<TextMeshProUGUI>();

        zoneAreaNameText.text = zoneData.GetZoneName();
    }

    private void Start()
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
