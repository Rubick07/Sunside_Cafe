using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CreditMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] pageGameobjectArray;
    [SerializeField] private Image maskImage;

    private bool isActive;
    private bool isFill;

    private int index = 0;

    private bool canPress = false;

    private void Start()
    {
        GameEvents.OnPlayMusic("ExploreDay");

        pageGameobjectArray[0].GetComponent<CanvasGroup>().alpha = 0;

        pageGameobjectArray[0].GetComponent<CanvasGroup>().DOFade(1f, 1f).OnComplete(() =>
         {
             canPress = true;
         });


    }
    private void Update()
    {
        if (!canPress)
            return;


        if (Input.GetMouseButtonDown(0))
        {
            NextPage();
        }


        if (!isActive)
            return;

        if (isFill)
        {
            maskImage.fillAmount += Time.deltaTime;

            if (maskImage.fillAmount >= 1)
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

    public void NextPage()
    {
        canPress = false;

        if (index == pageGameobjectArray.Length - 3)
        {
            index++;
            pageGameobjectArray[index].GetComponent<CanvasGroup>().DOFade(1f, 1f).OnComplete(() =>
            {
                canPress = true;
            });
            return;
        }

        if (index == pageGameobjectArray.Length - 2)
        {
            index++;
            pageGameobjectArray[index].GetComponent<CanvasGroup>().DOFade(1f,1f).OnComplete(() => 
            {
                canPress = true;
            });
            return;
        }
        
        if (index == pageGameobjectArray.Length - 1)
        {
            BlackscreenUI.instance.FadeIn(() => Loader.Load(Loader.Scene.MainMenuScene), 1f);
            return;
        }
        
        if(index == 0)
        {
            canPress = false;

            pageGameobjectArray[0].GetComponent<CanvasGroup>().DOFade(0f, 1f).OnComplete(() =>
            {
                pageGameobjectArray[0].SetActive(false);
                canPress = true;
                Hide();

            });


            index++;
            pageGameobjectArray[index].SetActive(true);
            return;
        }

        maskImage.fillOrigin = 0;
        maskImage.fillAmount = 0;

        maskImage.DOFillAmount(1f, 1f).OnComplete(() => 
        {
            pageGameobjectArray[index].SetActive(false);
            index++;
            pageGameobjectArray[index].SetActive(true);

            maskImage.fillOrigin = 1;
            maskImage.fillAmount = 1;

            maskImage.DOFillAmount(0f, 1f).OnComplete(() => 
            {
                canPress = true;
            });

        });






    }
}
