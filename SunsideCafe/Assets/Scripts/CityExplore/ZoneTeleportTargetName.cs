using UnityEngine;
using TMPro;

public class ZoneTeleportTargetName : MonoBehaviour
{
    private Teleport teleport;
    private TextMeshProUGUI zoneAreaNameText;

    private void Awake()
    {
        zoneAreaNameText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        teleport = transform.parent.parent.GetComponentInChildren<Teleport>();
        zoneAreaNameText.text = teleport.GetZoneDataTarget().GetZoneName();
        Hide();
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
