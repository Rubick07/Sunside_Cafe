using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    [SerializeField] private Button playButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        instance = this;

        playButton.onClick.AddListener(()=>
        {
            BlackscreenUI.instance.FadeIn(()=> Loader.Load(Loader.Scene.City_Area), 1f);
            AudioManager.Instance.StopMusic();
        });

        settingButton.onClick.AddListener(() =>
        {
            SettingsMenu.instance.Show();
            Hide();
        });

        exitButton.onClick.AddListener(() =>
        {
            ExitGame();
        });

    }

    private void Start()
    {
        Hide();
    }

    private void ExitGame()
    {
        Debug.Log("Keluar");
        Application.Quit();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
