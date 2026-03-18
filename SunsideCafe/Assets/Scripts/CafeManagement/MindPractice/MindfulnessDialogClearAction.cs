using UnityEngine;

public class MindfulnessDialogClearAction : MonoBehaviour
{
    [SerializeField] private string dialogTitle;
    private void Start()
    {
        GameManager.instance.OnGameSceneUnloadChanged += GameManager_OnGameSceneUnloadChanged;
    }

    private void GameManager_OnGameSceneUnloadChanged(object sender, System.EventArgs e)
    {
        DialogRunnerSingleton.instance.StartDialog(dialogTitle);
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameSceneUnloadChanged -= GameManager_OnGameSceneUnloadChanged;
    }
}
