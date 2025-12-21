using UnityEngine;
using TMPro;

public class ZoneTeleportTargetName : MonoBehaviour
{
    [SerializeField] ZoneData zoneData;

    private TextMeshProUGUI zoneAreaNameText;

    private void Awake()
    {
        zoneAreaNameText = GetComponentInChildren<TextMeshProUGUI>();

        Hide();
    }

    private void Start()
    {
        zoneAreaNameText.text = zoneData.GetZoneName();
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
