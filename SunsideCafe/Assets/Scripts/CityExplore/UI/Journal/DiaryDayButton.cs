using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaryDayButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private Button dayButton;

    private int index;

    private void Start()
    {
        DaySystem.instance.OnDayChanged += DaySystem_OnDayChanged;

        dayButton.onClick.AddListener(()=> 
        {
            DiaryManagerUI.instance.ChangeDayDiary(index);
        });

        CheckInteractableDay(0);
    }

    private void DaySystem_OnDayChanged(object sender, int e)
    {
        CheckInteractableDay(e);
    }

    private void CheckInteractableDay(int e)
    {
        if (e == index)
        {
            dayButton.interactable = true;
        }
    }

    public void Setup(int index)
    {
        dayText.text = "Day " + (index + 1).ToString();
        this.index = index;
    }

}
