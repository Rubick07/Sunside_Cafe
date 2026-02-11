using TMPro;
using UnityEngine;

public class TimeManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI shiftText;

    private void Start()
    {
        TimeManager.Instance.OnShiftChanged += UpdateUI;

    }

    void UpdateUI(int day, int shift)
    {
        dayText.text = $"Day {day + 1}";
        shiftText.text = $"Shift {shift + 1}";
    }
}
