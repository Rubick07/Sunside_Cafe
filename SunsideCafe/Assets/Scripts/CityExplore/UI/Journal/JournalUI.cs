using UnityEngine;
using UnityEngine.UI;
using System;

public class JournalUI : MonoBehaviour
{
    public static JournalUI instance;

    public event EventHandler OnJournalUIOpen;
    public event EventHandler OnJournalUIClose;

    [Header("BUTTON REFERENCE")]
    [SerializeField] private Button exitButton;
    [SerializeField] private Button profileButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button diaryButton;
    [SerializeField] private Button objectiveButton;

    [Header("PAGE REFERENCE")]
    [SerializeField] private GameObject profileGroupGameobject;
    [SerializeField] private GameObject inventoryGroupGameobject;
    [SerializeField] private GameObject diaryGroupGameobject;
    [SerializeField] private GameObject objectiveGroupGameobject;


    private float normalButtonHeight = 126f;
    private float normalButtonPosY = 379.3f;

    private float buttonInActiveHeight = 70.326f;
    private float buttonInActivePosY   = 351.46f;

    private void Awake()
    {
        instance = this;

        RectTransform profRectTransform = profileButton.GetComponent<RectTransform>();
        RectTransform invRectTransform = inventoryButton.GetComponent<RectTransform>();
        RectTransform diaryRectTransform = diaryButton.GetComponent<RectTransform>();
        RectTransform objectiveRectTransform = objectiveButton.GetComponent<RectTransform>();


        exitButton.onClick.AddListener(()=> 
        {
            Hide();
        });

        profileButton.onClick.AddListener(() => 
        {
            profileGroupGameobject.SetActive(true);
            inventoryGroupGameobject.SetActive(false);
            diaryGroupGameobject.SetActive(false);
            objectiveGroupGameobject.SetActive(false);

            profRectTransform.anchoredPosition = new Vector2(profRectTransform.anchoredPosition.x, normalButtonPosY);
            profRectTransform.sizeDelta = new Vector2(profRectTransform.sizeDelta.x, normalButtonHeight);

            invRectTransform.anchoredPosition = new Vector2(invRectTransform.anchoredPosition.x, buttonInActivePosY);
            invRectTransform.sizeDelta = new Vector2(invRectTransform.sizeDelta.x, buttonInActiveHeight);

            diaryRectTransform.anchoredPosition = new Vector2(diaryRectTransform.anchoredPosition.x, buttonInActivePosY);
            diaryRectTransform.sizeDelta = new Vector2(diaryRectTransform.sizeDelta.x, buttonInActiveHeight);

            objectiveRectTransform.anchoredPosition = new Vector2(objectiveRectTransform.anchoredPosition.x, buttonInActivePosY);
            objectiveRectTransform.sizeDelta = new Vector2(objectiveRectTransform.sizeDelta.x, buttonInActiveHeight);

        });

        inventoryButton.onClick.AddListener(() =>
        {
            profileGroupGameobject.SetActive(false);
            inventoryGroupGameobject.SetActive(true);
            diaryGroupGameobject.SetActive(false);
            objectiveGroupGameobject.SetActive(false);

            profRectTransform.anchoredPosition = new Vector2(profRectTransform.anchoredPosition.x, buttonInActivePosY);
            profRectTransform.sizeDelta = new Vector2(profRectTransform.sizeDelta.x, buttonInActiveHeight);

            invRectTransform.anchoredPosition = new Vector2(invRectTransform.anchoredPosition.x, normalButtonPosY);
            invRectTransform.sizeDelta = new Vector2(invRectTransform.sizeDelta.x, normalButtonHeight);

            diaryRectTransform.anchoredPosition = new Vector2(diaryRectTransform.anchoredPosition.x, buttonInActivePosY);
            diaryRectTransform.sizeDelta = new Vector2(diaryRectTransform.sizeDelta.x, buttonInActiveHeight);

            objectiveRectTransform.anchoredPosition = new Vector2(objectiveRectTransform.anchoredPosition.x, buttonInActivePosY);
            objectiveRectTransform.sizeDelta = new Vector2(objectiveRectTransform.sizeDelta.x, buttonInActiveHeight);

        });

        diaryButton.onClick.AddListener(() => 
        {
            profileGroupGameobject.SetActive(false);
            inventoryGroupGameobject.SetActive(false);
            diaryGroupGameobject.SetActive(true);
            objectiveGroupGameobject.SetActive(false);

            profRectTransform.anchoredPosition = new Vector2(profRectTransform.anchoredPosition.x, buttonInActivePosY);
            profRectTransform.sizeDelta = new Vector2(profRectTransform.sizeDelta.x, buttonInActiveHeight);

            invRectTransform.anchoredPosition = new Vector2(invRectTransform.anchoredPosition.x, buttonInActivePosY);
            invRectTransform.sizeDelta = new Vector2(invRectTransform.sizeDelta.x, buttonInActiveHeight);

            diaryRectTransform.anchoredPosition = new Vector2(diaryRectTransform.anchoredPosition.x, normalButtonPosY);
            diaryRectTransform.sizeDelta = new Vector2(diaryRectTransform.sizeDelta.x, normalButtonHeight);

            objectiveRectTransform.anchoredPosition = new Vector2(objectiveRectTransform.anchoredPosition.x, buttonInActivePosY);
            objectiveRectTransform.sizeDelta = new Vector2(objectiveRectTransform.sizeDelta.x, buttonInActiveHeight);

        });

        objectiveButton.onClick.AddListener(() =>
        {
            profileGroupGameobject.SetActive(false);
            inventoryGroupGameobject.SetActive(false);
            diaryGroupGameobject.SetActive(false);
            objectiveGroupGameobject.SetActive(true);

            profRectTransform.anchoredPosition = new Vector2(profRectTransform.anchoredPosition.x, buttonInActivePosY);
            profRectTransform.sizeDelta = new Vector2(profRectTransform.sizeDelta.x, buttonInActiveHeight);

            invRectTransform.anchoredPosition = new Vector2(invRectTransform.anchoredPosition.x, buttonInActivePosY);
            invRectTransform.sizeDelta = new Vector2(invRectTransform.sizeDelta.x, buttonInActiveHeight);

            diaryRectTransform.anchoredPosition = new Vector2(diaryRectTransform.anchoredPosition.x, buttonInActivePosY);
            diaryRectTransform.sizeDelta = new Vector2(diaryRectTransform.sizeDelta.x, buttonInActiveHeight);

            objectiveRectTransform.anchoredPosition = new Vector2(objectiveRectTransform.anchoredPosition.x, normalButtonPosY);
            objectiveRectTransform.sizeDelta = new Vector2(objectiveRectTransform.sizeDelta.x, normalButtonHeight);

        });


        profileGroupGameobject.SetActive(true);
        inventoryGroupGameobject.SetActive(false);
        diaryGroupGameobject.SetActive(false);
        objectiveGroupGameobject.SetActive(false);

        profRectTransform.anchoredPosition = new Vector2(profRectTransform.anchoredPosition.x, normalButtonPosY);
        profRectTransform.sizeDelta = new Vector2(profRectTransform.sizeDelta.x, normalButtonHeight);

        invRectTransform.anchoredPosition = new Vector2(invRectTransform.anchoredPosition.x, buttonInActivePosY);
        invRectTransform.sizeDelta = new Vector2(invRectTransform.sizeDelta.x, buttonInActiveHeight);

        diaryRectTransform.anchoredPosition = new Vector2(diaryRectTransform.anchoredPosition.x, buttonInActivePosY);
        diaryRectTransform.sizeDelta = new Vector2(diaryRectTransform.sizeDelta.x, buttonInActiveHeight);

        objectiveRectTransform.anchoredPosition = new Vector2(objectiveRectTransform.anchoredPosition.x, buttonInActivePosY);
        objectiveRectTransform.sizeDelta = new Vector2(objectiveRectTransform.sizeDelta.x, buttonInActiveHeight);

    }

    private void Start()
    {
        Hide();
    }


    public void ToggleJournal()
    {
        if (gameObject.activeInHierarchy)
            Hide();
        else Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);

        OnJournalUIOpen?.Invoke(this, EventArgs.Empty);
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        OnJournalUIClose?.Invoke(this, EventArgs.Empty);
    }
}
