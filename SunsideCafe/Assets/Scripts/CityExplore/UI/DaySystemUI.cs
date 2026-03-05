using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DaySystemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private Image maskImage;

    private bool isActive;
    private bool isFill;

    private void Start()
    {
        DaySystem.instance.OnDayChanged += DaySystem_OnDayChanged;

        maskImage.fillAmount = 0;
    }

    private void Update()
    {
        if (!isActive)
            return;

        if (isFill)
        {
            maskImage.fillAmount += Time.deltaTime;

            if(maskImage.fillAmount >= 1)
            {
                isActive = false;
            }

        }
        else
        {
            maskImage.fillAmount -= Time.deltaTime;

            if (maskImage.fillAmount <= 0)
            {
                isActive = false;
            }
        }

    }

    private void DaySystem_OnDayChanged(object sender, int e)
    {
        dayText.text = "Day "+ e.ToString();
    }

    public void Show()
    {
        isActive = true;
        isFill = true;
        maskImage.fillOrigin = 0;
        maskImage.fillAmount = 0;
    }

    public void Hide()
    {
        isActive = true;
        isFill = false;

        maskImage.fillOrigin = 1;
        maskImage.fillAmount = 1;
    }

    [Yarn.Unity.YarnCommand("DayUIFadeIn")]
    public void DayFadeIn()
    {
        Show();
    }
    [Yarn.Unity.YarnCommand("DayUIFadeOut")]
    public void DayFadeOut()
    {
        Hide();
    }


}
