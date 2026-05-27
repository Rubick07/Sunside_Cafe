using UnityEngine;

public class GameManagerChangeSceneAction : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void TriggerChangeScene()
    {
        if(GameManager.instance.GetCurrentActiveScene() != "City_Area")
        {
            GameManager.instance.RemoveScene();
        }

        GameManager.instance.AddScene(sceneName);
    }

}
