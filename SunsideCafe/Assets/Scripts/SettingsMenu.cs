using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance;

    [Header("SLIDER REFERENCE")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [Header("BUTTON REFERENCE")]
    [SerializeField] private Button musicButton;
    [SerializeField] private Button sfxButton;
    [SerializeField] private Button applyButton;
    [SerializeField] private Button backButton;
    [Header("DROPDOWN REFERENCE")]
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown graphicsDropdown;


    Resolution[] resolutions;

    private void Awake()
    {
        instance = this;

        Init();
        Hide();
    }

    private void Start()
    {
        resolutions = Screen.resolutions;

        graphicsDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string label = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(label);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }

        graphicsDropdown.AddOptions(options);
        graphicsDropdown.value = currentIndex;
        graphicsDropdown.RefreshShownValue();
    }

    private void Init()
    {
        musicButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.ToggleMusic();
        });

        sfxButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.ToggleSFX();
        });

        applyButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.ApplyVolumeSettings();
        });

        backButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.ApplyVolumeSettings();
            Hide();
        });

        musicSlider.onValueChanged.AddListener((a) =>
        {
            AudioManager.Instance.SetMusicVolume(a);
        });

        sfxSlider.onValueChanged.AddListener((a) =>
        {
            AudioManager.Instance.SetSFXVolume(a);
        });

        resolutionDropdown.onValueChanged.AddListener(SetScreenMode);
        graphicsDropdown.onValueChanged.AddListener(SetResolution);

    }

    public void SetScreenMode(int index)
    {
        switch (index)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];

        Screen.SetResolution(
            res.width,
            res.height,
            Screen.fullScreen
        );

        PlayerPrefs.SetInt("resolution", index);
    }


    public void Show()
    {
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
