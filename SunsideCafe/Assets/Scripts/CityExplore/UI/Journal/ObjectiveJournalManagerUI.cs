using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ObjectiveJournalManagerUI : MonoBehaviour
{
    public static ObjectiveJournalManagerUI instance;

    [Header("TEXT REFERENCE")]
    [SerializeField] private TextMeshProUGUI objectiveTitleText;
    [SerializeField] private TextMeshProUGUI objectiveDescText;
    [Header("Button REFERENCE")]
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private Transform objectiveButtonPrefab;

    private List<ObjectiveJournalButtonUI> objectiveJournalButtonUIList = new();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        buttonContainer.RemoveAllChild();

        ObjectiveManager.instance.OnObjectiveClear += ObjectiveManager_OnObjectiveClear;

        ObjectiveData objectiveData = ObjectiveManager.instance.GetCurrentObjectiveData();

        CreateButton(objectiveData);
    }

    private void ObjectiveManager_OnObjectiveClear(object sender, ObjectiveRuntime e)
    {
        CreateButton(e.data);
    }

    public void CreateButton(ObjectiveData objectiveData)
    {
        Transform objectiveButtonTransform = Instantiate(objectiveButtonPrefab, buttonContainer);

        ObjectiveJournalButtonUI objectiveJournalButtonUI = objectiveButtonTransform.GetComponent<ObjectiveJournalButtonUI>();

        objectiveJournalButtonUI.Setup(objectiveData);

    }

    public void ChangeObjectivePage(ObjectiveData objectiveData)
    {
        objectiveTitleText.text = objectiveData.title;
        objectiveDescText.text = objectiveData.description;
    }

}
