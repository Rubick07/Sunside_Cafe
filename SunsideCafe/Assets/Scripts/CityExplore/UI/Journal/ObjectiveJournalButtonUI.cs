using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveJournalButtonUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI objectiveName;

    private ObjectiveData objectiveData;
    private void Start()
    {
        ObjectiveJournalManagerUI.instance.ChangeObjectivePage(objectiveData);
    }

    public void Setup(ObjectiveData objectiveData)
    {
        this.objectiveData = objectiveData;

        objectiveName.text = objectiveData.title;
    }
}
