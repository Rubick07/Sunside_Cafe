using UnityEngine;
using UnityEngine.UI;

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


    private void Awake()
    {
        instance = this;

        Init();
        Hide();
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
