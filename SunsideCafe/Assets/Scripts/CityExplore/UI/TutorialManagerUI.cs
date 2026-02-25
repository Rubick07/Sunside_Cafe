using UnityEngine;
using UnityEngine.UI;

public class TutorialManagerUI : MonoBehaviour
{
    [SerializeField] private TutorialData[] tutorialDataArray;

    private void Start()
    {
        foreach (TutorialData tutorialData in tutorialDataArray)
        {
            tutorialData.exitButton.onClick.AddListener(()=> 
            {
                TutorialManager.instance.TutorialComplete();
            });
        }
        HideAllChild();
        Hide();

        TutorialManager.instance.OnTutorialTrigger += TutorialManager_OnTutorialTrigger;
        TutorialManager.instance.OnTutorialComplete += TutorialManager_OnTutorialComplete;
    }

    private void TutorialManager_OnTutorialComplete(object sender, System.EventArgs e)
    {
        HideAllChild();
        Hide();
    }

    private void TutorialManager_OnTutorialTrigger(object sender, TutorialTriggerType e)
    {
        Show();
        foreach(TutorialData data in tutorialDataArray)
        {
            if(data.triggerType == e)
            {
                data.tutorialGroupUIGameobject.SetActive(true);
                return;
            }

        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void HideAllChild()
    {
        foreach(TutorialData tutorialData in tutorialDataArray)
        {
            tutorialData.tutorialGroupUIGameobject.SetActive(false);
        }
    }

}

[System.Serializable]
public class TutorialData
{
    public TutorialTriggerType triggerType;
    public GameObject tutorialGroupUIGameobject;
    public Button exitButton;

}
