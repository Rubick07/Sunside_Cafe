using UnityEngine;

public class BaristaTutorialAction : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.OnGameSceneUnloadChanged += GameManager_OnGameSceneUnloadChanged;
    }

    private void GameManager_OnGameSceneUnloadChanged(object sender, System.EventArgs e)
    {
        DialogRunnerSingleton.instance.StartDialog("PlaceholderCafeKelar");
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameSceneUnloadChanged -= GameManager_OnGameSceneUnloadChanged;
    }
}
