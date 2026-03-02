using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Yarn.Unity;

public class ZoneUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI zoneText;
    private RectTransform rectTransform;

    private bool isActive;
    private float timeToHide = 3f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Teleport.OnAnyTeleportTrigger += Teleport_OnAnyTeleportTrigger;
        //TeleportUI.OnAnyTeleportEnd += TeleportUI_OnAnyTeleportEnd;


        Hide();
    }

    private void Update()
    {
        if (!isActive)
            return;

        timeToHide -= Time.deltaTime;

        if(timeToHide <= 0)
        {
            isActive = false;
            timeToHide = 3f;
            HideAnimation();
        }

    }

    private void Teleport_OnAnyTeleportTrigger(object sender, ZoneData e)
    {
        zoneText.text = e.GetZoneName();
    }

    private void TeleportUI_OnAnyTeleportEnd(object sender, System.EventArgs e)
    {
        ShowAnimation();
    }

    public void ShowAnimation()
    {
        Show();
        rectTransform.DOMoveX(325, .5f).OnComplete(()=>
        {
            isActive = true;
        });
    }

    public void HideAnimation()
    {
        rectTransform.DOMoveX(-295f, .5f);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        rectTransform.DOMoveX(-295f, 0f);
        gameObject.SetActive(false);
    }

    [YarnCommand("ShowZoneUI")]
    public void ShowAnimationYarn()
    {
        ShowAnimation();
    }

}
