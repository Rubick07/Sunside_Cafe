using UnityEngine;

[CreateAssetMenu(fileName = "DiaryDaySO", menuName = "Scriptable Objects/DiaryDaySO")]
public class DiaryDaySO : ScriptableObject
{
    [TextArea(5,10)]
    public string dayDescstring;
    [TextArea(5, 10)]
    public string todayExperienceDescstring;
}
