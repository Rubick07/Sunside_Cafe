using UnityEngine;
using UnityEngine.UI;
using System;

public class JournalUI : MonoBehaviour
{
    public static JournalUI instance;

    public event EventHandler OnJournalUIOpen;
    public event EventHandler OnJournalUIClose;

    [SerializeField] private Button exitButton;


    private void Awake()
    {
        instance = this;

        exitButton.onClick.AddListener(()=> 
        {
            Hide();
        });
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
