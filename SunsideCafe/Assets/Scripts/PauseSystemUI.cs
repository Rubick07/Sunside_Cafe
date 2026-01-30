using UnityEngine;
using UnityEngine.UI;

public class PauseSystemUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            PauseSystem.instance.UnPause();
        });
        settingsButton.onClick.AddListener(() => 
        {
            SettingsMenu.instance.Show();
            Hide();
        });
        exitButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        PauseSystem.instance.OnGamePause += PauseSystem_OnGamePause;
        PauseSystem.instance.OnGameUnPause += PauseSystem_OnGameUnPause;

        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void PauseSystem_OnGameUnPause(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void PauseSystem_OnGamePause(object sender, System.EventArgs e)
    {
        Show();
    }

    private void OnDestroy()
    {
        PauseSystem.instance.OnGamePause -= PauseSystem_OnGamePause;
        PauseSystem.instance.OnGameUnPause -= PauseSystem_OnGameUnPause;
    }

}
