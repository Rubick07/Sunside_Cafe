using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DiaryManagerUI : MonoBehaviour
{
    public static DiaryManagerUI instance;

    [SerializeField] private List<DiaryDaySO> diaryDaySOList;
    [Header("Text REFERENCE")]
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI dayDescText;
    [SerializeField] private TextMeshProUGUI todayExprerienceDescText;

    [Header("Button REFERENCE")]
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private Transform diaryButtonPrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        buttonContainer.RemoveAllChild();

        CreateButton();
        ChangeDayDiary(0);
    }

    public void CreateButton()
    {
        int index = 0;

        foreach(DiaryDaySO a in diaryDaySOList)
        {
            Transform diaryButtonTransform = Instantiate(diaryButtonPrefab, buttonContainer);

            DiaryDayButton diaryDayButton = diaryButtonTransform.GetComponent<DiaryDayButton>();

            diaryDayButton.Setup(index);

            index++;
        }
    }

    public void ChangeDayDiary(int ind)
    {
        dayText.text = "Day "+(ind + 1).ToString();
        dayDescText.text = diaryDaySOList[ind].dayDescstring;
        todayExprerienceDescText.text = diaryDaySOList[ind].todayExperienceDescstring;
    }

}
