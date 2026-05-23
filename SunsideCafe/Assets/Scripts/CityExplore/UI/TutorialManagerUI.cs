using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialManagerUI : MonoBehaviour
{
    [SerializeField] private TutorialData[] tutorialDataArray;

    private void Start()
    {
        foreach (TutorialData tutorialData in tutorialDataArray)
        {
/*
            tutorialData.exitButton.onClick.AddListener(()=> 
            {
                TutorialManager.instance.TutorialComplete();
            });
*/
            tutorialData.canvasGroup = tutorialData.tutorialGroupUIGameobject.GetComponent<CanvasGroup>();
            tutorialData.canvasGroup.alpha = 0;

            tutorialData.highlight.fillAmount = 0;
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
                data.canvasGroup.DOFade(1f, 1f);
                data.highlight.DOFillAmount(1f, 1f);

                return;
            }

        }
    }

    public void ShowAnimation()
    {

    }

    public void HideAnimation()
    {

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
   [HideInInspector] 
    public CanvasGroup canvasGroup;
    public Image highlight;
    //public Button exitButton;
    
}
