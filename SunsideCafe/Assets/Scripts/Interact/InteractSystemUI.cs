using TMPro;
using UnityEngine;

public class InteractSystemUI : MonoBehaviour
{
    private TextMeshProUGUI zoneAreaNameText;

    private void Awake()
    {
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
